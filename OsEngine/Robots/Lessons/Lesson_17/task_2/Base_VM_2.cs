using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OsEngine.Robots.Lessons.Lesson_17.task_2
{
    public class Base_VM_2 : INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        //============================================= Events =========================================

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
