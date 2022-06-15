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
    public partial class FormDataProfil : Form
    {
        User user;
        User user1;
        public FormDataProfil(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboardAdm frmAdm = new FormDashboardAdm(user);
            frmAdm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormEditProfil frmAdm = new FormEditProfil(user);
            frmAdm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormEditPassword frmAdm = new FormEditPassword(user);
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

        private void FormDataProfil_Load(object sender, EventArgs e)
        {
            user1 = new User();
            user1 = User.SelectUsername(user.username);
            label12.Text = user1.username;
            label17.Text = user1.nama;
            label18.Text = user1.tanggal_lahir;
            label16.Text = user1.jenis_kelamin;
            label19.Text = user1.no_telepon;
            label20.Text = user1.hak_akses;
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin frmAdm = new FormLogin();
            frmAdm.Show();
        }
    }
}
