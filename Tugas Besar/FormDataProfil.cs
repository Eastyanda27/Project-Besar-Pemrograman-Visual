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
    public partial class FormDataProfil : Form
    {
        public FormDataProfil()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboardAdm frmAdm = new FormDashboardAdm();
            frmAdm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormEditProfil frmAdm = new FormEditProfil();
            frmAdm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormEditPassword frmAdm = new FormEditPassword();
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
    }
}
