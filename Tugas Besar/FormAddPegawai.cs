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
    public partial class FormAddPegawai : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; database = tugas_besar_visual; uid = root; sslMode = none; password =");
        public FormAddPegawai()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataPegawai frmAdm = new FormDataPegawai();
            frmAdm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.username = textBox2.Text;
            user.password = textBox1.Text;
            user.nama = textBox3.Text;
            user.tanggal_lahir = dateTimePicker1.Value.ToString("yyyyMMdd");
            user.jenis_kelamin = comboBox1.SelectedItem.ToString();
            user.no_telepon = textBox4.Text;
            user.hak_akses = comboBox2.SelectedItem.ToString();

            //copy img
            var source = lblFileName.Text;
            DateTime dateTime = DateTime.Now;
            var fileName = "img_" + dateTime.Ticks.ToString();
            var destinationFolder = Path.Combine(Environment.CurrentDirectory, "gambar");
            var destination = Path.Combine(destinationFolder, fileName);
            try
            {
                File.Copy(source, destination);
                user.gambar = destination.ToString();
            }
            catch (Exception err)
            {
                user.gambar = "";
                String error = err.Message;
            }

            String response = user.insert();
            if (response == null)
            {
                MessageBox.Show("Tambah User Berhasil");
                this.Close();
                FormDataPegawai frmAdm = new FormDataPegawai();
                frmAdm.Show();
            }
            else
            {
                MessageBox.Show("Tambah User Gagal. Error " + response);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataProfil frmAdm = new FormDataProfil();
            frmAdm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataProduk frmAdm = new FormDataProduk();
            frmAdm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKeuanganHarian frmAdm = new FormKeuanganHarian();
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

        private void button5_Click(object sender, EventArgs e)
        {
            var isi = "1234567890abcdefghijklmnopqrstuvwxyz";
            var random = new char[8];
            var acak = new Random();

            for (int i = 0; i < random.Length; i++)
            {
                random[i] = isi[acak.Next(isi.Length)];
            }

            textBox2.Text = new string(random);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var isi = "1234567890abcdefghijklmnopqrstuvwxyz";
            var random = new char[8];
            var acak = new Random();

            for (int i = 0; i < random.Length; i++)
            {
                random[i] = isi[acak.Next(isi.Length)];
            }

            textBox1.Text = new string(random);
        }
    }
}
