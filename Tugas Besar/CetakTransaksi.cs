using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tugas_Besar.ReportGenerator.CrystalReport;

namespace Tugas_Besar
{
    public partial class CetakTransaksi : Form
    {
        String no_transaksi;
        public CetakTransaksi(String no_transaksi)
        {
            InitializeComponent();
            this.no_transaksi = no_transaksi;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DataTable transaksi = new DataTable();
            transaksi.Columns.Add("no_transaksi", typeof(String));
            transaksi.Columns.Add("no_produk", typeof(String));
            transaksi.Columns.Add("no_barcode", typeof(String));
            transaksi.Columns.Add("nama_produk", typeof(String));
            transaksi.Columns.Add("harga_jual", typeof(int));
            transaksi.Columns.Add("kuantitas", typeof(int));
            transaksi.Columns.Add("harga_total", typeof(int));
            transaksi = Transaksi.SelectTransaksi(this.no_transaksi);

            DataTable jualan = new DataTable();
            transaksi.Columns.Add("tanggal_transaksi", typeof(DateTime));
            jualan.Columns.Add("harga_total", typeof(int));
            jualan = Transaksi.SelectJualan(this.no_transaksi);

            CrTransaksi cr1 = new CrTransaksi();
            cr1.Database.Tables["transaksi"].SetDataSource(transaksi);
            cr1.Database.Tables["penjualan"].SetDataSource(jualan);
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = cr1;
        }
    }
}
