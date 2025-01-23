using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OsEngine.Robots.Lessons.Lesson_17.task_2
{
    /// <summary>
    /// Логика взаимодействия для Test_Rodot_Window_2.xaml
    /// </summary>
    public partial class Test_Rodot_Window_2 : Window
    {
        public Test_Rodot_Window_2(Test_Rodot_2 test_Rodot_2)
        {
            InitializeComponent();

            vm_2 = new VM_2(test_Rodot_2);

            DataContext = vm_2;
        }

        VM_2 vm_2;
    }
}
