using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Banque
{
    class OperationR : Operation
    {
        public OperationR(float f) : base(f)
        {
        }

        public override string affiche() 
        {
            return " - " + base.affiche();
        }
    }
}
