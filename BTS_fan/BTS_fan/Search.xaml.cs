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
    /// Логика взаимодействия для Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
        }



        private void serage_btn(object sender, RoutedEventArgs e)
        {
            diapgr.Visibility = Visibility.Visible;
            annigri.Visibility = Visibility.Hidden;
            youngestgr.Visibility = Visibility.Hidden;

        }

        private void young_btn(object sender, RoutedEventArgs e)
        {
            diapgr.Visibility = Visibility.Hidden;
            annigri.Visibility = Visibility.Hidden;
            youngestgr.Visibility = Visibility.Visible;
            SqlConnection conn = Sql.connection;
            conn.Open();
            SqlCommand command = new SqlCommand($"SELECT * FROM Artists ORDER BY Age", conn);
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i < 8; i++)
            {
                reader.Read();
                yoage.Content+=reader.GetValue(2).ToString() + "         ";
                yoage.Content+=reader.GetValue(1).ToString() + "\n";
                
            }
            reader.Close();
            conn.Close();
        }

        private void anni_btn(object sender, RoutedEventArgs e)
        {
            diapgr.Visibility = Visibility.Hidden;
            annigri.Visibility = Visibility.Visible;
            youngestgr.Visibility = Visibility.Hidden;
            SqlConnection conn = Sql.connection;
            conn.Open(); 
            SqlCommand command = new SqlCommand($"SELECT * FROM Groupes WHERE (( {DateTime.Now.Year} - DatePart(YEAR,Founding_date)) % 10 = 0)", conn);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                dateani.Content += reader.GetValue(3).ToString().Split('.')[2].Split(' ')[0] + "        ";
                dateani.Content += reader.GetValue(1).ToString() + "\n";
                
            }
            reader.Close();
            conn.Close();
        }       
        
        private void Button_exit(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Close();
            mw.Show();
        }

        private void proceed_btn(object sender, RoutedEventArgs e)
        {
            serage.Content = "";
            SqlConnection conn = Sql.connection;
            conn.Open();
            SqlCommand countID = new SqlCommand("SELECT COUNT(Group_ID) FROM Groupes", Sql.connection);
            SqlDataReader reader = countID.ExecuteReader();
            reader.Read();
            int ID = Convert.ToInt32(reader.GetValue(0));
            reader.Close();
            for (int i = 0; i < ID - 2; i++)
            {
                SqlCommand command = new SqlCommand($"SELECT dbo.Artists.Age, dbo.Groupes.Group_ID, dbo.Groupes.Group_name FROM dbo.Artists " +
                    $"INNER JOIN dbo.Group_Artists ON dbo.Artists.Artist_ID = dbo.Group_Artists.Artist_ID INNER JOIN dbo.Groupes " +
                    $"ON dbo.Group_Artists.Group_ID = dbo.Groupes.Group_ID WHERE dbo.Groupes.Group_ID = {i}", conn);
                SqlDataReader reader2 = command.ExecuteReader();
                List<int> temp = new List<int>();
                string groupname = "";
                while (reader2.Read()) 
                { 
                    temp.Add(Convert.ToInt32(reader2.GetValue(0)));
                    groupname = reader2.GetValue(2).ToString();
                }
                int avg = 0;
                foreach (int age in temp) avg += age;
                avg /= temp.Count;
                if (avg >= Convert.ToInt32(low.Text) & avg <= Convert.ToInt32(high.Text))
                {
                    serage.Content += avg.ToString() + "         " + groupname + "\n";
                }
                reader2.Close();

            }
            
            conn.Close();
        }
    }
}
