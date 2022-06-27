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
    /// Логика взаимодействия для Groups.xaml
    /// </summary>
    public partial class Groups : Window
    {
        static private bool Kostul = false;
        public Groups()
        {
            InitializeComponent();
            Kostul = true;
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Close();
            mw.Show();
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            try
            {
                Sql.CloseConn();
                Sql.OpenConn();
                string Group_Name = (sender as TextBox).Text;
                SqlCommand command = new SqlCommand($"SELECT * FROM Groupes WHERE Group_name LIKE '%{Group_Name}%'", Sql.connection);
                SqlDataReader reader = command.ExecuteReader();
                int i = 0;
                if (Kostul)
                    GroupsGrid.Children.Clear();
                while (reader.Read())
                {
                    Label group = new Label
                    {
                        Content = reader.GetValue(1),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Height = 43,
                        Width = 741,
                        Margin = new Thickness(36, 90 + i * 52, 0, 0),
                        VerticalAlignment = VerticalAlignment.Top,
                        Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)),
                        FontSize = 26,
                    };
                    group.MouseLeftButtonDown += Group_Click;
                    i++;
                    GroupsGrid.Children.Add(group);
                }
                reader.Close(); Sql.CloseConn();
            }
            catch {/*буває.*/}
        }
        private void Group_Click(object sender, RoutedEventArgs e)
        {
            Info iw = new Info();
            iw.GetInfo((sender as Label).Content.ToString());
            Close();
            iw.Show();
        }

        private void newgroup_btn(object sender, RoutedEventArgs e)
        {
            AddGroup agw = new AddGroup();
            Close();
            agw.Show();
        }
    }
} 
