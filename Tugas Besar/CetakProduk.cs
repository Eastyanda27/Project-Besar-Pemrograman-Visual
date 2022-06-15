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
    public partial class CetakProduk : Form
    {
        public CetakProduk()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DataTable produk = new DataTable();
            produk.Columns.Add("no_produk", typeof(String));
            produk.Columns.Add("no_barcode", typeof(String));
            produk.Columns.Add("nama_produk", typeof(String));
            produk.Columns.Add("jenis_produk", typeof(String));
            produk.Columns.Add("harga_jual", typeof(int));
            produk.Columns.Add("jumlah_produk", typeof(int));
            produk.Columns.Add("jumlah_jual", typeof(int));
            produk = Produk.SelectFull();

            CrProduk cr1 = new CrProduk();
            cr1.Database.Tables["produk"].SetDataSource(produk);
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = cr1;
        }
    }
}
