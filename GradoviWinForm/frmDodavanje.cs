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
    public partial class frmDodavanje : Form
    {
        string constr = @"Data Source=ServerName\SQLEXPRESS;Initial Catalog=MyData;Integrated Security=True";
        SqlCommand cmd;
        //ID varijabla koristena za izmjenu i brisanje podatka  
        int ID = 0;


        public frmDodavanje()
        {
            InitializeComponent();

        }

        private void btnUpisati_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);


            if (txtNaziv.Text != "" && txtPostanskiBroj.Text != "")
            {
                cmd = new SqlCommand("insert into Gradovi(Naziv,PostanskiBroj,DatumIVrijemeUpisa) values(@naziv,@postanskibroj,getdate())", con);
                con.Open();
                cmd.Parameters.AddWithValue("@naziv", txtNaziv.Text);
                cmd.Parameters.AddWithValue("@postanskibroj", txtPostanskiBroj.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Podatak upisan uspjesno");
                
                //Brisanje podatka
                txtNaziv.Text = "";
                txtPostanskiBroj.Text = "";
                ID = 0;

            }
            else
            {
                MessageBox.Show("Unesite potrebne vrijednosti! Obavezan unos oba podatka!");
            }
        }

        private void btnOdustati_Click(object sender, EventArgs e)
        {
            // Prekid upisa - vracanje na prvu formu za pregled gradova
            this.Close();
        }

        private void frmDodavanje_Load(object sender, EventArgs e)
        {

        }
    }
}
