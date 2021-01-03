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
    public partial class ModMat : Form
    {
        static MySqlConnection conn = new MySqlConnection("DataSource=localhost; UserID=root; database=santiermanagement");
        MySqlDataAdapter adapt; 
        DataTable matDT = new DataTable(); 
        MySqlCommandBuilder cb;

        private void ModMat_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                adapt = new MySqlDataAdapter("SELECT cod_mat, denumire_mat AS Denumire, UM AS 'Unitatea de masura', pret_unitar AS Pret FROM materiale ORDER BY cod_mat ASC", conn);
                matDT.Clear();
                adapt.Fill(matDT);
                dataGridViewMat.DataSource = matDT;
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
                adapt.Update(matDT); 
                MessageBox.Show("Am modificat datele"); 
                conn.Close(); 
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        public ModMat()
        {
            InitializeComponent();
        }


               
    }
}
