using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

namespace BTS_fan
{
    /// <summary>
    /// Логика взаимодействия для ChangeArtist.xaml
    /// </summary>
    public partial class ChangeArtist : Window
    {
        public ChangeArtist()
        {
            InitializeComponent();
        }
        public string GroupName;
        public bool IsAdd;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = false;
            if (IsAdd)
            {
                try
                {
                    Sql.OpenConn();
                    SqlCommand countID = new SqlCommand("SELECT COUNT(Artist_ID) FROM Artists", Sql.connection);
                    SqlDataReader reader = countID.ExecuteReader();
                    reader.Read();
                    int ID = Convert.ToInt32(reader.GetValue(0));
                    reader.Close();
                    string name = ArName.Text.Split('-')[0];
                    string age = ArName.Text.Split('-')[1];
                    string ampl = ArName.Text.Split('-')[2];
                    SqlCommand addArtist = new SqlCommand($"INSERT INTO Artists VALUES({ID},'{name}',{age},'{ampl}')", Sql.connection);
                    addArtist.ExecuteNonQuery();
                    SqlCommand getIDGroup = new SqlCommand($"SELECT * FROM Groupes WHERE Group_name = '{GroupName}'", Sql.connection);
                    SqlDataReader reader1 = getIDGroup.ExecuteReader();
                    reader1.Read();
                    int GrID = Convert.ToInt32(reader1.GetValue(0));
                    reader1.Close();
                    SqlCommand addGrID_arID = new SqlCommand($"INSERT INTO Group_Artists VALUES({ID},{GrID})", Sql.connection);
                    addGrID_arID.ExecuteNonQuery();
                    Sql.CloseConn();
                }
                catch
                {
                    Fail(btn);
                    return;
                }
            }
            else
            {
                try
                {
                    Sql.OpenConn();
                    SqlCommand delete = new SqlCommand($"DELETE FROM Artists WHERE Artist_Name = '{ArName.Text}'", Sql.connection);
                    delete.ExecuteNonQuery();
                    Sql.CloseConn();
                }
                catch
                {
                    Fail(btn);
                    return;
                }
            }

            for (int i = 5; i >= 0; i--)
            {
                Result.Content = $"Успішно!({i})"; 
                DoEvents();
                Thread.Sleep(400);
            }
            Info iw = new Info();
            iw.GetInfo(GroupName);
            Close();
            iw.Show();
        }
        void Fail(Button btn)
        {
            for (int i = 5; i >= 0; i--)
            {
                Result.Content = $"Щось пішло не так\nповторіть через ({i})";
                DoEvents();
                Thread.Sleep(400);
            }
            Sql.CloseConn();
            ChangeArtist caw = new ChangeArtist();
            caw.GroupName = this.GroupName;
            caw.IsAdd = this.IsAdd;
            if(IsAdd) caw.MainLB.Content = "Введіть ім'я-вік-амплуа";
            Close();
            caw.Show();
        }
        void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame(true);
            Dispatcher.CurrentDispatcher.BeginInvoke
            (
            DispatcherPriority.Background,
            (SendOrPostCallback)delegate (object arg)
            {
                var f = arg as DispatcherFrame;
                f.Continue = false;
            },
            frame
            );
            Dispatcher.PushFrame(frame);
        }
    }
}
