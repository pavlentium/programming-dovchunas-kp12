using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls;
using System;

namespace BTS_fan
{
    /// <summary>
    /// Логика взаимодействия для Info.xaml
    /// </summary
    public partial class Info : Window
    {
        public Info()
        {
            InitializeComponent();
        }
        private string Group_Name;
        public void GetInfo(string str)
        {
            this.Group_Name = str;
            Sql.OpenConn();
            SqlCommand takeInfo = new SqlCommand($"SELECT * FROM Groupes WHERE (Group_name = '{Group_Name}')", Sql.connection);
            SqlDataReader reader = takeInfo.ExecuteReader();
            reader.Read();
            int gID = Convert.ToInt32(reader.GetValue(0));
            if (gID > 9) TourBtn.IsEnabled = false;
            gName.Content = Group_Name;
            country.Content = reader.GetString(2);
            year.Content = reader.GetValue(3).ToString().Split('.')[2];
            reader.Close();
            SqlCommand takeChels = new SqlCommand($"SELECT dbo.Group_Artists.Artist_ID, dbo.Artists.Artist_Name, dbo.Artists.Role, dbo.Artists.Age, " +
                $"dbo.Groupes.Group_name FROM dbo.Groupes INNER JOIN dbo.Group_Artists ON dbo.Groupes.Group_ID = dbo.Group_Artists.Group_ID INNER " +
                $"JOIN dbo.Artists ON dbo.Group_Artists.Artist_ID = dbo.Artists.Artist_ID WHERE dbo.Groupes.Group_name = '{Group_Name}'", Sql.connection);
            SqlDataReader reader1 = takeChels.ExecuteReader();
            chels.Content = "";
            while (reader1.Read())
            {
                chels.Content += $"{reader1.GetValue(1)} - {reader1.GetValue(2)}, вік: {reader1.GetValue(3)} (ID: {reader1.GetValue(0)})\n";
            }
            reader1.Close();
            SqlCommand takeMusic = new SqlCommand($"SELECT dbo.Groupes.Group_name, dbo.Repertoire.Group_ID, dbo.Repertoire.Song_ID, dbo.Songs.Title," +
                $" dbo.Songs.Producer, dbo.Songs.Author FROM dbo.Groupes INNER JOIN dbo.Repertoire ON dbo.Groupes.Group_ID = dbo.Repertoire.Group_ID" +
                $" INNER JOIN dbo.Songs ON dbo.Repertoire.Song_ID = dbo.Songs.Song_ID WHERE dbo.Groupes.Group_name = '{Group_Name}'", Sql.connection);
            SqlDataReader reader2 = takeMusic.ExecuteReader();
            tracks.Content = producers.Content = authors.Content = "";
            while (reader2.Read())
            {
                tracks.Content += reader2.GetValue(3) + "\n";
                producers.Content += reader2.GetValue(4) + "\n";
                authors.Content += reader2.GetValue(5) + "\n";
            }
            reader2.Close();
            SqlCommand getPlace = new SqlCommand($"SELECT * FROM Billboard WHERE Group_Name = '{Group_Name}'", Sql.connection);
            SqlDataReader reader3 = getPlace.ExecuteReader();
            while (reader3.Read()) place.Content = reader3.GetValue(0);
            reader3.Close();
            Sql.CloseConn();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Groups gw = new Groups();
            Close();
            gw.Show();
        }

        private void Grid_Change(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if(btn.Content.ToString() == "Пісні")
            {
                btn.Content = "Інфо";
                Music.Visibility = Visibility.Visible;
                GroupInf.Visibility = Visibility.Hidden;
                gName.Visibility = Visibility.Hidden;
                gMusic.Visibility = Visibility.Visible;
                TourBtn.Visibility = Visibility.Hidden;
                AddTrack_Btn.Visibility = Visibility.Visible;
            }
            else
            {
                btn.Content = "Пісні";
                Music.Visibility = Visibility.Hidden;
                GroupInf.Visibility = Visibility.Visible;
                gName.Visibility = Visibility.Visible;
                gMusic.Visibility = Visibility.Hidden;
                TourBtn.Visibility = Visibility.Visible;
                AddTrack_Btn.Visibility = Visibility.Hidden;
            }
        }

        private void Add_Artist(object sender, RoutedEventArgs e)
        {
            ChangeArtist caw = new ChangeArtist();
            caw.GroupName = Group_Name;
            caw.IsAdd = true;
            caw.MainLB.Content = "Введіть ім'я-вік-амплуа";
            Close();
            caw.Show();
        }
        private void Remove_Artist(object sender, RoutedEventArgs e)
        {
            ChangeArtist caw = new ChangeArtist();
            caw.GroupName = Group_Name;
            caw.IsAdd = false;
            Close();
            caw.Show();
        }

        private void Tour_Click(object sender, RoutedEventArgs e)
        {
            Tours tw = new Tours();
            tw.GetInfo(Group_Name);
            Close();
            tw.Show();
        }

        private void AddTrack_Click(object sender, RoutedEventArgs e)
        {
            AddTrack atw = new AddTrack();
            atw.Group_Name = Group_Name;
            Close();
            atw.Show();
        }
    }
}
