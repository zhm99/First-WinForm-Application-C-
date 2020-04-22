using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradoviWinForm
{
    public partial class frmStampa : Form
    {
        public frmStampa()
        {
            InitializeComponent();
        }

        private void btnStampaj_Click(object sender, EventArgs e)
        {
            string query = "SELECT Naziv, PostanskiBroj FROM Gradovi";
            string constr = @"Data Source=ServerName\SQLEXPRESS;Initial Catalog=MyData;Integrated Security=True";
            SqlConnection cn = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Connection = cn;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dat = new DataTable();
            sda.Fill(dat);
            StampaReport11 cr1 = new StampaReport11();
            cr1.SetDataSource(dat);
            crystalReportViewer1.ReportSource = cr1;
            crystalReportViewer1.Refresh();
        }

        private void frmStampa_Load(object sender, EventArgs e)
        {

        }
    }
}
