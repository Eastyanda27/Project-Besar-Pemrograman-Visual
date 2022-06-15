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
    public partial class FormDataProfilPegawai : Form
    {
        User user;
        User user1;
        public FormDataProfilPegawai(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void FormDataProfilPegawai_Load(object sender, EventArgs e)
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

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTransaksiPegawai frmAdm = new FormTransaksiPegawai(user);
            frmAdm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboardPegawai frmAdm = new FormDashboardPegawai(user);
            frmAdm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin frmAdm = new FormLogin();
            frmAdm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormEditProfilPegawai frmAdm = new FormEditProfilPegawai(user);
            frmAdm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormEditPasswordPegawai frmAdm = new FormEditPasswordPegawai(user);
            frmAdm.Show();
        }
    }
}
