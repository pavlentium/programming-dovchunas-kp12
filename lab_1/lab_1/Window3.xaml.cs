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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void btn3ex_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }
        static string zn = "";
        static double fin = 0;
        private void ans()
        {
            double a, b;
            string[] dod = result.Text.Split(zn);
            if (dod[0].Contains(","))
            {
                string[] adod = dod[0].Split(",");
                a = Convert.ToInt32(adod[0]) + Convert.ToInt32(adod[1]) / (Math.Pow(10, adod[1].Length));
            }
            else a = Convert.ToDouble(dod[0]);

            if (dod[1].Contains(","))
            {
                string[] adod = dod[1].Split(",");
                b = Convert.ToInt32(adod[0]) + Convert.ToInt32(adod[1]) / (Math.Pow(10, adod[1].Length));
            }
            else b = Convert.ToDouble(dod[1]);

            switch (zn)
            {
                case "/":
                    fin = Math.Round(a / b, 4);
                    break;
                case "*":
                    fin = Math.Round(a * b, 4);
                    break;
                case "+":
                    fin = Math.Round(a + b, 4);
                    break;
                case "-":
                    fin = Math.Round(a - b, 4);
                    break;
            }
            result.Text = Convert.ToString(fin);
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            ans();
            zn = "";
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            result.Text = "";
            zn = "";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (result.Text.Length > 0)
            {
                result.Text = result.Text.Remove(result.Text.Length - 1);
            }
            if (result.Text == "") zn = "";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            result.Text += (string)btn5.Content;
        }
        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            result.Text += (string)btn6.Content;
        }
        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            result.Text += (string)btn7.Content;
        }
        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            result.Text += (string)btn9.Content;
        }
        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            result.Text += (string)btn10.Content;
        }
        private void btn11_Click(object sender, RoutedEventArgs e)
        {
            result.Text += (string)btn11.Content;
        }
        private void btn13_Click(object sender, RoutedEventArgs e)
        {
            result.Text += (string)btn13.Content;
        }
        private void btn14_Click(object sender, RoutedEventArgs e)
        {
            result.Text += (string)btn14.Content;
        }
        private void btn15_Click(object sender, RoutedEventArgs e)
        {
            result.Text += (string)btn15.Content;
        }
        private void btn18_Click(object sender, RoutedEventArgs e)
        {
            result.Text += (string)btn18.Content;
        }



        private void btn20_Click(object sender, RoutedEventArgs e)
        {
            if (zn != "")ans();
            result.Text += "+";
            zn = "+";
        }

        private void btn16_Click(object sender, RoutedEventArgs e)
        {
            if (zn != "")ans();
            result.Text += "-";
            zn = "-";
        }

        private void btn12_Click(object sender, RoutedEventArgs e)
        {
            if (zn != "")ans();
            result.Text += "/";
            zn = "/";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            if (zn != "")ans();
            result.Text += "*";
            zn = "*";
        }

        private void btn19_Click(object sender, RoutedEventArgs e)
        {
            if (!result.Text.Contains(","))
            result.Text += ",";
        }

        private void btn17_Click(object sender, RoutedEventArgs e)
        {
            fin *= (-1);
            result.Text = Convert.ToString(fin);
        }
    }
}
