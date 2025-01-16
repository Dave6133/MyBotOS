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
    [Bot("Lesson2Bot2")]
    public class Lesson2Bot2 : BotPanel
    {
        public Lesson2Bot2(string name, StartProgram startProgram) : base(name, startProgram)
        {
            // 1 Создаем параметр string

            StrategyParameterString regime = CreateParameter("regime", "Off", new[] { "Off", "On" });

            // 2 Создаем параметр int 

            StrategyParameterInt smaLen = CreateParameter("sma Len", 15, 1, 20, 1);

            // 3 Создаем параметр bool

            StrategyParameterBool isUpCandleToEntry = CreateParameter("Is up candle", true);

            // 4 Создаем параметр  decimal

            StrategyParameterDecimal bollingerDeviation = CreateParameter("Bollinger deviation", 1.4m, 1, 2, 0.1m);

            // 5 Создаем параметр TemeOfDay

            StrategyParameterTimeOfDay startToTrade = CreateParameterTimeOfDay("Start to trade", 11, 00, 00, 00);

        }

        public override string GetNameStrategyType()
        {
            return "Lesson2Bot2";
        }

        public override void ShowIndividualSettingsDialog()
        {
            throw new System.NotImplementedException();
        }
    }
}
