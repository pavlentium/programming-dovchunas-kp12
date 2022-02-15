using System;
using System.IO;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btn1ex_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"D:\Навчання\Прога\codein\lab_1\studata.txt",true);
            sw.Write("\n" + zbook.Text + ";" + pib.Text + ";" + group.Text + ";");
            sw.Close();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            List<string> addinfo = new List<string>();
            StreamReader sr = new StreamReader(@"D:\Навчання\Прога\codein\lab_1\studata.txt", false);
            
            while (!sr.EndOfStream)
            {
                string[] input = sr.ReadLine().Split(';');
                if (input[0] != zbook.Text)
                {
                    addinfo.Add(input[0] + ";" + input[1] + ";" + input[2] + ";");

                }
            }
            sr.Close();
            StreamWriter sw = new StreamWriter(@"D:\Навчання\Прога\codein\lab_1\studata.txt", false);
            for (int i = 0; i < addinfo.Count; i++)
            {
                if (i == addinfo.Count - 1) sw.Write(addinfo[i]);
                else sw.WriteLine(addinfo[i]);
            }
            sw.Close();
        }
    }
}
