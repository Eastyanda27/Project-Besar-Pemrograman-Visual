using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;

namespace Tugas_Besar
{
    public class User
    {
        protected static String conString = "server = localhost; database = tugas_besar_visual; uid = root; sslMode = none; password =";
        static MySqlConnection conn;
        static MySqlCommand cmd;

        public String username { get; set; }
        public String password { get; set; }
        public String nama { get; set; }
        public String tanggal_lahir { get; set; }
        public String jenis_kelamin { get; set; }
        public String no_telepon { get; set; }
        public String hak_akses { get; set; }
        public String gambar { get; set; }


        public User()
        {
            conn = new MySqlConnection(conString);
            cmd = new MySqlCommand();
        }
        public bool validasi()
        {
            bool result = false;
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM user WHERE username=@username AND password=@password";
            cmd.Parameters.AddWithValue("@username", this.username);
            cmd.Parameters.AddWithValue("@password", this.password);
            try
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    //user = new User(Convert.ToInt16(rdr["id_user"]), rdr["username"].ToString(), rdr["password"].ToString(), Convert.ToInt16(rdr["id_pegawai"]), Convert.ToInt16(rdr["role"]));
                    username = rdr["username"].ToString();
                    hak_akses = rdr["hak_akses"].ToString();
                    result = true;
                }
            }
            catch (Exception e)
            {
                String error = e.Message;
            }
            conn.Close();
            return result;
        }

        public string insert()
        {
            string result = null;
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO user (username,password,nama," + 
                "tanggal_lahir,jenis_kelamin,no_telepon,hak_akses,gambar) VALUES (@username,@password," + 
                "@nama,@tanggal_lahir,@jenis_kelamin,@no_telepon,@hak_akses,@gambar)", conn))
            {
                cmd.Parameters.AddWithValue("@username", this.username);
                cmd.Parameters.AddWithValue("@password", this.password);
                cmd.Parameters.AddWithValue("@nama", this.nama);
                cmd.Parameters.AddWithValue("@tanggal_lahir", this.tanggal_lahir);
                cmd.Parameters.AddWithValue("@jenis_kelamin", this.jenis_kelamin);
                cmd.Parameters.AddWithValue("@no_telepon", this.no_telepon);
                cmd.Parameters.AddWithValue("@hak_akses", this.hak_akses);
                cmd.Parameters.AddWithValue("@gambar", this.gambar);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            return result;
        }

        public static DataTable SelectFull()
        {
            conn = new MySqlConnection(conString);
            DataTable dt = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE hak_akses = 'Pegawai'", conn))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    conn.Close();
                }
                catch (Exception e)
                {
                    String error = e.Message;
                }
            }
            return dt;
        }

        public static DataTable Select (String nama)
        {
            conn = new MySqlConnection(conString);
            DataTable dt = new DataTable();
            cmd = conn.CreateCommand();
            if (nama != "")
            {
                cmd.CommandText = "SELECT * FROM user WHERE hak_akses = 'Pegawai' AND nama LIKE '%" +
                    nama + "%'";
                cmd.Parameters.AddWithValue("@nama", nama);
            }
            else cmd.CommandText = "SELECT * FROM user WHERE hak_akses = 'Pegawai'";

            try
            {
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                String s = cmd.CommandText;
                dt.Load(rdr);
                conn.Close();
            }
            catch (Exception e)
            {
                String error = e.Message;
            }
            return dt;
        }

        public string Delete()
        {
            string result = null;
            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM user WHERE username = @username", conn))
            {
                cmd.Parameters.AddWithValue("@username", this.username);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            return result;
        }
    }
}
