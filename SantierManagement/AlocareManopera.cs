﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SantierManagement
{
    public partial class AlocareManopera : Form
    {
        DataTable manoperaDT, alocareSantiereDT;
        int idConectat;

        private void completezComboboxSantiere_Alocare(int idConectat)
        {
            comboBoxSantier.Items.Clear();
            // Apelam metoda care interogheaza tabela santiere si depune rezultatul in: DataTable alocareSantiereDT
            alocareSantiereDT = Interogari_DB.selectezSantiere_Alocare(idConectat);
            // DataTable alocareSantiereDT este folosit ca sursa de date pentru comboBoxSantier
            comboBoxSantier.DataSource = alocareSantiereDT;
            // Valoarea din coloana "cod_santier" se asociaza fiecarui item  
            // din comboBoxSantier dar nu se afiseaza in comboBoxSantier
            comboBoxSantier.ValueMember = "cod_santier";
            //denumirea santierului afisat in comboBoxSantier preluata din DataTable
            comboBoxSantier.DisplayMember = "informatiiSantier";
        }

        private void completezComboboxManopera_Alocare()
        {
            comboBoxMan.Items.Clear();
            manoperaDT = Interogari_DB.selectezManopera();
            comboBoxMan.DataSource = manoperaDT;
            comboBoxMan.ValueMember = "cod_man";
            comboBoxMan.DisplayMember = "informatiiMan";
        }
        public AlocareManopera(int id_Conectat)
        {
            InitializeComponent();
            idConectat = id_Conectat;
            completezComboboxSantiere_Alocare(idConectat);
            completezComboboxManopera_Alocare();

        }
    }
}
