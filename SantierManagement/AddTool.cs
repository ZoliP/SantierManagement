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
    public partial class AddTool : Form
    {
        string numeUt, prodUt;
        int tarifUt;

        public AddTool()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            numeUt = textBoxDenumire.Text;
            prodUt = textBoxProducator.Text;
            tarifUt = Convert.ToInt16(textBoxTarif.Text);
            try
            {
                if (numeUt == "" || prodUt == "")
                    throw new Exception("Date incomplete. Repetati!");
                Adaugare_DB.inregistrariUtilaj(numeUt, prodUt, Convert.ToInt16(tarifUt));
                MessageBox.Show("Utilaj nou adaugat");
                textBoxDenumire.Text = "";
                textBoxProducator.Text = "";
                textBoxTarif.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);            
            }
        }
    }
}
