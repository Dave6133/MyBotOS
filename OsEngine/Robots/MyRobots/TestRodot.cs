using OsEngine.Entity;
using OsEngine.OsTrader.Panels;
using OsEngine.Robots.MyRobots.Robot_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Runtime;
using OsEngine.Robots.MyRobots;

namespace OsEngine.Robots.MyRobots
{
    public class TestRodot : BotPanel
    {

        public int a;
        
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

           // VM vm1 = new VM(this);

            //MyRobotWindow myRobotWindow = new MyRobotWindow(this);

        }

        public override string GetNameStrategyType()
        {
            return nameof(TestRodot);
        }

        public override void ShowIndividualSettingsDialog()
        {
            MyRobotWindow myRobotWindow = new MyRobotWindow(this);

            VM vm1 = new VM(this);



            // myRobotWindow.TextBlockLot.Text = ((StrategyParameterInt)Parameters[0]).ValueInt.ToString();//выводит параметр 5 в MyRobotWindow

            //myRobotWindow.TextBlockStop.Text = ((StrategyParameterInt)Parameters[1]).ValueInt.ToString();

            // myRobotWindow.TextBlockTake.Text = ((StrategyParameterInt)Parameters[2]).ValueInt.ToString();



            myRobotWindow.Closing += MyRobotWindow_Closing;


            myRobotWindow.Show();



            



        }

        private void MyRobotWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((StrategyParameterInt)Parameters[0]).ValueInt = a;
        }





        //private void MyRobotWindow_Closing1(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    VM vm1 = new VM(this);
        //    MyRobotWindow myRobotWindow = new MyRobotWindow(this);
        //    ((StrategyParameterInt)Parameters[0]).ValueInt = vm1.TextBoxLot;
        //}



        //private void _testRodot_ParametrsChangeByUser1()
        //{
        //    MyRobotWindow myRobotWindow = new MyRobotWindow(this);

        //    VM vm1 = new VM(this);

        //    vm1.TextBoxLot = int.Parse(myRobotWindow.TextBoxLot1.Text) ;

        //    ((StrategyParameterInt)Parameters[0]).ValueInt = vm1.TextBoxLot;
        //}


    }
}
