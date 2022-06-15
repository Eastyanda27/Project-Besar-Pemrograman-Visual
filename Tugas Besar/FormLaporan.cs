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
    public partial class FormLaporan : Form
    {
        User user;
        public FormLaporan(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void FormLaporan_Load(object sender, EventArgs e)
        {
            loadDataLaporan();
        }

        private void loadDataLaporan()
        {
            Laporan laporan = new Laporan();
            DataTable dt = new DataTable();
            dt = laporan.SelectLaporan();
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Laporan laporan = new Laporan();
            DataTable dt = new DataTable();
            laporan.awal = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            laporan.akhir = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            dt = laporan.SelectCari();
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Laporan laporan = new Laporan();
            int selectdrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectdrowindex];
            laporan.tanggal_transaksi = Convert.ToDateTime(selectedRow.Cells["tanggal_transaksi"].Value);
            laporan.jumlah_transaksi = Convert.ToInt32(selectedRow.Cells["jumlah_transaksi"].Value);
            laporan.harga_total = Convert.ToInt32(selectedRow.Cells["harga_total"].Value);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataProfil frmAdm = new FormDataProfil(user);
            frmAdm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataProduk frmAdm = new FormDataProduk(user);
            frmAdm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKeuangan frmAdm = new FormKeuangan(user);
            frmAdm.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataPegawai frmAdm = new FormDataPegawai(user);
            frmAdm.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTransaksi frmAdm = new FormTransaksi(user);
            frmAdm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboardAdm frmAdm = new FormDashboardAdm(user);
            frmAdm.Show();
        }
    }
}
