using OsEngine.Charts.CandleChart.Indicators;
using OsEngine.Entity;
using OsEngine.OsTrader.Panels;
using OsEngine.OsTrader.Panels.Attributes;
using OsEngine.OsTrader.Panels.Tab;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OsEngine.Robots.MyRobots.ReversVolumeRobot
{
    [Bot(nameof(ReversVolumeRobot))]//Добавляет робота в OS
    public class ReversVolume : BotPanel
    {
        public ReversVolume(string name, StartProgram startProgram) : base(name, startProgram)
        {
            TabCreate(BotTabType.Simple);//Создает источника типа «Simple». В этот момент в робота добавляется один источник BotTabSimple в массив TabsSimple.

            _tab = TabsSimple[0];                                            //сохраняет переменную BotTabSimple в поле класса.

            _tab.CandleFinishedEvent += _tab_CandleFinishedEvent;              //Подписаться на событие завершения свечи.

            _tab.PositionOpeningSuccesEvent += _tab_PositionOpeningSuccesEvent;  //подписаться на событие успешного открытия сделки.

            _risk = CreateParameter("Risk %", 1m, 0.1m, 10m, 0.1m);               //Риск на сделку

            _profitKoef = CreateParameter("Profit koef", 1m, 1m, 10m, 0.5m);       //Во сколько раз тейк больше стопа

            _countCandles = CreateParameter("Candles count average volume", 1, 1, 100, 1);//Кол-во свечей для вычисления среднего объема

            _countDownCandles = CreateParameter("Count down candles", 1, 1, 7, 1);//Кол-во падующих свечей перед объемным разворотом

            _koefVolume = CreateParameter("Koef volumes", 1m, 1m, 10m, 0.1m);//Во сколько раз объем привышает средний объем для выполнения условия разворота
        }

        



        #region Fields+==============================================

        private BotTabSimple _tab;
        /// <summary>
        /// Риск на сделку
        /// </summary>
        private StrategyParameterDecimal _risk;
        /// <summary>
        /// Во сколько раз тейк больше стопа
        /// </summary>
        private StrategyParameterDecimal _profitKoef;
        /// <summary>
        /// Кол-во свечей для вычисления среднего объема
        /// </summary>
        private StrategyParameterInt _countCandles;
        /// <summary>
        /// Кол-во падующих свечей перед объемным разворотом
        /// </summary>
        private StrategyParameterInt _countDownCandles;
        /// <summary>
        /// Во сколько раз объем привышает средний объем для выполнения условия разворота
        /// </summary>
        private StrategyParameterDecimal _koefVolume;
        /// <summary>
        /// Кол-во пунктов для стопа
        /// </summary>
        private int _punktsStop = 0;



        #endregion


        #region Mehods==============================================
        private void _tab_CandleFinishedEvent(List<Candle> candles)
        {
            List<Position> positions = _tab.PositionOpenLong;

            Candle candle = candles.Last();

            if (positions.Count > 0)
            {
                Position position = positions.First();

                if (candle.Close > position.EntryPrice + _punktsStop * _tab.Securiti.PriceStep)
                {
                    UpdateStopLoss(position);
                }

                return;
            }

            if (candles.Count < _countCandles.ValueInt +1) return;//Если кол-во свечей маленькое то выходим

            for(int i = candles.Count - 2; i > candles.Count - 2 - _countDownCandles.ValueInt; i--)//Кол-во падающих свечей
            {
                if (candles[i].Close > candles[i].Open) return;
            }

            int count = _countCandles.ValueInt;

            decimal averageVolume = 0;

            for (int i = candles.Count - count; i < candles.Count; i++)//candles.Count - общее кол-во
            {
                averageVolume += candles[i].Volume; //Сумарный объем
            }

            averageVolume /= count;

            if (candle.Close < (candle.High + candle.Low) / 2                       //Если цена меньше середины свечи или объем на последней свечи будет меньше чем средний объем * _koefVolume
                || candle.Volume < averageVolume * _koefVolume.ValueDecimal) return;

            _punktsStop = (int)((candle.Close - candle.Low) / _tab.Securiti.PriceStep);

            if (_punktsStop < 5) return;

            decimal amountStop = _punktsStop * _tab.Securiti.PriceStepCost;//Стоймость стопа в деньгах

            decimal amountRisk = _tab.Portfolio.ValueBegin* _risk.ValueDecimal / 100;//Риск в деньгах

            decimal volume = amountRisk / amountStop;//Объем в деньгах

            if (_tab.Securiti.Go > 1)// Проверка горантийного обеспечения
            {
                decimal maxLot = _tab.Portfolio.ValueBegin / _tab.Securiti.Go;

                if (maxLot < volume) return;

                
            }

            _tab.BuyAtMarket(volume);//Заявка по рынку
        }

        private void UpdateStopLoss(Position position )
        {
            _tab.SellAtStopCancel();

            decimal stopMarketPrice = position.EntryPrice - 100 * _tab.Securiti.PriceStep;

            _tab.CloseAtStop(position, position.EntryPrice, stopMarketPrice);
        }



        private void _tab_PositionOpeningSuccesEvent(Position position)
        {
            decimal take = position.EntryPrice + _punktsStop * _profitKoef.ValueDecimal;// Подсчет профита

            decimal stop = position.EntryPrice - _punktsStop;

            decimal stopMarketPrice = stop - 100 * _tab.Securiti.PriceStep;

            _tab.CloseAtProfit(position, take, take);

            _tab.CloseAtStop(position, stop, stopMarketPrice);
        }

        

        public override string GetNameStrategyType()
        {
            return nameof(ReversVolume);
        }

        public override void ShowIndividualSettingsDialog()
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
