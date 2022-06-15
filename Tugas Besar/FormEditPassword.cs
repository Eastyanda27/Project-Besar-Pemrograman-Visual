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
    public partial class FormEditPassword : Form
    {
        User user;
        public FormEditPassword(User user)
        {
            InitializeComponent();
            this.user = user;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataProfil frmAdm = new FormDataProfil(user);
            frmAdm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User password = new User();
            password.username = textBox4.Text;
            password.password = textBox3.Text;
            if (password.ValidasiPassword())
            {
                if (textBox2.Text == textBox1.Text)
                {
                    password.username = textBox4.Text;
                    password.password = textBox2.Text;
                    String response = password.UpdatePassword();
                    if (response == null)
                    {

                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Konfirmasi Password Baru Salah");
                    this.Hide();
                    FormEditPassword frmPass = new FormEditPassword(user);
                    frmPass.Show();
                }
                MessageBox.Show("Password Berhasil Diubah");
                FormDataProfil frmAdm = new FormDataProfil(user);
                frmAdm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username / Password Lama Salah");
            }
        }
    }
}
