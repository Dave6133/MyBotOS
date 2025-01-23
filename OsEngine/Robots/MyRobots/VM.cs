using OsEngine.OsTrader.Panels.Tab;
using OsEngine.Robots.MyRobots.Robot_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsEngine.Robots.MyRobots;
using OsEngine.Entity;

namespace OsEngine.Robots.MyRobots
{
    public class VM : BaseVM
    {
        public VM(TestRodot testRodot)
        {
            _testRodot = testRodot;

           

            TextBoxLot = ((StrategyParameterInt)_testRodot.Parameters[0]).ValueInt;

            _testRodot.ParametrsChangeByUser += _testRodot_ParametrsChangeByUser;
            _testRodot.a = TextBoxLot;


           
        }

       

        public TestRodot _testRodot ;






        #region Property=============================================== 


        public int Lot =0;


        public int TextBoxLot
        {
            get => _textBoxLot;

            set
            {
                _textBoxLot = value;
                OnPropertyChanged(nameof(TextBoxLot));
                 _testRodot.a = _textBoxLot;
            }
        }
        int _textBoxLot;

        #endregion

        private void _testRodot_ParametrsChangeByUser()
        {
            

            TextBoxLot = ((StrategyParameterInt)_testRodot.Parameters[0]).ValueInt;  

           // Lot = ((StrategyParameterInt)_testRodot.Parameters[0]).ValueInt;
        }


    }
}
