using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OsEngine.Robots.MyRobots
{
    public class BaseVM : INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) //Если есть привязка к событию PropertyChanged
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));//то создается объект new PropertyChangedEventArgs(prop) и передается строка "Number"
            }
        }

        //============================================= Events =========================================

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
