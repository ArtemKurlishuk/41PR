using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeLord_MVVM_Kurlishuk.ViewModell;

namespace TimeLord_MVVM_Kurlishuk.View
{
    /// <summary>
    /// Логика взаимодействия для Timer.xaml
    /// </summary>
    public partial class Timer : Page
    {
        public Timer()
        {
            InitializeComponent();
            DataContext = new VMTimer();
        }

        private void Counter_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
