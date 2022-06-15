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
        User user;
        public FormAddPegawai(User user)
        {
            InitializeComponent();
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
                pictureBox7.Image = new Bitmap(open.FileName);
                pictureBox7.ImageLocation = open.FileName;
                pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataPegawai frmAdm = new FormDataPegawai(user);
            frmAdm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User akun = new User();
            akun.username = textBox2.Text;
            akun.password = textBox1.Text;
            akun.nama = textBox3.Text;
            akun.tanggal_lahir = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            akun.jenis_kelamin = comboBox1.SelectedItem.ToString();
            akun.no_telepon = textBox4.Text;
            akun.hak_akses = comboBox2.SelectedItem.ToString();

            //copy img
            var source = lblFileName.Text;
            DateTime dateTime = DateTime.Now;
            var fileName = "img_" + dateTime.Ticks.ToString();
            var destinationFolder = Path.Combine(Environment.CurrentDirectory, "Gambar");
            var destination = Path.Combine(destinationFolder, fileName);
            try
            {
                File.Copy(source, destination);
                akun.gambar = destination.ToString();
            }
            catch (Exception err)
            {
                akun.gambar = "";
                String error = err.Message;
            }

            String response = akun.insert();
            if (response == null)
            {
                MessageBox.Show("Tambah User Berhasil");
                this.Close();
                FormDataPegawai frmAdm = new FormDataPegawai(user);
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
