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
    /// Логика взаимодействия для Tours.xaml
    /// </summary>
    public partial class Tours : Window
    {
        public Tours()
        {
            InitializeComponent();
        }

        public string Group_Name;

        public void GetInfo(string str)
        {
            this.Group_Name = str;
            int place = 0;
            Sql.OpenConn();
            SqlCommand getTitle = new SqlCommand($"SELECT dbo.Groupes.Group_name, dbo.Tours.Title, dbo.Tours.Date_of_begin, " +
                $"dbo.Tours.Date_of_end, dbo.Last_Tour.Tour_ID FROM dbo.Groupes INNER JOIN dbo.Last_Tour ON dbo.Groupes.Group_ID = dbo.Last_Tour.Group_ID " +
                $"INNER JOIN dbo.Tours ON dbo.Last_Tour.Tour_ID = dbo.Tours.Tour_ID WHERE dbo.Groupes.Group_name = '{Group_Name}'", Sql.connection);
            SqlDataReader reader = getTitle.ExecuteReader();
            reader.Read();
            tName.Content = reader.GetValue(1).ToString();
            start.Content = reader.GetValue(2).ToString();
            end.Content = reader.GetValue(3).ToString();
            int tID = Convert.ToInt32(reader.GetValue(4));
            reader.Close();
            SqlCommand takeInfo = new SqlCommand($"SELECT * FROM Billboard WHERE Group_Name = '{Group_Name}'", Sql.connection);
            SqlDataReader reader1 = takeInfo.ExecuteReader();
            while (reader1.Read()) place = Convert.ToInt32(reader1.GetValue(0));
            reader1.Close();
            SqlCommand takeSityID = new SqlCommand($"SELECT dbo.Tour_City.City_ID, dbo.Cities.Name FROM dbo.Tour_City INNER JOIN dbo.Cities ON dbo.Tour_City.City_ID = dbo.Cities.City_ID WHERE dbo.Tour_City.Tour_ID = {tID}", Sql.connection);
            List<string> cities = new List<string>();
            int counter = 0, sityCost = 0;
            SqlDataReader reader2 = takeSityID.ExecuteReader();
            while (reader2.Read())
            {
                counter++;
                sityCost += Convert.ToInt32(reader2.GetValue(0));
                cities.Add(reader2.GetValue(1).ToString());
            }
            reader2.Close();
            sityCost /= counter;
            long cost = 800 - place * sityCost * 4;
            avCost.Content = cost;
            long amountOfTickets = (11-place) * tID * 12000 * sityCost;
            amountOfT.Content = amountOfTickets;
            receipts.Content = amountOfTickets * cost;
            Cities_Label.Text = "";
            foreach(string sity in cities)
            {
                Cities_Label.Text += sity + ", ";
            }
            Cities_Label.Text = Cities_Label.Text.Remove(Cities_Label.Text.Length - 2, 2);
            Sql.CloseConn();
        }

        private void Exit_Btn(object sender, RoutedEventArgs e)
        {
            Info iw = new Info();
            iw.GetInfo(Group_Name);
            Close();
            iw.Show();
        }
    }
}
