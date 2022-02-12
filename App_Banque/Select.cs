using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Banque
{
    public partial class Select : Form
    {
         private Compte com = null;  
        public Select()
        {
           
            InitializeComponent();
            
        }

        private void Select_Load(object sender, EventArgs e)
        {
            richTextBoxn.Text = Form1.c.ToString();
            string s = "";
            foreach(Compte i in Form1.c.comptes )
            {
                s = s + i.ToString() + "\n";

            }
            richTextBox1.Text = s;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int choix = int.Parse(textBox1.Text);
            foreach (Compte i in Form1.c.comptes)
            {
                if (i.Compare(choix))
                { com = i;
                    break;
                } 
            }
            if (com == null) MessageBox.Show("numero invalide");
            else
            {

                this.Hide();
                Oper p = new Oper(this.com);
                p.Show();

            }

        }
        
    }
}

