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
    class Laporan
    {
        public DateTime tanggal_transaksi { set; get; }
        public int jumlah_transaksi { set; get; }
        public int harga_total { set; get; }
        public String no_produk { set; get; }
        public String nama_produk { set; get; }
        public String awal { set; get; }
        public String akhir { set; get; }

        static MySqlConnection conn = Connection.conString();
        static MySqlCommand cmd;

        public Laporan()
        {
            conn = Connection.conString();
            cmd = new MySqlCommand();
        }

        public DataTable SelectCari()
        {
            DataTable dt = new DataTable();
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT tanggal_transaksi, SUM(jumlah_transaksi), SUM(harga_total)" +
                " FROM penjualan WHERE tanggal_transaksi BETWEEN '"+ awal +"' AND '"+ akhir +"'";
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

        public DataTable SelectLaporan()
        {
            DataTable dt = new DataTable();
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT tanggal_transaksi, SUM(jumlah_transaksi), SUM(harga_total)" + 
                " FROM penjualan GROUP BY tanggal_transaksi";
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
