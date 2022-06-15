using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;

namespace Tugas_Besar
{
    class Keuangan : Connection
    {
        public String tanggal_keuangan { set; get; }
        public String jenis_keuangan { set; get; }
        public int jumlah_uang { set; get; }
        public String awal { set; get; }
        public String akhir { set; get; }

        static MySqlConnection conn = Connection.conString();
        static MySqlCommand cmd;

        public Keuangan()
        {
            conn = Connection.conString();
            cmd = new MySqlCommand();
        }

        public string Insert()
        {
            String error = null;
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO keuangan (tanggal_keuangan, jenis_keuangan, jumlah_uang) " + 
                "VALUES (@tanggal_keuangan, @jenis_keuangan, @jumlah_uang)";
            cmd.Parameters.AddWithValue("@tanggal_keuangan", this.tanggal_keuangan);
            cmd.Parameters.AddWithValue("@jenis_keuangan", this.jenis_keuangan);
            cmd.Parameters.AddWithValue("@jumlah_uang", this.jumlah_uang);

            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return error;
        }

        public DataTable SelectKeuangan()
        {
            DataTable dt = new DataTable();
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT tanggal_keuangan, jenis_keuangan, SUM(jumlah_uang) FROM keuangan " + 
                "GROUP BY tanggal_keuangan, jenis_keuangan";
            {
                try
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    dt.Load(rdr);
                }
                catch
                {

                }
            }
            return dt;
        }

        public DataTable SelectCari()
        {
            DataTable dt = new DataTable();
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT tanggal_keuangan, jenis_keuangan, SUM(jumlah_uang) FROM keuangan " +
                "WHERE tanggal_keuangan BETWEEN '" + awal + "' AND '" + akhir + "'";
            {
                try
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    dt.Load(rdr);
                }
                catch
                {

                }
            }
            return dt;
        }
    }
}
