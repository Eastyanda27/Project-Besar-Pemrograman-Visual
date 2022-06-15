using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tugas_Besar.ReportGenerator.CrystalReport;

namespace Tugas_Besar
{
    public partial class CetakPegawai : Form
    {
        public CetakPegawai()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DataTable user = new DataTable();
            user.Columns.Add("username", typeof(String));
            user.Columns.Add("nama", typeof(String));
            user.Columns.Add("tanggal_lahir", typeof(DateTime));
            user.Columns.Add("jenis_kelamin", typeof(String));
            user.Columns.Add("no_telepon", typeof(String));
            user.Columns.Add("hak_akses", typeof(String));
            user = User.SelectFull();

            CrPegawai cr1 = new CrPegawai();
            cr1.Database.Tables["pegawai"].SetDataSource(user);
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = cr1;
        }
    }
}
