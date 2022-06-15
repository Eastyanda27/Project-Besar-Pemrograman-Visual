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
    class Transaksi : Connection
    {
        public String gambar { set; get; }
        public String no_transaksi { set; get; }
        public String tanggal_transaksi { set; get; }
        public String no_produk { set; get; }
        public String no_barcode { set; get; }
        public String nama_produk { set; get; }
        public int kuantitas { set; get; }
        public int harga_jual { set; get; }
        public int harga_total { set; get; }
        public int jumlah_transaksi { set; get; }
        public String struk { set; get; }
        public int jumlah_produk { set; get; }
        public int kurang { set; get; }

        static MySqlConnection conn = Connection.conString();
        static MySqlCommand cmd;

        public Transaksi()
        {
            conn = Connection.conString();
            cmd = new MySqlCommand();
        }

        public string InsertTransaksi()
        {
            string result = null;
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO transaksi" + 
                "(no_transaksi,no_produk,no_barcode,nama_produk,kuantitas,harga_jual, " + 
                "harga_total) VALUES (@no_transaksi,@no_produk,@no_barcode,@nama_produk, " + 
                "@kuantitas,@harga_jual,@harga_total)", conn))
            {
                cmd.Parameters.AddWithValue("@no_transaksi", this.no_transaksi);
                cmd.Parameters.AddWithValue("@no_produk", this.no_produk);
                cmd.Parameters.AddWithValue("@no_barcode", this.no_barcode);
                cmd.Parameters.AddWithValue("@nama_produk", this.nama_produk);
                cmd.Parameters.AddWithValue("@kuantitas", this.kuantitas);
                cmd.Parameters.AddWithValue("@harga_jual", this.harga_jual);
                cmd.Parameters.AddWithValue("@harga_total", this.harga_total);
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

        public string Insert()
        {
            String error = null;
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO penjualan (no_transaksi, tanggal_transaksi, harga_total, " + 
                "jumlah_transaksi) VALUES (@no_transaksi, @tanggal_transaksi, @harga_total, " + 
                "@jumlah_transaksi)";
            cmd.Parameters.AddWithValue("@no_transaksi", this.no_transaksi);
            cmd.Parameters.AddWithValue("@tanggal_transaksi", this.tanggal_transaksi);
            cmd.Parameters.AddWithValue("@harga_total", this.harga_total);
            cmd.Parameters.AddWithValue("@jumlah_transaksi", this.jumlah_transaksi);

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

        public DataTable ReadStruk()
        {
            DataTable dt = new DataTable();
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT no_transaksi,no_produk,no_barcode,nama_produk,kuantitas, " + 
                "harga_jual,harga_total FROM transaksi WHERE no_transaksi = '" + struk + "'";
            cmd.Parameters.AddWithValue(struk, this.struk);
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

        public static DataTable SelectTransaksi(String no_transaksi)
        {
            conn = Connection.conString();
            DataTable dt = new DataTable();
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT no_transaksi,no_produk,no_barcode,nama_produk,kuantitas, " +
                "harga_jual,harga_total FROM transaksi WHERE no_transaksi = " + no_transaksi + "";
            cmd.Parameters.AddWithValue("@no_transaksi", no_transaksi);
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

        public static DataTable SelectJualan(String no_transaksi)
        {
            conn = Connection.conString();
            DataTable dt = new DataTable();
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT tanggal_transaksi,harga_total FROM penjualan WHERE no_transaksi = " + no_transaksi + "";
            cmd.Parameters.AddWithValue("@no_transaksi", no_transaksi);
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

        public string KuantitasTerjual()
        {
            String error = null;
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE produk set jumlah_jual = @jumlah_produk WHERE no_produk = '" + struk + "';";
            cmd.Parameters.AddWithValue("@jumlah_produk", this.jumlah_produk);
            cmd.Parameters.AddWithValue(struk, this.struk);
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch
                {

                }
            }
            return error;
        }

        public string KuantitasKurang()
        {
            String error = null;
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE produk set jumlah_produk = @jumlah_produk WHERE no_produk = '" + struk + "';";
            cmd.Parameters.AddWithValue("@kurang", this.kurang);
            cmd.Parameters.AddWithValue(struk, this.struk);
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch
                {

                }
            }
            return error;
        }
    }
}
