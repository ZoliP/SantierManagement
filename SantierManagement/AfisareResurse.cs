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
    public partial class AfisareResurse : Form
    {
        DataTable santiereAfisResDT, afisMatDT, afisManDT, afisUt, afisTr;
        DataRow santiereAfisResDR;
        int idConectat, idSantier;

        private void completezComboboxSantiere_Alocare(int idConectat)
        {
            comboBoxSantier.Items.Clear();
            // Apelam metoda care interogheaza tabela santiere si depune rezultatul in: DataTable alocareSantiereDT
            santiereAfisResDT = Interogari_DB.selectezSantiereAfisareResurse(idConectat);
            santiereAfisResDR = santiereAfisResDT.NewRow();
            santiereAfisResDR["cod_santier"] = "0";
            santiereAfisResDR["informatiiSantier"] = "---- Selectati santierul ----";
            santiereAfisResDT.Rows.InsertAt(santiereAfisResDR, 0);   
            // Valoarea din coloana "cod_santier" se asociaza fiecarui item  
            // din comboBoxSantier dar nu se afiseaza in comboBoxSantier
            comboBoxSantier.ValueMember = "cod_santier";
            //denumirea santierului afisat in comboBoxSantier preluata din DataTable
            comboBoxSantier.DisplayMember = "informatiiSantier";
            // DataTable alocareSantiereDT este folosit ca sursa de date pentru comboBoxSantier
            comboBoxSantier.DataSource = santiereAfisResDT; 
         }

        public void completezListBox(int idSantier)
        {
            try
            {
                //MessageBox.Show("completezlistboxmateriale" + idSantier);
                afisMatDT = Interogari_DB.selectezResurseMaterial(idSantier);
                listBoxMaterial.DataSource = afisMatDT;
                listBoxMaterial.DisplayMember = "infoAfisMat";
                listBoxMaterial.ValueMember = "cod_misc_mat";

                afisManDT = Interogari_DB.selectezResurseManopera(idSantier);
                listBoxManopera.DataSource = afisManDT;
                listBoxManopera.ValueMember = "cod_misc_man";
                listBoxManopera.DisplayMember = "infoMan";

                afisUt = Interogari_DB.selectezResurseUtilaj(idSantier);
                listBoxUtilaje.DataSource = afisUt;
                listBoxUtilaje.ValueMember = "cod_misc_ut";
                listBoxUtilaje.DisplayMember = "infoUt";

                afisTr = Interogari_DB.selectezResurseTransport(idSantier);
                listBoxTransport.DataSource = afisTr;
                listBoxTransport.ValueMember = "cod_misc_tr";
                listBoxTransport.DisplayMember = "infoTr";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);            
            }           
        }
        
        private void comboBoxSantiere_SelectionChangeCommited(object sender, EventArgs e)
        {            
            try 
            {                
                idSantier = Convert.ToInt32(comboBoxSantier.SelectedValue.ToString());                
                completezListBox(idSantier);
            }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message);            
            }        
        }


        public AfisareResurse(int id_Conectat, int id_Santier)
        {
            InitializeComponent();            
            idConectat = id_Conectat;
            idSantier = id_Santier;
            completezComboboxSantiere_Alocare(idConectat);
            completezListBox(idSantier);
        }
    }
}
