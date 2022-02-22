using System;
using static System.Math;
using System.Collections.Generic;
using System.IO;
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



namespace prac01
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            kspr = Convert.ToInt32(testtex.Text);
        }
        public double inter = 0;
        public List<List<double>> inters = new List<List<double>>();
        public int intc = 0;
        public static int kspr;
        public (double, double) disp(List<double> disper)
        {
            int len = disper.Count;
            double s = 0, m = 0;
            for (int i = 0; i < len; i++) m += disper[i];
            m /= len;
            for (int i = 0; i < len; i++) s += Pow(disper[i] - m, 2);
            s /= len - 1;
            s = Sqrt(s);
            return (s, m);
        }
        public static int cringe(List<double> lies, double yi)
        {
            double mi = 0, si = 0, tp, tt;
            lies.Remove(yi);
            for (int i = 0; i < lies.Count; i++)
            {
                mi += lies[i];
            }
            for (int i = 0; i < lies.Count; i++)
            {
                si += Pow(lies[i] - mi, 2);
            }
            si /= lies.Count - 1;
            si = Sqrt(si);
            tp = Abs((yi - mi) / (si/(Sqrt(lies.Count))));
            tt = 2.31;
            lies.Add(yi);
            if (tp > tt) return 1;
            else return 0;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter f1 = new StreamWriter("daex.txt", false);
            for (int i = 0; i < inters.Count; i++)
            {
                for (int j = 0; j < inters[i].Count; j++)
                {
                    if (cringe(inters[i], inters[i][j]) == 1)
                    {
                        inters[i].Remove(inters[i][j]);
                    }
                }
            }
            foreach(var el in inters)
            {
                foreach(var el1 in el)
                {
                    f1.Write(el1 + "; ");
                }
                
                f1.WriteLine($"\nDispersion = {Round(disp(el).Item1, 3)} ");
                f1.Write($"MatExpect = {Round(disp(el).Item2, 3)} \n");
            }
            f1.Close();
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();   
        }

        private void chin(object sender, TextChangedEventArgs e)
        {
            kilksim.Text = polved.Text.Length.ToString();
            int posit = polved.Text.Length - 1;
            if (polved.Text.Length == 0) return;
            if (polved.Text[posit] == cod.Text[posit])
            {
                if (inter == 0)
                {
                    inters.Add(new List<double>());
                    inter = Convert.ToDouble(Convert.ToInt64(DateTime.Now.Ticks) / 10000) / 1000;
                }
                else
                {
                    inters[intc].Add(Round(Convert.ToDouble(Convert.ToInt64(DateTime.Now.Ticks) / 10000) / 1000 - inter, 4));
                }
                if (polved.Text == cod.Text)
                {
                    polved.IsEnabled = false;
                    inter = 0;
                }
            }
            else
            {
                polved.Text = polved.Text.Remove(posit);
            }
        }

        private void nextspr_Click(object sender, RoutedEventArgs e)
        {
            polved.Text = "";
            polved.IsEnabled = true;
            intc += 1;
            kspr -= 1;
            if (kspr == 1)
            {
                nextspr.IsEnabled = false;
            }
        }
    }
}
