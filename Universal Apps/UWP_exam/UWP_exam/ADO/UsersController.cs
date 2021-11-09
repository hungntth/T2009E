using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using UWP_exam.Model;

namespace UWP_exam.ADO
{
    class UsersController
    {
        MySqlConnection conn;

        public UsersController()
        {
            string sql = "server=localhost;user=aacc;database=UWP_excam;port=3306;password=";
            conn = new MySqlConnection(sql);
        }

        public bool Login(string user, string pass)
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            string loginUser = String.Format("SELECT COUNT(*) FROM user WHERE password = '{0}' AND username = '{1}'",
                user, pass);

            MySqlCommand countCommand = new MySqlCommand(loginUser, conn);





            int i = (int)(long)countCommand.ExecuteScalar();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
