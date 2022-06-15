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
    class Produk : Connection
    {
        static MySqlConnection conn = Connection.conString();
        static MySqlCommand cmd;

        public String no_produk { get; set; }
        public String no_barcode { get; set; }
        public String nama_produk { get; set; }
        public String jenis_produk { get; set; }
        public int harga_jual { get; set; }
        public int jumlah_produk { get; set; }
        public int jumlah_jual { get; set; }
        public String gambar { get; set; }

        public Produk()
        {
            conn = Connection.conString();
            cmd = new MySqlCommand();
        }

        public string Insert()
        {
            string result = null;
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO produk (no_produk,no_barcode," +
                "nama_produk,jenis_produk,harga_jual,jumlah_produk,jumlah_jual,gambar) " + "VALUES" +
                "(@no_produk,@no_barcode,@nama_produk,@jenis_produk,@harga_jual,@jumlah_produk," + 
                "@jumlah_jual,@gambar)", conn))
            {
                cmd.Parameters.AddWithValue("@no_produk", this.no_produk);
                cmd.Parameters.AddWithValue("@no_barcode", this.no_barcode);
                cmd.Parameters.AddWithValue("@nama_produk", this.nama_produk);
                cmd.Parameters.AddWithValue("@jenis_produk", this.jenis_produk);
                cmd.Parameters.AddWithValue("@harga_jual", this.harga_jual);
                cmd.Parameters.AddWithValue("@jumlah_produk", this.jumlah_produk);
                cmd.Parameters.AddWithValue("@jumlah_jual", this.jumlah_jual);
                cmd.Parameters.AddWithValue("@gambar", this.gambar);
                try
                {
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
            conn = Connection.conString();
            DataTable dt = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM produk", conn))
            {
                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    dt.Load(rdr);
                }
                catch (Exception e)
                {
                    String error = e.Message;
                }
            }
            return dt;
        }

        public static DataTable Select(String nama_produk)
        {
            DataTable dt = new DataTable();
            cmd = conn.CreateCommand();
            if (nama_produk != "")
            {
                cmd.CommandText = "SELECT * FROM produk WHERE nama_produk LIKE '%" + nama_produk + "%'" + "OR no_barcode LIKE '%" + nama_produk + "%'";
                cmd.Parameters.AddWithValue("@nama_produk", nama_produk);
            }
            else cmd.CommandText = "SELECT * FROM produk";

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
            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM produk WHERE no_produk=@no_produk", conn))
            {
                cmd.Parameters.AddWithValue("@no_produk", this.no_produk);
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

        public string update()
        {
            string result = null;
            using (MySqlCommand cmd = new MySqlCommand("UPDATE produk SET no_produk=@no_produk," +
                "no_barcode=@no_barcode,nama_produk=@nama_produk,jenis_produk=@jenis_produk," + 
                "harga_jual=@harga_jual,jumlah_produk=@jumlah_produk,gambar = @gambar WHERE " + 
                "nama_produk=@nama_produk", conn))
            {
                cmd.Parameters.AddWithValue("@no_produk", this.no_produk);
                cmd.Parameters.AddWithValue("@no_barcode", this.no_barcode);
                cmd.Parameters.AddWithValue("@nama_produk", this.nama_produk);
                cmd.Parameters.AddWithValue("@jenis_produk", this.jenis_produk);
                cmd.Parameters.AddWithValue("@harga_jual", this.harga_jual);
                cmd.Parameters.AddWithValue("@jumlah_produk", this.jumlah_produk);
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

        public DataTable SelectForTrans(String pencarian)
        {
            DataTable dt = new DataTable();
            cmd = conn.CreateCommand();
            if (nama_produk != "")
            {
                cmd.CommandText = "SELECT * FROM produk WHERE no_barcode LIKE '%" + pencarian +
                    "%' OR nama_produk LIKE '%" + pencarian + "%'";
                cmd.Parameters.AddWithValue("@no_barcode", pencarian);
            }
            else cmd.CommandText = "SELECT * FROM produk";

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
    }
}
