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
    public partial class AddWorker : Form
    {
        DataTable functiiDT;
        int codfctMan, tarifMan;
        string numeMan, prenumeMan;

        private void completezFunctii()
        {
            comboBoxFunctia.Items.Clear();
            functiiDT = Interogari_DB.selectezFunctii();
            comboBoxFunctia.DataSource = functiiDT;
            comboBoxFunctia.ValueMember = "cod_functie";
            comboBoxFunctia.DisplayMember = "denumire_functie";        
        }

        public AddWorker()
        {
            InitializeComponent();
            completezFunctii();        
        }

       
        private void buttonNewFunction_Click(object sender, EventArgs e)
        {
            AddFunction func = new AddFunction();
            func.ShowDialog();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            numeMan = textBoxNume.Text;
            prenumeMan = textBoxPrenume.Text;
            codfctMan = Convert.ToInt16(comboBoxFunctia.SelectedValue.ToString());
            tarifMan = Convert.ToInt16(textBoxTarif.Text);
            try 
            {
                if (numeMan =="" || prenumeMan =="")
                    throw new Exception("Date incomplete.Repetati!");
                Adaugare_DB.inregistrariManopera(numeMan, prenumeMan, Convert.ToInt16(codfctMan), tarifMan);
                MessageBox.Show("Angajat nou adăugat!");
                textBoxNume.Text = "";
                textBoxPrenume.Text = "";
                textBoxTarif.Text = "";            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                
        }
    }
}
