using OsEngine.Entity;
using OsEngine.OsTrader.Panels;
using OsEngine.OsTrader.Panels.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsEngine.Robots.Lessons.Lesson_17.task_2
{
    [Bot(nameof(task_2))]//Добавляет робота в OS
    public class Test_Rodot_2 : BotPanel
    {
        public int Lot;

        public int Stop;

        public int Take;
        public Test_Rodot_2(string name, StartProgram startProgram) : base(name, startProgram)
        {
            TabCreate(BotTabType.Simple); // Создает вкладку
                                          // this.- покажет все элементы класса BotPanel
            TabCreate(BotTabType.Simple);

            CreateParameter("Lot", 5, 1, 20, 2);

            CreateParameter("Stop", 38, 0, 0, 0);

            CreateParameter("Take", 7, 0, 0, 0);

           // CreateParameter("Mode", "Edit", new[] { "Edit ", "Trading" });
        }

        public override string GetNameStrategyType()
        {
            return nameof(Test_Rodot_2);
        }

        public override void ShowIndividualSettingsDialog()
        {
            Test_Rodot_Window_2 test_Rodot_Window_2 = new Test_Rodot_Window_2(this);

            

            test_Rodot_Window_2.Show();

            test_Rodot_Window_2.Closing += Test_Rodot_Window_2_Closing;



        }

        private void Test_Rodot_Window_2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((StrategyParameterInt)Parameters[0]).ValueInt = Lot;

            ((StrategyParameterInt)Parameters[1]).ValueInt = Stop;

            ((StrategyParameterInt)Parameters[2]).ValueInt = Take;


        }
    }
}
