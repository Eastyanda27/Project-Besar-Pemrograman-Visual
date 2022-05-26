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
    public partial class FormAddProduk : Form
    {
        public FormAddProduk()
        {
            InitializeComponent();
            textBox7.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string picture = open.FileName.ToString();
                lblFileName.Text = picture;
                pictureBox7.ImageLocation = picture;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] imgbt = null;
            FileStream fstream = new FileStream(this.lblFileName.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imgbt = br.ReadBytes((int)fstream.Length);

            Produk produk = new Produk();
            produk.no_produk = textBox2.Text;
            produk.no_barcode = textBox5.Text;
            produk.nama_produk = textBox1.Text;
            produk.jenis_produk = textBox4.Text;
            produk.harga_jual = Convert.ToInt32(textBox3.Text);
            produk.jumlah_produk = Convert.ToInt32(textBox6.Text);
            produk.jumlah_jual = Convert.ToInt32(textBox7.Text);


            String response = produk.Insert();
            if (response == null)
            {
                MessageBox.Show("Tambah Produk Berhasil");
                this.Hide();
                FormDataProduk frmAdm = new FormDataProduk();
                frmAdm.Show();
            }
            else
            {
                MessageBox.Show("Tambah Produk Gagal. Error " + response);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataProduk frmAdm = new FormDataProduk();
            frmAdm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataProfil frmAdm = new FormDataProfil();
            frmAdm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKeuanganHarian frmAdm = new FormKeuanganHarian();
            frmAdm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataPegawai frmAdm = new FormDataPegawai();
            frmAdm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLaporanHarian frmAdm = new FormLaporanHarian();
            frmAdm.Show();
        }

        private void FormAddProduk_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var isi = "1234567890";
            var random = new char[4];
            var acak = new Random();

            for (int i = 0; i < random.Length; i++)
            {
                random[i] = isi[acak.Next(isi.Length)];
            }

            textBox2.Text = new string(random);
        }
    }
}
