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
    public partial class AddTransport : Form
    {
        string numeTr;
        int valTr;

        public AddTransport()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            numeTr = textBoxDenumire.Text;
            valTr = Convert.ToInt16(textBoxPret.Text);
            try
            {
                 if (numeTr == "")
                    throw new Exception("Date incomplete. Repetati!");
            Adaugare_DB.inregistrariTransport(numeTr, valTr);
            MessageBox.Show("Material nou transportat adaugat");
            textBoxDenumire.Text = "";
            textBoxPret.Text = "";            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);            
            }        
        }
    }
}
