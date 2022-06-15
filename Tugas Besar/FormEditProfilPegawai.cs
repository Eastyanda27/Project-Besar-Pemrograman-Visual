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
    public partial class FormEditProfilPegawai : Form
    {
        User user;
        User user1;
        public FormEditProfilPegawai(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void FormEditProfilPegawai_Load(object sender, EventArgs e)
        {
            user1 = new User();
            user1 = User.SelectUsername(user.username);
            textBox2.Text = user1.username;
            textBox1.Text = user1.nama;
            dateTimePicker1.Value = Convert.ToDateTime(user1.tanggal_lahir);
            comboBox2.Text = user1.jenis_kelamin;
            textBox4.Text = user1.no_telepon;
            String fileName = user1.gambar;
            if (fileName != "")
            {
                try
                {
                    pictureBox7.Image = new Bitmap(fileName);
                }
                catch (Exception err)
                {
                    String error = err.Message;
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTransaksiPegawai frmAdm = new FormTransaksiPegawai(user);
            frmAdm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataProfilPegawai frmAdm = new FormDataProfilPegawai(user);
            frmAdm.Show();
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
            User user = new User();
            user.username = textBox2.Text;
            user.nama = textBox1.Text;
            user.tanggal_lahir = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            user.jenis_kelamin = comboBox2.SelectedItem.ToString();
            user.no_telepon = textBox4.Text;

            //copy img
            var source = lblFileName.Text;
            DateTime dateTime = DateTime.Now;
            var fileName = "img_" + dateTime.Ticks.ToString();
            var destinationFolder = Path.Combine(Environment.CurrentDirectory, "Gambar");
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

            String response = user.Update();
            if (response == null)
            {
                MessageBox.Show("Edit Profil Berhasil");
                this.Hide();
                FormDataProfil frmAdm = new FormDataProfil(user);
                frmAdm.Show();
            }
            else
            {
                MessageBox.Show("Edit Profil Gagal. Error " + response);
            }
        }
    }
}
