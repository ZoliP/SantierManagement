using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SantierManagement
{
    public partial class AddSantier : Form
    {
        // fereastra de dialog pt alegere fisier
        OpenFileDialog flDlg = new OpenFileDialog();
        string denSantier, benSantier, adrSantier, proiSantier, imgSantier;
        int manager;
        DataTable sefSantDT;

        private void completezComboBoxSefSantier()
        {
            comboBoxSefSantier.Items.Clear();
            sefSantDT = Interogari_DB.selectezSefSantier();
            comboBoxSefSantier.DataSource = sefSantDT;
            comboBoxSefSantier.ValueMember = "id_u";
            comboBoxSefSantier.DisplayMember = "nume_prenume";        
        }

        public AddSantier()
        {
            InitializeComponent();
            completezComboBoxSefSantier();

        }

        private void buttonSelectImg_Click(object sender, EventArgs e)
        {
            //selectez fisierul imagine din folderul //Poze
            flDlg.Filter = "Image File|*.jpg"; //ce tip de fisier sa arate in fereastra
            flDlg.Title = "Selectează fișierul imagine"; // titlul ferestrei
            // deschid o fereastra de dialog pt. selectarea imaginii
            flDlg.InitialDirectory = Directory.GetCurrentDirectory() + @"\Poze";
            if (flDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) //A fost apasat butonul OK
            {
                // Calea completa a fisierului:
                string caleFisier = flDlg.FileName;
                // Separam bucatile din path complet - ce se afla intre \\
                string[] numeFisier = @caleFisier.Split('\\');
                // Luam doar ultima parte (bucata) - numele fisierului - este la sfarsitul path-ului  
                textBoxImagine.Text = numeFisier[numeFisier.Length - 1];
            }
        }
                  
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            denSantier = textBoxDenumire.Text;
            benSantier = textBoxBeneficiar.Text;
            adrSantier = textBoxAdresa.Text;
            proiSantier = textBoxProiectant.Text;
            imgSantier = textBoxImagine.Text;
            manager = Convert.ToInt16(comboBoxSefSantier.SelectedValue.ToString());
            try
            {
                // daca nu sunt completate datele complete, eroare
                if (denSantier == "" || benSantier == "" || adrSantier == "" || proiSantier == "" || imgSantier == "")
                    throw new Exception("Completați toate datele!");
                Adaugare_DB.inregistrezSantierDB(denSantier, benSantier, adrSantier, proiSantier, Convert.ToInt16(manager), imgSantier);
                MessageBox.Show("Șantier adăugat!");
                //golim continutul obiectelor din interfata
                textBoxDenumire.Text = "";
                textBoxBeneficiar.Text = "";
                textBoxAdresa.Text = "";
                textBoxProiectant.Text = "";
                textBoxImagine.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);            
            }
        }

      
        
       
    }
}
