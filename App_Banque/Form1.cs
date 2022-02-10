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

namespace App_Banque
{
    public partial class Form1 : Form
    {
        static public SqlConnection connexion;
        static public Client c;
        public Form1()
        {

            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connexStr;
            connexStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BanqueApp;MultipleActiveResultSets = True;";
            connexion = new SqlConnection(connexStr);
            connexion.Open();
            SqlCommand commande;
            SqlDataReader reader;
            string requete;
            string log = textBox1.Text;
            string pass = textBox2.Text;
            requete = "select *from Client where nom = 'Ahbella' and prenom = 'Houda' ";
            commande = new SqlCommand(requete, connexion);
            reader = commande.ExecuteReader();
            string s = " Bonjour ";
            if (reader.Read())
            {
                int idclt = int.Parse(reader["Id"].ToString());
                s = s + reader["Id"].ToString() + " " + reader["nom"].ToString();

                c = new Client(idclt, reader["nom"].ToString(), reader["prenom"].ToString(), reader["adresse"].ToString(), reader["login"].ToString(), reader["password"].ToString());
                SqlCommand com;
                SqlDataReader re;
                string req = "select * from Compte where numClient =" + idclt;
                com = new SqlCommand(req, connexion);
                re = com.ExecuteReader();
                
                while (re.Read())
                {
                  Compte cp1 = new Compte(int.Parse(re["numCompte"].ToString()), c, float.Parse(re["solde"].ToString()), int.Parse(re["choix"].ToString()));
                  c.comptes.Add(cp1);
                }

                // clients.Add(c);
            }
            Select formselect = new Select();
            this.Hide();
            formselect.Show();
            



        }
    }
}
