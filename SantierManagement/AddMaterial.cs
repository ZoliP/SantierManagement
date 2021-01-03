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
    public partial class AddMaterial : Form
    {
        DataTable furnizoriDT;
        string denMat, umMat;
        int pretMat, furnizor;

        public AddMaterial()
        {
            InitializeComponent();
            completezFurnizori();
        }

        private void completezFurnizori()
        {
            comboBoxFurnizor.Items.Clear();
            furnizoriDT = Interogari_DB.selectezFurnizor();
            comboBoxFurnizor.DataSource = furnizoriDT;
            comboBoxFurnizor.ValueMember = "cod_furnizor";
            comboBoxFurnizor.DisplayMember = "denumire";                    
        }
       
        private void buttonFurnizorNou_Click(object sender, EventArgs e)
        {
            AddDealer furniz = new AddDealer();
            furniz.ShowDialog();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            denMat = textBoxDenumire.Text;
            umMat = textBoxUM.Text;
            pretMat = Convert.ToInt16(textBoxPret.Text);
            furnizor = Convert.ToInt16(comboBoxFurnizor.SelectedValue.ToString());
            try
            {
                if (denMat == "" || umMat == "")
                    throw new Exception("Date incomplete. Repetati!");
                Adaugare_DB.inregistrariMateriale(denMat, umMat, Convert.ToInt16(pretMat), Convert.ToInt16(furnizor));
                MessageBox.Show("Material nou adaugat");
                textBoxDenumire.Text = "";
                textBoxUM.Text = "";
                textBoxPret.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }                
    }
}
