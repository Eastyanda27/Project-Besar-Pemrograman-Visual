using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas_Besar
{
    public partial class FormKeuangan : Form
    {
        User user;
        public FormKeuangan(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Keuangan keuangan = new Keuangan();
            int selectdrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectdrowindex];
            keuangan.tanggal_keuangan = Convert.ToString(selectedRow.Cells["tanggal_keuangan"].Value);
            keuangan.jenis_keuangan = Convert.ToString(selectedRow.Cells["jenis_keuangan"].Value);
            keuangan.jumlah_uang = Convert.ToInt32(selectedRow.Cells["jumlah_uang"].Value);
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

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLaporan frmAdm = new FormLaporan(user);
            frmAdm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboardAdm frmAdm = new FormDashboardAdm(user);
            frmAdm.Show();
        }

        private void FormKeuangan_Load(object sender, EventArgs e)
        {
            loadDataKeuangan();
        }

        private void loadDataKeuangan()
        {
            Keuangan keuangan = new Keuangan();
            DataTable dt = new DataTable();
            dt = keuangan.SelectKeuangan();
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Keuangan keuangan = new Keuangan();
            DataTable dt = new DataTable();
            keuangan.awal = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            keuangan.akhir = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            dt = keuangan.SelectCari();
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAddKeuangan frmAdm = new FormAddKeuangan(user);
            frmAdm.Show();
        }
    }
}
