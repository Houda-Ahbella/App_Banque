using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Banque
{
	class Operation
	{

		static int compteur;
		int num;
		float montant;
		public Operation(float f)
		{
			this.num = compteur++;
			this.montant = f;
		}
		public virtual string affiche()
			{
			return this.montant + "";
			}

	}
}
