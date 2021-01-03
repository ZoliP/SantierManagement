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
    public partial class ModUt : Form
    {
        static MySqlConnection conn = new MySqlConnection("DataSource=localhost; UserID=root; database=santiermanagement");
        MySqlDataAdapter adapt;
        DataTable utDT = new DataTable();
        MySqlCommandBuilder cb;  

        private void buttonModificare_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cb = new MySqlCommandBuilder(adapt);
                adapt.Update(utDT);
                MessageBox.Show("Am modificat datele");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ModUt_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                adapt = new MySqlDataAdapter("SELECT cod_ut, denumire_ut AS Denumire, producator AS Producator, tarif_orar_ut AS 'Tarif orar' FROM utilaje ORDER BY cod_ut ASC", conn);
                utDT.Clear();
                adapt.Fill(utDT);
                dataGridViewUt.DataSource = utDT;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ModUt()
        {
            InitializeComponent();
        }
    }
}
