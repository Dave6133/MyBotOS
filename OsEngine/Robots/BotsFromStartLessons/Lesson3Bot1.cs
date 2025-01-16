using System.Collections.Generic;
using System.Windows;
using OsEngine.Entity;
using OsEngine.Language;
using OsEngine.Market;
using OsEngine.OsTrader.Panels;
using OsEngine.OsTrader.Panels.Attributes;
using OsEngine.OsTrader.Panels.Tab;

namespace OsEngine.Robots.BotsFromStartLessons
{
    [Bot("Lesson3Bot1")]
    public class Lesson3Bot1 : BotPanel
    {
        BotTabSimple _tabToTrade;

        StrategyParameterString _regime;

        StrategyParameterDecimal _volume;
        public Lesson3Bot1(string name, StartProgram startProgram) : base(name, startProgram)
        {
            TabCreate(BotTabType.Simple);

            _tabToTrade = TabsSimple[0];

            _tabToTrade.CandleFinishedEvent += _tabToTrade_CandleFinishedEvent;

            _regime = CreateParameter("regime", "Off", new[] { "Off", "On" });

            _volume = CreateParameter("Volume", 10m, 1, 10, 1);

        }

        private void _tabToTrade_CandleFinishedEvent(List<Candle> candles)
        {
            // вызывается на каждой новой свече
            if (_regime.ValueString == "off")
            {
                return;
            }

            if(candles.Count < 10)
            {
                return;
            }


            List<Position> positions = _tabToTrade.PositionsAll;

            if (positions.Count == 0)
            {// открытие позиции
                Candle lastCandle = candles[candles.Count - 1];// берем последнюю свечу

                Candle prevCandle = candles[candles.Count - 2];// берем предпоследнюю свечу

                if (lastCandle.IsUp == true && prevCandle.IsUp == true) 
                { // покупаем.обе свечи ростут

                    _tabToTrade.BuyAtMarket(_volume.ValueDecimal);


                }

            }
            else
            {// закрытие позиции

                Candle prevCandle = candles[candles.Count - 2];// берем предпоследнюю свечу

                decimal iowCandle = prevCandle.Low; // взяли у свечи нижнее значение

                Position position = positions[0]; // берем позицию из массива

                _tabToTrade.CloseAtTrailingStopMarket(position, iowCandle);

            }
        }

        public override string GetNameStrategyType()
        {
            return "Lesson3Bot1";
        }

        public override void ShowIndividualSettingsDialog()
        {
            throw new System.NotImplementedException();
        }
    }
}
