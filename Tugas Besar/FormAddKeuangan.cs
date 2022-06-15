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
    public partial class FormAddKeuangan : Form
    {
        User user;
        public FormAddKeuangan(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKeuangan frmAdm = new FormKeuangan(user);
            frmAdm.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Keuangan keuangan = new Keuangan();
            keuangan.tanggal_keuangan = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            keuangan.jenis_keuangan = comboBox1.SelectedItem.ToString();
            keuangan.jumlah_uang = Convert.ToInt32(textBox1.Text);

            String response = keuangan.Insert();
            if (response == null)
            {
                MessageBox.Show("Tambah Data Keuangan Berhasil");
                this.Hide();
                FormKeuangan frmAdm = new FormKeuangan(user);
                frmAdm.Show();
            }
            else
            {
                MessageBox.Show("Tambah Data Keuangan Gagal. Error " + response);
            }
        }
    }
}
