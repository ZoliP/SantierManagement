using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SantierManagement
{
    public partial class ModMan : Form
    {

        static MySqlConnection conn = new MySqlConnection("DataSource=localhost; UserID=root; database=santiermanagement");
        MySqlDataAdapter adapt;
        DataTable manDT = new DataTable();
        MySqlCommandBuilder cb;  

        private void buttonModificare_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cb = new MySqlCommandBuilder(adapt);
                adapt.Update(manDT);
                MessageBox.Show("Am modificat datele");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ModMan_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                adapt = new MySqlDataAdapter("SELECT cod_man, nume AS Nume, prenume AS Prenume, tarif_orar_man AS 'Tarif orar' FROM angajati ORDER BY cod_man ASC", conn);
                manDT.Clear();
                adapt.Fill(manDT);
                dataGridViewMan.DataSource = manDT;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ModMan()
        {
            InitializeComponent();
        }
    }
}
