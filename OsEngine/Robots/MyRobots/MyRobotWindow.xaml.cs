﻿using System;
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

namespace OsEngine.Robots.MyRobots
{
    /// <summary>
    /// Логика взаимодействия для MyRobotWindow.xaml
    /// </summary>
    public partial class MyRobotWindow : Window
    {
        public MyRobotWindow(TestRodot testRodot)
        {
            InitializeComponent();

            vm = new VM(testRodot);

            DataContext = vm;
        }

       

        private VM vm;




    }
}
