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
    public partial class frmGradovi : Form
    {
        public frmGradovi()
        {
            InitializeComponent();
        }

        //globalne varijable
        SqlConnection con;
        SqlCommand sqlCmd;
        string constr = @"Data Source=ServerName\SQLEXPRESS;Initial Catalog=MyData;Integrated Security=True";
        string query;
        DataSet dataSet;
        DataTable dtRecord;
        SqlDataAdapter sqlDataAdap;

        private void frmGradovi_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            query = "SELECT Naziv, PostanskiBroj FROM Gradovi";
            SqlCommand sqlCmd = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
            DataTable dtRecord = new DataTable();
            sqlDataAdap.SelectCommand = sqlCmd;
            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //pretraga koristeci textBox umjesto pretrage na dugme Pretrazi

            /*SqlConnection con = new SqlConnection(constr);
            query = "SELECT Naziv, PostanskiBroj FROM Gradovi";
            query = query + " WHERE 1=1 ";

            string[] lista_izraza;
            lista_izraza = txtSearch.Text.Split(' ');

            foreach (string izraz in lista_izraza)
            {
                query = query + string.Format(" AND isnull(Naziv,'') + ';' + isnull(PostanskiBroj,'') LIKE '%{0}%'", izraz);
            }

            //pretraga koristeci textBox umjesto pretrage na dugme Pretrazi
            SqlCommand sqlCmd = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
            DataTable dtRecord = new DataTable();
            sqlDataAdap.SelectCommand = sqlCmd;
            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;*/
        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
            //filtriranje podataka tako što će prikazati samo gradove i poštanske brojeve koje sadrže sve ključne riječi
            //uneseni tekst pretvara u ključne riječi koristeći prazno mjesto kao separator razdvajanja
            SqlConnection con = new SqlConnection(constr);
            query = "SELECT Naziv, PostanskiBroj FROM Gradovi";
            query = query + " WHERE 1=1 ";

            string[] lista_izraza;
            lista_izraza = txtSearch.Text.Split(' ');

            foreach (string izraz in lista_izraza)
            {
                query = query + string.Format(" AND isnull(Naziv,'') + ';' + isnull(PostanskiBroj,'') LIKE '%{0}%'", izraz);
            }

            SqlCommand sqlCmd = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
            DataTable dtRecord = new DataTable();
            sqlDataAdap.SelectCommand = sqlCmd;
            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;
        }

        private void btnOsvjezi_Click(object sender, EventArgs e)
        {
            try
            {
                //sql connection objekat
                using (SqlConnection conn = new SqlConnection(constr))
                {

                    //dohvatiti SQL Server instancu 
                    string query = @"SELECT Naziv, PostanskiBroj FROM Gradovi";


                    //definisanje SqlCommand objekta
                    SqlCommand cmd = new SqlCommand(query, conn);


                    //Setovanje SqlDataAdapter objekta
                    SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);

                    //definisanje dataset-a
                    DataSet ds = new DataSet();

                    //ispuniti dataset sa query rezultatom
                    dAdapter.Fill(ds);

                    //setovati DataGridView kontrolu na read-only
                    dataGridView1.ReadOnly = true;

                    //postaviti DataGridView kontrole data source/data table
                    dataGridView1.DataSource = ds.Tables[0];


                    //zatvaranje konekcije
                    conn.Close();
                }
            }

            catch (Exception ex)
            {
                //prikaz poruke sa greskom
                MessageBox.Show("Nije moguce prikazati nove rezultate!" + ex.Message);
            }
        }

        private void dodavanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDodavanje fd = new frmDodavanje();
            fd.ShowDialog();
        }

        private void izmjenaIBrisanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIzmjenaBrisanje fib = new frmIzmjenaBrisanje();
            fib.ShowDialog();
        }

        private void štampaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStampa fs = new frmStampa();
            fs.ShowDialog();
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Jeste li sigurni da zelite zatvoriti aplikaciju?", "Zatvori program?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //System.IO.File.AppendAllText(errorlogpath, extmsg);
                this.Close();
                Application.Exit();
            }
        }
    }
}
