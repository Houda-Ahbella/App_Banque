using System;
using System.Collections.Generic;
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

		}
		//virtual void consulter();
		public void crediter(float somme)
		{
			this.solde = this.solde + somme;
			this.historique.Add(new OperationA(somme));

		}
		public bool debiter(float M)
		{
			if (plafond > M)
			{
				this.solde = this.solde - M;
				this.historique.Add(new OperationR(M));
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
