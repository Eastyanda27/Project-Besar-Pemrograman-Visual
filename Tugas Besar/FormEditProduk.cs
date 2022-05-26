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
        //Produk produk;
        public FormEditProduk()
        {
            InitializeComponent();
            //this.produk = produk;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataProduk frmAdm = new FormDataProduk();
            frmAdm.Show();
        }

        private void FormEditProduk_Load(object sender, EventArgs e)
        {
            textBox2.Text = produk.no_produk.ToString();
            textBox5.Text = produk.no_barcode.ToString();
            textBox1.Text = produk.nama_produk.ToString();
            textBox6.Text = produk.jenis_produk.ToString();
            textBox3.Text = produk.harga_jual.ToString();
            textBox4.Text = produk.jumlah_produk.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                //pbProfile.Image = new Bitmap(open.FileName);
                // image file path  
                lblFileName.Text = open.FileName;
                if (open.FileName != "") pictureBox7.Image = new Bitmap(open.FileName);
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

            //copy img
            var source = lblFileName.Text;
            DateTime dateTime = DateTime.Now;
            var fileName = "img_" + dateTime.Ticks.ToString();
            var destinationFolder = Path.Combine(Environment.CurrentDirectory, "gambar");
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
                FormDataProduk frmAdm = new FormDataProduk();
                frmAdm.Show();
            }
            else
            {
                MessageBox.Show("Edit Produk Gagal. Error " + response);
            }
        }
    }
}
