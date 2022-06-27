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
    /// Логика взаимодействия для AddTrack.xaml
    /// </summary>
    public partial class AddTrack : Window
    {
        public AddTrack()
        {
            InitializeComponent();
        }

        public string Group_Name;

        private void CorrectInp(object sender, TextChangedEventArgs e)
        {
            if (Title.Text.Length > 2 && Author.Text.Length > 2 && Producer.Text.Length > 2)
                AddBtn.IsEnabled = true;
            else 
                AddBtn.IsEnabled = false;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Sql.OpenConn();
            
            SqlCommand countSID = new SqlCommand("SELECT COUNT(Song_ID) FROM Songs", Sql.connection);
            SqlDataReader reader = countSID.ExecuteReader();
            reader.Read();
            int sID = Convert.ToInt32(reader.GetValue(0)) + 2;
            reader.Close();
            
            SqlCommand addSong = new SqlCommand($"INSERT INTO Songs VALUES({sID},'{Title.Text}','{Producer.Text}','{Author.Text}')", Sql.connection);
            addSong.ExecuteNonQuery();
            
            SqlCommand countGID = new SqlCommand($"SELECT * FROM Groupes WHERE Group_name = '{Group_Name}'", Sql.connection);
            SqlDataReader reader1 = countGID.ExecuteReader();
            reader1.Read();
            int gID = Convert.ToInt32(reader1.GetValue(0));
            reader1.Close();

            SqlCommand addGID_SID = new SqlCommand($"INSERT INTO Repertoire VALUES({gID},{sID})", Sql.connection);
            addGID_SID.ExecuteNonQuery();

            Sql.CloseConn();

            Info iw = new Info();
            iw.GetInfo(Group_Name);
            Close();
            iw.Show();
        }
    }
}
