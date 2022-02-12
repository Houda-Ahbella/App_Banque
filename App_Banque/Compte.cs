using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Banque
{
    public class Compte
    {
		public int numcompte;
		private Client titulaire;
		public float solde;
		static private float plafond=200;
		private int choix;
		
		List<Operation> historique;
		

		public Compte(int id, Client clt, float solde, int ch)
		{
			this.numcompte = id;
			this.titulaire = clt;
			this.solde = solde;
			plafond = 1000;
			this.choix = ch;
			this.historique = new List<Operation>();
			string requete = "select * from OperationA where numCompte = " + id;
			SqlCommand commande = new SqlCommand(requete, Form1.connexion);
			SqlDataReader reader = commande.ExecuteReader();
			while (reader.Read())
			{
				Operation o = new OperationA(float.Parse(reader["numOperation"].ToString()));
				this.historique.Add(o);
			
			}
            string requete2 = "select * from OperationR where numCompte = " + id;
            SqlCommand commande2 = new SqlCommand(requete2, Form1.connexion);
            SqlDataReader reader2 = commande2.ExecuteReader();
            while (reader2.Read())
            {
                Operation o = new OperationR(float.Parse(reader2["numOperation"].ToString()));
                this.historique.Add(o);

            }

        }
		
		public void crediter(float somme)
		{
			this.solde = this.solde + somme;
			Operation A =new OperationA(somme);
			this.historique.Add(A);
			string requete = "insert into OperationA (numOperation,montant,numCompte) values (" + A.num +"," +somme+","+ this.numcompte+")" ;
			SqlCommand commande = new SqlCommand(requete, Form1.connexion);
			SqlDataReader reader = commande.ExecuteReader();

		}
		
		public bool debiter(float M)
		{
			if (plafond > M)
			{
				this.solde = this.solde - M;
				Operation A = new OperationR(M);
				this.historique.Add(A);
				string requete = "insert into OperationR (numOperation,montant,numCompte) values (" + A.num + "," + M + "," + this.numcompte + ")";
				SqlCommand commande = new SqlCommand(requete, Form1.connexion);
				SqlDataReader reader = commande.ExecuteReader();
				return true;
			}
			return false;
           
		}
		public override string ToString()
		{
			string s = "";
		if (this.choix == 1)
		s= " numero de compte est : " + this.numcompte + " le type du compte est courant";
			
		if (this.choix == 2)
		s= " numero de compte est :" + this.numcompte + " le type du compte est epagne";
		else
		s= " numero de compte est :" + this.numcompte + " le type du compte est courant epagne";
			s = s+ " montant :" + this.solde + "\n les poerations : \n";
			foreach (Operation i in this.historique)
				s = s + i.affiche() + "\n";
			return s;

		}
		public bool Compare(int nm)
        {

			if (this.numcompte == nm) return true;
			return false;
        }

	}
}

