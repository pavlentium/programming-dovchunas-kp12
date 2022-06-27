using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS_fan
{
    static class Sql
    {
        private static string strConnection = "Data Source=DESKTOP-M860KU2;Initial Catalog=BTS_Fan;Integrated Security=True";
        static public SqlConnection connection = new SqlConnection(strConnection);
        static public void SetConn(string conn)
        {
            connection = new SqlConnection(conn);
        }
        static public void OpenConn()
        {
            connection.Open();
        }
        static public void CloseConn()
        {
            connection.Close();
        }
    }
}
