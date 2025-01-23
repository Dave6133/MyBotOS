using OsEngine.Entity;
using OsEngine.Robots.MyRobots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsEngine.Robots.Lessons.Lesson_17.task_2
{
    public class VM_2 : Base_VM_2
    {
        public VM_2(Test_Rodot_2 test_Rodot_2)
        {
            _test_Rodot_2 = test_Rodot_2;

            TextBoxLot = ((StrategyParameterInt)_test_Rodot_2.Parameters[0]).ValueInt;

            _test_Rodot_2.Lot = TextBoxLot;

            TextBoxStop = ((StrategyParameterInt)_test_Rodot_2.Parameters[1]).ValueInt;

            _test_Rodot_2.Stop = TextBoxStop;

            TextBoxTake = ((StrategyParameterInt)_test_Rodot_2.Parameters[2]).ValueInt;

            _test_Rodot_2.Take = TextBoxTake;

           



        }

        

        public Test_Rodot_2 _test_Rodot_2;

        #region Propertys =================================================================================== 
        public int TextBoxLot
        {
            get => _textBoxLot;

            set
            {
                _textBoxLot = value;

                OnPropertyChanged(nameof(TextBoxLot));

                _test_Rodot_2.Lot = _textBoxLot;
            }
        }
        int _textBoxLot;


        public int TextBoxStop
        {
            get => _textBoxStop;

            set
            {
                _textBoxStop = value;

                OnPropertyChanged(nameof(TextBoxStop));

                _test_Rodot_2.Stop = _textBoxStop;
            }
        }
        int _textBoxStop;

        public int TextBoxTake
        {
            get => _textBoxTake;

            set
            {
                _textBoxTake = value;

                OnPropertyChanged(nameof(TextBoxTake));

                _test_Rodot_2.Take = _textBoxTake;
            }
        }
        int _textBoxTake;

        #endregion


        #region Method ===================================================================================

       


        #endregion
    }
}
