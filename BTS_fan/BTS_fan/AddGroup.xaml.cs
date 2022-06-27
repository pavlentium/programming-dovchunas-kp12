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
    /// Логика взаимодействия для AddGroup.xaml
    /// </summary>
    public partial class AddGroup : Window
    {
        public AddGroup()
        {
            InitializeComponent();
        }

        private void CorrectInp(object sender, TextChangedEventArgs e)
        {
            if(Title.Text.Length > 2 && Country.Text.Length > 2)
            {
                try
                {
                    int year = Convert.ToInt32(Year.Text);
                    if (year > 1901 && year < 2077)
                    {
                        AddBtn.IsEnabled = true;
                        return;
                    }
                }
                catch { }
            }
            AddBtn.IsEnabled = false;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Sql.OpenConn();
            SqlCommand countID = new SqlCommand("SELECT COUNT(Group_ID) FROM Groupes", Sql.connection);
            SqlDataReader reader = countID.ExecuteReader();
            reader.Read();
            int ID = Convert.ToInt32(reader.GetValue(0));
            reader.Close();
            SqlCommand addGroup = new SqlCommand($"INSERT INTO Groupes VALUES({ID}, '{Title.Text}','{Country.Text}','{Year.Text}-01-01 00:00:00')", Sql.connection);
            addGroup.ExecuteNonQuery();
            Sql.CloseConn();
            Groups gw = new Groups();
            Close();
            gw.Show();
        }
    }
}
