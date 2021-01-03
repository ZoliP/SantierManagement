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
    public partial class ModTr : Form
    {
        static MySqlConnection conn = new MySqlConnection("DataSource=localhost; UserID=root; database=santiermanagement");
        MySqlDataAdapter adapt;
        DataTable trDT = new DataTable();
        MySqlCommandBuilder cb;

        private void ModTr_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                adapt = new MySqlDataAdapter("SELECT cod_tr, denumire_mat_tr AS 'Denumirea marfrei transportate', valoare_tr AS 'Pret transport' FROM transport ORDER BY cod_tr ASC", conn);
                trDT.Clear();
                adapt.Fill(trDT);
                dataGridViewTr.DataSource = trDT;
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
                adapt.Update(trDT);
                MessageBox.Show("Am modificat datele");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ModTr()
        {
            InitializeComponent();
        }

    }
}
