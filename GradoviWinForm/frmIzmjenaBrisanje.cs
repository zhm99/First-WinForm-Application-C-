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
    public partial class frmIzmjenaBrisanje : Form
    {
        //konekcijski string
        string constr = @"Data Source=ServerName\SQLEXPRESS;Initial Catalog=MyData;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID varijabla koristena za upis, izmjenu i brisanje podatka  
        int ID = 0;

        public frmIzmjenaBrisanje()
        {
            InitializeComponent();
            PrikazPodataka();
        }

        //Prikaz podataka u DataGridView  
        private void PrikazPodataka()
        {
            SqlConnection con = new SqlConnection(constr);
            
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Gradovi", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //Brisanje podatka  
        private void BrisanjePodatka()
        {
            txtNaziv.Text = "";
            txtPostanskiBroj.Text = "";
            ID = 0;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtNaziv.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPostanskiBroj.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnIzmjena_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);

            if (txtNaziv.Text != "" && txtPostanskiBroj.Text != "")
            {
                cmd = new SqlCommand("update Gradovi set Naziv=@naziv, PostanskiBroj=@postanskibroj, DatumIVrijemeUpisa=getdate() where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@naziv", txtNaziv.Text);
                cmd.Parameters.AddWithValue("@postanskibroj", txtPostanskiBroj.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Podatak uspjesno izmijenjen!");
                con.Close();
                PrikazPodataka();
                BrisanjePodatka();

            }
            else
            {
                MessageBox.Show("Odaberite podatak za izmjenu!");
            }
        }

        private void btnObrisati_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);

            if (ID != 0)
            {
                cmd = new SqlCommand("delete Gradovi where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Podatak uspjesno obrisan!");
                PrikazPodataka();
                BrisanjePodatka();

            }
            else
            {
                MessageBox.Show("Odaberite podatak za brisanje!");
            }
        }

        private void btnOdustati_Click(object sender, EventArgs e)
        {
            // Prekid upisa - vracanje na prvu formu za pregled gradova
            this.Close();
        }

        private void frmIzmjenaBrisanje_Load(object sender, EventArgs e)
        {

        }
    }
}
