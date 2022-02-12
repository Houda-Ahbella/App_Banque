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
    public partial class Oper : Form
    {
        private Compte com;
        public Oper(Compte c)
        {
            com = c;
            InitializeComponent();
        }

        private void Oper_Load(object sender, EventArgs e)
        {
            
            richTextBox1.Text = com.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ss = int.Parse(textBox1.Text);
            com.crediter(ss);
            richTextBox1.Text = com.ToString();
            MessageBox.Show("Credit avec succes");
            SqlCommand commande;
            SqlDataReader reader;
            string requete ;
            requete = "update Compte set solde = " + com.solde + " where numCompte = " + com.numcompte;
            commande = new SqlCommand(requete, Form1.connexion);
            reader = commande.ExecuteReader();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
           if( com.debiter(int.Parse(textBox1.Text)))
            {
                richTextBox1.Text = com.ToString();
                SqlCommand commande;
                SqlDataReader reader;
                string requete;
                requete = "update Compte set solde = " + com.solde + " where numCompte = " + com.numcompte;
                commande = new SqlCommand(requete, Form1.connexion);
                reader = commande.ExecuteReader();
                MessageBox.Show("debit avec succes");
            }
               
           else MessageBox.Show("echec de debit");
        }
    }
}
