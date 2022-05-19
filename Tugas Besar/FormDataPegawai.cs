using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas_Besar
{
    public partial class FormDataPegawai : Form
    {
        public FormDataPegawai()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAddPegawai frmAdm = new FormAddPegawai();
            frmAdm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboardAdm frmAdm = new FormDashboardAdm();
            frmAdm.Show();
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
    }
}
