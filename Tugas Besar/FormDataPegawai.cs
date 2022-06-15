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
    public partial class FormDataPegawai : Form
    {
        User user;
        public FormDataPegawai(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "foto")
            {
                // Your code would go here - below is just the code I used to test 
                string s = dataGridView1.Rows[e.RowIndex].Cells["gambar"].Value.ToString();
                if (s != "") e.Value = Image.FromFile(s);
                else e.Value = null;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAddPegawai frmAdm = new FormAddPegawai(user);
            frmAdm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboardAdm frmAdm = new FormDashboardAdm(user);
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

        private void loadDataPegawai()
        {
            User user = new User();
            DataTable dt = new DataTable();
            dt = User.SelectFull();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["gambar"].Visible = false;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Show();
        }

        private void ChildFromClosing (object sender, FormClosingEventArgs e)
        {
            loadDataPegawai();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            User pegawai = new User();
            int selectdrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectdrowindex];
            pegawai.gambar = Convert.ToString(selectedRow.Cells["gambar"].Value);
            pegawai.username = Convert.ToString(selectedRow.Cells["username"].Value);
            pegawai.nama = Convert.ToString(selectedRow.Cells["nama"].Value);
            pegawai.tanggal_lahir = Convert.ToString(selectedRow.Cells["tanggal_lahir"].Value);
            pegawai.jenis_kelamin = Convert.ToString(selectedRow.Cells["jenis_kelamin"].Value);
            pegawai.no_telepon = Convert.ToString(selectedRow.Cells["no_telepon"].Value);
            pegawai.hak_akses = Convert.ToString(selectedRow.Cells["hak_akses"].Value);

            if (Convert.ToBoolean(selectedRow.Cells["hapus"].Selected) == true)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Yakin menghapus pegawai " + pegawai.username +
                    " ?", "Hapus Data Pegawai", buttons);
                if (result == DialogResult.Yes)
                {
                    string response;
                    response = pegawai.Delete();
                    if (response == null) MessageBox.Show("Sukses");
                    else MessageBox.Show(response);
                    loadDataPegawai();
                }
                else
                {

                }
            }
            else
            {
                
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            User user = new User();
            DataTable dt = new DataTable();
            dt = User.Select(txtboxCariPengguna.Text);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["gambar"].Visible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Show();
        }

        private void FormDataPegawai_Load(object sender, EventArgs e)
        {
            loadDataPegawai();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CetakPegawai frmAdm = new CetakPegawai();
            frmAdm.Show();
        }
    }
}
