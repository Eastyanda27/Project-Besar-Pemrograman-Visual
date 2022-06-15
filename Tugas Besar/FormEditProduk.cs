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
    public partial class FormEditProduk : Form
    {
        User user;
        public FormEditProduk(User user)
        {
            InitializeComponent();
            this.user = user;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataProduk frmAdm = new FormDataProduk(user);
            frmAdm.Show();
        }

        private void FormEditProduk_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = Connection.conString();
            MySqlCommand cmd = new MySqlCommand("SELECT nama_produk FROM produk", conn);
            MySqlDataReader rdr;
            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string no_produk = rdr.GetString(0);
                    comboBox1.Items.Add(no_produk);
                }
            }
            catch
            {

            }
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
                pictureBox7.Image = new Bitmap(open.FileName);
                pictureBox7.ImageLocation = open.FileName;
                pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Produk produk = new Produk();
            produk.no_produk = textBox2.Text;
            produk.no_barcode = textBox5.Text;
            produk.nama_produk = comboBox1.Text;
            produk.jenis_produk = textBox6.Text;
            produk.harga_jual = Convert.ToInt32(textBox3.Text);
            produk.jumlah_produk = Convert.ToInt32(textBox4.Text);

            //copy img
            var source = lblFileName.Text;
            DateTime dateTime = DateTime.Now;
            var fileName = "img_" + dateTime.Ticks.ToString();
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

            String response = produk.update();
            if (response == null)
            {
                MessageBox.Show("Edit Produk Berhasil");
                this.Hide();
                FormDataProduk frmAdm = new FormDataProduk(user);
                frmAdm.Show();
            }
            else
            {
                MessageBox.Show("Edit Produk Gagal. Error " + response);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = Connection.conString();
            MySqlCommand cmd = new MySqlCommand("SELECT no_produk,no_barcode,jenis_produk,harga_jual,jumlah_produk FROM produk WHERE nama_produk = '" + comboBox1.Text + "';", conn);
            MySqlDataReader rdr;
            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string jumlah_produk = rdr.GetInt32(4).ToString();
                    string harga_jual = rdr.GetInt32(3).ToString();
                    string jenis_produk = rdr.GetString(2);
                    string no_barcode = rdr.GetString(1);
                    string no_produk = rdr.GetString(0);
                    textBox2.Text = no_produk;
                    textBox5.Text = no_barcode;
                    textBox6.Text = jenis_produk;
                    textBox3.Text = harga_jual;
                    textBox4.Text = jumlah_produk;
                }
            }
            catch
            {

            }
        }
    }
}
