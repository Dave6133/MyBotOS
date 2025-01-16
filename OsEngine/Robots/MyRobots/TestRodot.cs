using OsEngine.Entity;
using OsEngine.OsTrader.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsEngine.Robots.MyRobots
{
    internal class TestRodot : BotPanel
    {
        public TestRodot(string name, StartProgram startProgram) : base(name, startProgram)
        {
            TabCreate(BotTabType.Simple); // Создает вкладку
                                          // this.- покажет все элементы класса BotPanel
            TabCreate(BotTabType.Simple);

            TabCreate(BotTabType.Simple);

            TabCreate(BotTabType.Simple);

            CreateParameter("Lot", 5, 1, 20, 2);

            CreateParameter("Stop", 38, 0, 0, 0);

            CreateParameter("Take", 7, 0, 0, 0);

            CreateParameter("Mode", "Edit", new[] {"Edit ","Trading"});

            

            


        }

        public override string GetNameStrategyType()
        {
            return nameof(TestRodot);
        }

        public override void ShowIndividualSettingsDialog()
        {
            MyRobotWindow myRobotWindow = new MyRobotWindow();

            myRobotWindow.TextBlockLot.Text = ((StrategyParameterInt)Parameters[0]).ValueInt.ToString();//выводит параметр 5 в MyRobotWindow

            myRobotWindow.TextBlockStop.Text = ((StrategyParameterInt)Parameters[1]).ValueInt.ToString();

            myRobotWindow.TextBlockTake.Text = ((StrategyParameterInt)Parameters[2]).ValueInt.ToString();

            myRobotWindow.Show();// Показывает окно MyRobotWindow при нажатии "настройки торгового бота"
        }
    }
}
