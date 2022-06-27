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

namespace prac2l
{
    public partial class MainWindow : Window
    {
        static int Radius = 30;
        static int PointCount = 5;
        static Polygon myPolygon = new Polygon();
        static List<Ellipse> EllipseArray = new List<Ellipse>();
        static List<Point> pC = new List<Point>();
        public MainWindow()
        {
            InitializeComponent();
            InitPoints();
            InitPolygon();
        }
        private void InitPoints()
        {
            Random rnd = new Random();
            pC.Clear();
            EllipseArray.Clear();

            for (int i = 0; i < PointCount; i++)
            {
                Point p = new Point();

                p.X = rnd.Next(Radius, (int)(0.75 * Windick.Width) - 3 * Radius);
                p.Y = rnd.Next(Radius, (int)(0.90 * Windick.Height - 3 * Radius));
                pC.Add(p);
            }

            for (int i = 0; i < PointCount; i++)
            {
                Ellipse el = new Ellipse();

                el.StrokeThickness = 2;
                el.Height = el.Width = Radius;
                el.Stroke = Brushes.AntiqueWhite;
                el.Fill = Brushes.IndianRed;
                EllipseArray.Add(el);
            }
        }
        private void InitPolygon()
        {
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon.StrokeThickness = 2;
        }
        private void PlotPoints()
        {
            for (int i = 0; i < PointCount; i++)
            {
                Canvas.SetLeft(EllipseArray[i], pC[i].X - Radius / 2);
                Canvas.SetTop(EllipseArray[i], pC[i].Y - Radius / 2);
                MyCanvas.Children.Add(EllipseArray[i]);
            }
        }
        private void PlotWay(List<Point> Points)
        {
            PointCollection pointC = new PointCollection();
            for (int i = 0; i < Points.Count; i++)
            {
                pointC.Add(Points[i]);
            }
            myPolygon.Points = pointC;
            MyCanvas.Children.Add(myPolygon);
        }

        private void StopStart_Click(object sender, RoutedEventArgs e)
        {
            MyCanvas.Children.Clear();
            PlotPoints();
            GreedMain();
            PlotWay(pC);
        }

        private void NumElemCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;

            PointCount = Convert.ToInt32(item.Content);
            InitPoints();
            InitPolygon();
        }

        private void OneStep(object sender, EventArgs e)
        {
            MyCanvas.Children.Clear();
            PlotPoints();
            GreedMain();
            PlotWay(pC);
        }
        private void GreedMain()
        {
            for (int k = 0; k < pC.Count - 1; k++)
            {
                Point closestP = pC[k + 1];
                Point firstP = pC[k];
                Point secondP = pC[k + 1];
                double lenght = CalcLenght(firstP, secondP);
                for (int i = k + 2; i < pC.Count; i++)
                {
                    secondP = pC[i];
                    if (lenght > CalcLenght(firstP, secondP))
                    {
                        lenght = CalcLenght(firstP, secondP);
                        closestP = pC[i];
                    }
                }
                Point temp = pC[k + 1];
                int index = pC.IndexOf(closestP);
                pC[k + 1] = closestP;
                pC[index] = temp;
            }
        }
        static double CalcLenght(Point p1, Point p2)
        {
            double lenght = Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2);
            lenght = Math.Sqrt(lenght);
            return lenght;
        }
    }
}
