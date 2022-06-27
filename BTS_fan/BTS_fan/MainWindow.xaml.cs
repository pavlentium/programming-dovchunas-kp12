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

namespace BTS_fan
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

        private void Button_billboard(object sender, RoutedEventArgs e)
        {
            Billboard bw = new Billboard();
            Close();
            bw.Show();
            bw.change_billboard();
        }

        private void Button_author(object sender, RoutedEventArgs e)
        {
            Author aw = new Author();
            Close();
            aw.Show();
        }
        private void Button_exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Group(object sender, RoutedEventArgs e)
        {
            Groups gw = new Groups();
            Close();
            gw.Show();
        }

        private void Button_Search(object sender, RoutedEventArgs e)
        {
            Search sw = new Search();
            Close();
            sw.Show();

        }

        private void Button_tours(object sender, RoutedEventArgs e)
        {
            Tours tw = new Tours();
            Close();
            tw.Show();
        }

    }
}
