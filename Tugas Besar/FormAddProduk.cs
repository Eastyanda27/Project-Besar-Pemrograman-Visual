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
        User user;
        public FormAddProduk(User user)
        {
            InitializeComponent();
            textBox7.Text = "0";
            this.user = user;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                lblFileName.Text = open.FileName;
                pictureBox7.Image = new Bitmap (open.FileName);
                pictureBox7.ImageLocation = open.FileName;
                pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Produk produk = new Produk();
            produk.no_produk = textBox2.Text;
            produk.no_barcode = textBox5.Text;
            produk.nama_produk = textBox1.Text;
            produk.jenis_produk = textBox4.Text;
            produk.harga_jual = Convert.ToInt32(textBox3.Text);
            produk.jumlah_produk = Convert.ToInt32(textBox6.Text);
            produk.jumlah_jual = Convert.ToInt32(textBox7.Text);

            var source = lblFileName.Text;
            DateTime datetime = DateTime.Now;
            var fileName = "img_" + datetime.Ticks.ToString();
            var destinationFolder = Path.Combine(Environment.CurrentDirectory, "Gambar");
            var destination = Path.Combine(destinationFolder, fileName);
            try
            {
                File.Copy(source, destination);
                produk.gambar = destination.ToString();

            }
            catch (Exception err)
            {
                produk.gambar = "";
                String error = err.Message;

            }


            String response = produk.Insert();
            if (response == null)
            {
                MessageBox.Show("Tambah Produk Berhasil");
                this.Hide();
                FormDataProduk frmAdm = new FormDataProduk(user);
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
            FormDataProduk frmAdm = new FormDataProduk(user);
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

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataProfil frmAdm = new FormDataProfil(user);
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

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLaporan frmAdm = new FormLaporan(user);
            frmAdm.Show();
        }
    }
}
