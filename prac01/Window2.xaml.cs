using System;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            kspr = Convert.ToInt32(testtex.Text);
            StreamReader f1 = new StreamReader("daex.txt", false);
            while (!f1.EndOfStream)
            {
                string t = f1.ReadLine();
                if (t.Contains("Dispersion"))
                {
                    disperold.Add(Convert.ToDouble(t.Split(" ")[2]));
                }
                if (t.Contains("MatExpect"))
                {
                    matojold.Add(Convert.ToDouble(t.Split(" ")[2]));
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }
        public double inter = 0;
        public List<List<double>> inters = new List<List<double>>();
        public List<double> disperold = new List<double>();
        public List<double> matojold = new List<double>();
        public List<double> dispernew = new List<double>();
        public List<double> matojnew = new List<double>();
        public int intc = 0;
        public int[] re;
        
        public static int kspr;
        public string finddisper()
        {
            int pos = 0;
            foreach(var el in inters)
            {
                foreach(var old in disperold)
                {
                    double fp = Pow(Max(Round(disp(el).Item1, 3),old),2)/Pow(Min(Round(disp(el).Item1, 3), old), 2);
                    if (fp > 3.79) pos++;
                    else pos--;
                }
            }
            if (pos > 0) return ("неоднорідна");
            else return ("рівні");
        }
        public string pcoef()
        {
            re = new int[dispernew.Count];
            double n = cod.Text.Length;
            double[] p = new double[dispernew.Count];
            for (int i = 0; i < dispernew.Count; i++)
            {
                for (int j = 0; j < disperold.Count; j++)
                {
                    double dinew = dispernew[i], diold = disperold[j];
                    double majonew = matojnew[i], majoold = matojold[j];
                    double s = Sqrt(((Pow(dinew, 2) + Pow(diold, 2)) * (n - 1)) / (2 * n - 1));
                    double tp = Abs(majonew - majoold) / (s * Math.Sqrt(2 / n));
                    if (2.31 >= tp) re[i]++;
                }
                p[i] = re[i] / n;
            }
            return Round(sred(p), 3).ToString();
        }
        public double sred(double[] a)
        {
            double r = 0;
            for (int i = 0; i < a.Length; i++)
                r += a[i];
            r /= a.Length;
            return r;
        }
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
            tp = Abs((yi - mi) / (si / (Sqrt(lies.Count))));
            tt = 2.31;
            lies.Add(yi);
            if (tp > tt) return 1;
            else return 0;
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
                    if (kspr == 1) ms();

                }
            }
            else
            {
                polved.Text = polved.Text.Remove(posit);
            }
        }
        public string pom1()
        {
          
            double[] p = new double[3];
            for (int i = 0; i < p.Length; i++)
                p[i] = (3 - re[i]) /3.0;

            return Math.Round(sred(p), 8).ToString();
        }
        public string pom2()
        {
            double[] p = new double[3];
            for (int i = 0; i < p.Length; i++)
                p[i] = re[i] / 3.0;

            return Math.Round(sred(p), 8).ToString();
        }
        public void ms()
        {
            foreach(var li in inters)
            {
                dispernew.Add(disp(li).Item1);
                matojnew.Add(disp(li).Item2);

            }
            testlbl.Content = finddisper();
            testlbl2.Content = pcoef();
            testlbl3.Content = pom1();
            testlbl4.Content = pom2();
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
