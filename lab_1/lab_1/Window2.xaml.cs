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

namespace lab_1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void btn2ex_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }
        int k = 0;
        private void findwinner()
        {
            if (XO1.Content==XO2.Content & XO2.Content == XO3.Content & XO3.Content==XO4.Content & !XO1.IsEnabled)
            {
                if (XO1.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO6.Content == XO7.Content & XO7.Content == XO8.Content & XO8.Content == XO9.Content & !XO6.IsEnabled)
            {
                if (XO6.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO11.Content == XO12.Content & XO12.Content == XO13.Content & XO13.Content == XO14.Content & !XO11.IsEnabled)
            {
                if (XO11.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO16.Content == XO17.Content & XO17.Content == XO18.Content & XO18.Content == XO19.Content & !XO16.IsEnabled)
            {
                if (XO16.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO21.Content == XO22.Content & XO22.Content == XO23.Content & XO23.Content == XO24.Content & !XO21.IsEnabled)
            {
                if (XO21.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO2.Content == XO3.Content & XO3.Content == XO4.Content & XO4.Content == XO5.Content & !XO2.IsEnabled)
            {
                if (XO2.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO7.Content == XO8.Content & XO8.Content == XO9.Content & XO9.Content == XO10.Content & !XO7.IsEnabled)
            {
                if (XO7.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO12.Content == XO13.Content & XO13.Content == XO14.Content & XO14.Content == XO15.Content & !XO12.IsEnabled)
            {
                if (XO12.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO17.Content == XO18.Content & XO18.Content == XO19.Content & XO19.Content == XO20.Content & !XO17.IsEnabled)
            {
                if (XO17.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO22.Content == XO23.Content & XO23.Content == XO24.Content & XO24.Content == XO25.Content & !XO22.IsEnabled)
            {
                if (XO22.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO2.Content == XO3.Content & XO3.Content == XO4.Content & XO4.Content == XO5.Content & !XO2.IsEnabled)
            {
                if (XO2.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO2.Content == XO7.Content & XO7.Content == XO12.Content & XO12.Content == XO17.Content & !XO2.IsEnabled)
            {
                if (XO2.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO3.Content == XO8.Content & XO8.Content == XO13.Content & XO13.Content == XO18.Content & !XO3.IsEnabled)
            {
                if (XO3.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO4.Content == XO9.Content & XO9.Content == XO14.Content & XO14.Content == XO19.Content & !XO4.IsEnabled)
            {
                if (XO4.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO5.Content == XO10.Content & XO10.Content == XO15.Content & XO15.Content == XO20.Content & !XO5.IsEnabled)
            {
                if (XO5.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }            
            if (XO6.Content == XO11.Content & XO11.Content == XO16.Content & XO16.Content == XO21.Content & !XO6.IsEnabled)
            {
                if (XO6.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO7.Content == XO12.Content & XO12.Content == XO17.Content & XO17.Content == XO22.Content & !XO7.IsEnabled)
            {
                if (XO7.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO8.Content == XO13.Content & XO13.Content == XO18.Content & XO18.Content == XO23.Content & !XO8.IsEnabled)
            {
                if (XO8.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO9.Content == XO14.Content & XO14.Content == XO19.Content & XO19.Content == XO24.Content & !XO9.IsEnabled)
            {
                if (XO9.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO10.Content == XO15.Content & XO15.Content == XO20.Content & XO20.Content == XO25.Content & !XO10.IsEnabled)
            {
                if (XO10.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO1.Content == XO7.Content & XO7.Content == XO13.Content & XO13.Content == XO19.Content & !XO1.IsEnabled)
            {
                if (XO1.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO2.Content == XO8.Content & XO8.Content == XO14.Content & XO14.Content == XO20.Content & !XO2.IsEnabled)
            {
                if (XO2.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO6.Content == XO12.Content & XO12.Content == XO18.Content & XO18.Content == XO24.Content & !XO6.IsEnabled)
            {
                if (XO6.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO7.Content == XO13.Content & XO13.Content == XO19.Content & XO19.Content == XO25.Content & !XO7.IsEnabled)
            {
                if (XO7.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO4.Content == XO8.Content & XO8.Content == XO12.Content & XO12.Content == XO16.Content & !XO4.IsEnabled)
            {
                if (XO4.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO10.Content == XO14.Content & XO14.Content == XO18.Content & XO18.Content == XO22.Content & !XO10.IsEnabled)
            {
                if (XO10.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO5.Content == XO9.Content & XO9.Content == XO13.Content & XO13.Content == XO7.Content & !XO5.IsEnabled)
            {
                if (XO5.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
            if (XO9.Content == XO13.Content & XO13.Content == XO17.Content & XO17.Content == XO21.Content & !XO9.IsEnabled)
            {
                if (XO9.Content == "x") winnercon.Content = "Переміг перший гравець";
                else winnercon.Content = "Переміг другий гравець";
                return;
            }
        }

        private void XO_Click(object sender, RoutedEventArgs e)
        {
            Button XOal = (Button)e.Source;
            XOal.IsEnabled = false;
            if (k == 0)
            {
                XOal.Content = "x";
                k = 1;
            }
            else
            {
                XOal.Content = "o";
                k = 0;
            }
            findwinner();
            if (winnercon.Content != "") XO1.IsEnabled = XO2.IsEnabled = XO3.IsEnabled = XO4.IsEnabled = XO5.IsEnabled = XO6.IsEnabled = XO7.IsEnabled = XO8.IsEnabled = XO9.IsEnabled = XO10.IsEnabled = XO11.IsEnabled = XO12.IsEnabled = XO13.IsEnabled = XO14.IsEnabled = XO15.IsEnabled = XO16.IsEnabled = XO17.IsEnabled = XO18.IsEnabled = XO19.IsEnabled = XO20.IsEnabled = XO21.IsEnabled = XO22.IsEnabled = XO23.IsEnabled = XO24.IsEnabled = XO25.IsEnabled = false;
        }
    }
}
