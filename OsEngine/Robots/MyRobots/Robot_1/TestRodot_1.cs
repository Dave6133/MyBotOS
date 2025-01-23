using OsEngine.Entity;
using OsEngine.OsTrader.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsEngine.Robots.MyRobots.Robot_1
{
    public class TestRodot_1 : BotPanel
    {
        

        public TestRodot_1(string name, StartProgram startProgram) : base(name, startProgram)
        {
            TabCreate(BotTabType.Simple);

            TabCreate(BotTabType.Simple);

            CreateParameter("Lot", 5, 1, 20, 2);

           
        }

        public override string GetNameStrategyType()
        {
            return nameof(TestRodot_1);
        }

        public override void ShowIndividualSettingsDialog()
        {
            WindowTestRobot_1 windowTestRobot_1 = new WindowTestRobot_1();

            windowTestRobot_1.TextBlockLot.Text = ((StrategyParameterInt)Parameters[0]).ValueInt.ToString();

            windowTestRobot_1.Show();
        }
    }
}
