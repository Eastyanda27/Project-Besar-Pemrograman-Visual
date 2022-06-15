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
    public partial class FormDashboardPegawai : Form
    {
        User user;
        public FormDashboardPegawai(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void FormDashboardPegawai_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataProfilPegawai frmAdm = new FormDataProfilPegawai(user);
            frmAdm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTransaksiPegawai frmAdm = new FormTransaksiPegawai(user);
            frmAdm.Show();
        }
    }
}
