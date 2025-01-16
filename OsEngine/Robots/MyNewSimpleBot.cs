using System;
using System.Collections.Generic;
using OsEngine.Entity;
using OsEngine.Indicators;
using OsEngine.OsTrader.Panels;
using OsEngine.OsTrader.Panels.Attributes;
using OsEngine.OsTrader.Panels.Tab;


namespace OsEngine.Robots
{
    [Bot("MyNewSimpleBot")]
    internal class MyNewSimpleBot : BotPanel
    {
        public MyNewSimpleBot(string name, StartProgram startProgram)
            : base(name, startProgram)
        {
            TabCreate(BotTabType.Simple);
            TabToTrade = TabsSimple[0];
        }

        public BotTabSimple TabToTrade;

        public override string GetNameStrategyType()
        {
            return "MyNewSimpleBot";
        }

        public override void ShowIndividualSettingsDialog()
        {
            //throw new NotImplementedException();
        }
    }
}
