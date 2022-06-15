using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;

namespace Tugas_Besar
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.username = TextBoxUsername.Text;
            user.password = TextBoxPassword.Text;
            if (user.validasi())
            {
                MessageBox.Show("User berhasil login");
                if (user.hak_akses == "Admin")
                {
                    FormDashboardAdm frmDashboard = new FormDashboardAdm(user);
                    frmDashboard.Show();
                    this.Hide();
                }
                else if (user.hak_akses == "Pegawai")
                {
                    FormDashboardPegawai frmKasir = new FormDashboardPegawai(user);
                    frmKasir.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("User gagal login");
                TextBoxUsername.Text = "";
                TextBoxPassword.Text = "";
            }
        }
    }
}
