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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Window1 mw;
            mw = new Window1();
            Hide();
            mw.Show();
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Window2 mw;
            mw = new Window2();
            Hide();
            mw.Show();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            Window3 mw;
            mw = new Window3();
            Hide();
            mw.Show();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            Window4 mw;
            mw = new Window4();
            Hide();
            mw.Show();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
