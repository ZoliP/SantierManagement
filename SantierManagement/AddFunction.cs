using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SantierManagement
{
    public partial class AddFunction : Form
    {
        string numeFct;

        public AddFunction()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            numeFct = textBoxFunctie.Text;
            try
            {
                if (numeFct == "")
                    throw new Exception("Introduceți numele funcției!");
                Adaugare_DB.inregistrariFunctie(numeFct);
                MessageBox.Show("Funcție nouă adăugat!");
                textBoxFunctie.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }
    }
}
