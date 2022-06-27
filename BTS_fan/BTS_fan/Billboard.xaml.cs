using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace BTS_fan
{
    /// <summary>
    /// Логика взаимодействия для Billboard.xaml
    /// </summary>
    public partial class Billboard : Window
    {
        public Billboard()
        {
            InitializeComponent();
        }
        public void change_billboard()
        {
            billboard.Children.Clear();
            string content = "";
            SqlConnection conn = Sql.connection;
            conn.Open();
            SqlCommand command = new SqlCommand($"SELECT * FROM Billboard", conn);
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i < 10; i++)
            {
                reader.Read();
                content = (i + 1).ToString() + ". ";
                content += reader.GetValue(1).ToString() + " - ";
                content += reader.GetValue(2).ToString();
                Label lb = new Label
                {
                    Content = content,
                    FontSize = 17,
                    Margin = new Thickness(0, i * 33, 0, 0),
                    Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)),
                    Height = 33, Width = 652,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                billboard.Children.Add(lb);
            }
            conn.Close();
        }

        private void Button_exit(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
    }
}
