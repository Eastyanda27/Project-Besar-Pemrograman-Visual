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
    public partial class FormTransaksiPegawai : Form
    {
        User user;
        int harga;
        int kuantitas = 0;
        int tot;
        int total = 0;

        int qty_awal;
        int qty_jual;
        int qty_akhir;

        int jml_awal;
        int jml_jual;
        int jml_akhir;

        public FormTransaksiPegawai(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void FormTransaksiPegawai_Load(object sender, EventArgs e)
        {
            loadDataProduk();
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox8.Enabled = false;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "foto")
            {
                string s = dataGridView1.Rows[e.RowIndex].Cells["gambar"].Value.ToString();
                if (s != "") e.Value = Image.FromFile(s);
                else e.Value = null;
            }
        }

        private void loadDataProduk()
        {
            Produk produk = new Produk();
            DataTable dt = new DataTable();
            dt = Produk.SelectFull();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["gambar"].Visible = false;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Show();
        }

        private void ReadData()
        {
            Transaksi tabelStruk = new Transaksi();
            DataTable dt = new DataTable();
            tabelStruk.struk = textBox2.Text;
            dt = tabelStruk.ReadStruk();
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = dt;
            dataGridView2.ColumnHeadersVisible = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataProfilPegawai frmAdm = new FormDataProfilPegawai(user);
            frmAdm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboardPegawai frmAdm = new FormDashboardPegawai(user);
            frmAdm.Show();
        }

        private void Kurang()
        {
            MySqlConnection conn = Connection.conString();
            MySqlCommand cmd = new MySqlCommand("SELECT jumlah_produk FROM produk WHERE no_produk = '" + textBox5.Text + "';", conn);
            MySqlDataReader rdr;
            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string qty = rdr.GetInt32(0).ToString();
                    qty_awal = Convert.ToInt32(qty);
                }
            }
            catch
            {

            }

            qty_jual = Convert.ToInt32(textBox3.Text);
            qty_akhir = qty_awal - qty_jual;
        }

        private void Tambah()
        {
            MySqlConnection conn = Connection.conString();
            MySqlCommand cmd = new MySqlCommand("SELECT jumlah_jual FROM produk WHERE no_produk = '" + textBox5.Text + "'; ", conn);
            MySqlDataReader rdr;
            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string qty = rdr.GetInt32(0).ToString();
                    jml_awal = Convert.ToInt32(qty);
                }
            }
            catch
            {

            }

            jml_jual = Convert.ToInt32(textBox3.Text);
            jml_akhir = jml_awal + jml_jual;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            harga = Convert.ToInt32(textBox8.Text);

            if (textBox3.Text == "")
            {
                kuantitas = 0;
            }
            else
            {
                kuantitas = Convert.ToInt32(textBox3.Text);
            }

            tot = kuantitas * harga;
            textBox6.Text = tot.ToString();
            total = total + tot;
            textBox10.Text = total.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var isi = "1234567890";
            var random = new char[13];
            var acak = new Random();

            for (int i = 0; i < random.Length; i++)
            {
                random[i] = isi[acak.Next(isi.Length)];
            }

            textBox2.Text = new string(random);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Produk transaksi = new Produk();
            DataTable dt = new DataTable();
            dt = transaksi.SelectForTrans(textBox9.Text);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["gambar"].Visible = false;
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
            produk.jumlah_jual = Convert.ToInt32(selectedRow.Cells["jumlah_jual"].Value);

            if (Convert.ToBoolean(selectedRow.Cells["tambah_data"].Selected) == true)
            {
                textBox5.Text = produk.no_produk;
                textBox1.Text = produk.no_barcode;
                textBox4.Text = produk.nama_produk;
                textBox8.Text = Convert.ToString(produk.harga_jual);
                textBox1.Enabled = false;
                textBox4.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Kurang();
            Tambah();

            Transaksi inputtransaksi = new Transaksi();
            inputtransaksi.no_transaksi = textBox2.Text;
            inputtransaksi.no_produk = textBox5.Text;
            inputtransaksi.no_barcode = textBox1.Text;
            inputtransaksi.nama_produk = textBox4.Text;
            inputtransaksi.harga_jual = Convert.ToInt32(textBox8.Text);
            inputtransaksi.kuantitas = Convert.ToInt32(textBox3.Text);
            inputtransaksi.harga_total = Convert.ToInt32(textBox6.Text);

            String response = inputtransaksi.InsertTransaksi();
            if (response == null)
            {
                ReadData();
            }
            else
            {
                MessageBox.Show("Tambah Transaksi Gagal. Error " + response);
            }

            string responses;
            Transaksi inputKuantitas = new Transaksi();
            inputKuantitas.struk = textBox5.Text;
            inputKuantitas.jumlah_produk = Convert.ToInt32(jml_akhir);
            responses = inputKuantitas.KuantitasTerjual();

            if (responses == null)
            {

            }
            else MessageBox.Show(responses);

            string respon;
            Transaksi inputKurang = new Transaksi();
            inputKurang.kurang = Convert.ToInt32(qty_akhir);
            inputKurang.struk = textBox5.Text;
            respon = inputKurang.KuantitasKurang();
            if (respon == null)
            {

            }
            else MessageBox.Show(respon);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string response;
            string responsee;
            User user = new User();
            Keuangan inputkeuangan = new Keuangan();
            Transaksi inputtransaksi = new Transaksi();
            inputtransaksi.no_transaksi = textBox2.Text;
            inputtransaksi.tanggal_transaksi = dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss");
            inputtransaksi.harga_total = Convert.ToInt32(textBox10.Text);
            inputtransaksi.jumlah_transaksi = Convert.ToInt32(textBox7.Text);
            inputkeuangan.tanggal_keuangan = dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss");
            inputkeuangan.jumlah_uang = Convert.ToInt32(textBox10.Text);
            inputkeuangan.jenis_keuangan = "Pemasukan";
            response = inputtransaksi.Insert();
            responsee = inputkeuangan.Insert();
            if (response == null)
            {
                textBox5.Text = null;
                textBox1.Text = null;
                textBox4.Text = null;
                textBox3.Text = null;
                textBox6.Text = null;
                textBox7.Text = null;
            }
            else MessageBox.Show(response);

            if (responsee == null)
            {
                textBox5.Text = null;
                textBox1.Text = null;
                textBox4.Text = null;
                textBox3.Text = null;
                textBox6.Text = null;
                textBox7.Text = null;

                MessageBox.Show("Input Transaksi Berhasil");
            }
            else MessageBox.Show(responsee);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CetakTransaksi frmAdm = new CetakTransaksi(textBox2.Text);
            frmAdm.Show();
        }
    }
}
