using OsEngine.Entity;
using OsEngine.OsTrader.Panels;
using OsEngine.OsTrader.Panels.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsEngine.Robots.Lessons.Lesson_17.task_1
{
    [Bot(nameof(task_1))]
    public class Test_Rodot_1 : BotPanel
    {
        
        public Test_Rodot_1(string name, StartProgram startProgram) : base(name, startProgram)
        {
            TabCreate(BotTabType.Simple); 

            TabCreate(BotTabType.Simple);

            TabCreate(BotTabType.Simple);

            TabCreate(BotTabType.Simple);

            CreateParameter("Lot", 5, 1, 20, 2);

            CreateParameter("Stop", 38, 0, 0, 0);

            CreateParameter("Take", 7, 0, 0, 0);

            CreateParameter("Mode", "Edit", new[] { "Edit ", "Trading" });
        }

        public override string GetNameStrategyType()
        {
            return nameof(Test_Rodot_1);
        }

        public override void ShowIndividualSettingsDialog()
        {

            Test_Rodot_Window_1 test_Rodot_Window_1 = new Test_Rodot_Window_1();

            test_Rodot_Window_1.TextBlockLot.Text = ((StrategyParameterInt)Parameters[0]).ValueInt.ToString();

            test_Rodot_Window_1.TextBlockStop.Text = ((StrategyParameterInt)Parameters[1]).ValueInt.ToString();

            test_Rodot_Window_1.TextBlockTake.Text = ((StrategyParameterInt)Parameters[2]).ValueInt.ToString();

            test_Rodot_Window_1.Show();
        }
    }
}
