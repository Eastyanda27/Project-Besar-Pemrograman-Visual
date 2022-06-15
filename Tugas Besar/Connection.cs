using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;

namespace Tugas_Besar
{
    public class Connection
    {
        public static MySqlConnection conString()
        {
            MySqlConnection Conn = null;
            try
            {
                string ConnString = "server=localhost; database=tugas_besar_visual; uid=root; password=;";
                Conn = new MySqlConnection(ConnString);
            }
            catch (MySqlException sqlex)
            {
                throw new Exception(sqlex.Message.ToString());
            }
            return Conn;
        }
    }
}
