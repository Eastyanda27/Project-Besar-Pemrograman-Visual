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
    public partial class FormDataProduk : Form
    {
        public FormDataProduk()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAddProduk frmAdm = new FormAddProduk();
            frmAdm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboardAdm frmAdm = new FormDashboardAdm();
            frmAdm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataProfil frmAdm = new FormDataProfil();
            frmAdm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKeuanganHarian frmAdm = new FormKeuanganHarian();
            frmAdm.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataPegawai frmAdm = new FormDataPegawai();
            frmAdm.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLaporanHarian frmAdm = new FormLaporanHarian();
            frmAdm.Show();
        }

        private void loadDataProduk()
        {
            DataTable dt = new DataTable();
            dt = Produk.SelectFull();
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Show();
        }

        private void ChildFromClosing(object sender, FormClosingEventArgs e)
        {
            loadDataProduk();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Produk.Select(txtboxCariProduk.Text);
            dataGridView1.DataSource = dt;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Produk produk = new Produk();
            int selectdrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectdrowindex];
            produk.gambar = Convert.ToString(selectedRow.Cells["gambar"].Value);
            produk.no_produk = Convert.ToString(selectedRow.Cells["no_produk"].Value);
            produk.no_barcode = Convert.ToString(selectedRow.Cells["no_barcode"].Value);
            produk.nama_produk = Convert.ToString(selectedRow.Cells["nama_produk"].Value);
            produk.jenis_produk = Convert.ToString(selectedRow.Cells["jenis_produk"].Value);
            produk.harga_jual = Convert.ToInt32(selectedRow.Cells["harga_jual"].Value);
            produk.jumlah_produk = Convert.ToInt32(selectedRow.Cells["jumlah_produk"].Value);
            produk.jumlah_jual = Convert.ToInt32(selectedRow.Cells["jumlah_jual"].Value);

            if (Convert.ToBoolean(selectedRow.Cells["hapus"].Selected) == true)
            {
                if (produk.jumlah_jual == 0)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Yakin menghapus data barang " + produk.nama_produk + " ?", "Hapus Data Barang", buttons);
                    if (result == DialogResult.Yes)
                    {
                        string response;
                        response = produk.Delete();
                        if (response == null) MessageBox.Show("Sukses");
                        else MessageBox.Show(response);
                        loadDataProduk();
                    }
                    else
                    {

                    }

                }
                else
                {
                    MessageBox.Show("Tidak dapat menghapus barang karena barang sudah pernah terjual");
                }

            }
            else if (Convert.ToBoolean(selectedRow.Cells["edit"].Selected) == true)
            {
                FormEditProduk frmEditProduk = new FormEditProduk();
                frmEditProduk.FormClosing += new FormClosingEventHandler(ChildFromClosing);
                frmEditProduk.Show();
                this.Hide();
            }
        }

        private void FormDataProduk_Load(object sender, EventArgs e)
        {
            loadDataProduk();
        }
    }
}
