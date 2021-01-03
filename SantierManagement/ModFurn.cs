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
    public partial class ModFurn : Form
    {
        static MySqlConnection conn = new MySqlConnection("DataSource=localhost; UserID=root; database=santiermanagement");
        MySqlDataAdapter adapt;
        DataTable furnDT = new DataTable();
        MySqlCommandBuilder cb;

        private void ModFurn_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                adapt = new MySqlDataAdapter("SELECT cod_furnizor, denumire AS Denumire, adresa_furnizor AS 'Adresa', telefon AS Telefon, email AS 'E-mail' FROM furnizori ORDER BY cod_furnizor ASC", conn);
                furnDT.Clear();
                adapt.Fill(furnDT);
                dataGridViewFurn.DataSource = furnDT;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonModificare_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cb = new MySqlCommandBuilder(adapt);
                adapt.Update(furnDT);
                MessageBox.Show("Am modificat datele");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ModFurn()
        {
            InitializeComponent();
        }
    }
}
