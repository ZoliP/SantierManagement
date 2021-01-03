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
    public partial class AddDealer : Form
    {
        string denFurn, adrFurn, telFurn, mailFurn;

        public AddDealer()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            denFurn = textBoxDenumire.Text;
            adrFurn = textBoxAdresa.Text;
            telFurn = textBoxTel.Text;
            mailFurn = textBoxMail.Text;
            try
            {
                if (denFurn == "" || adrFurn == "" || telFurn == "" || mailFurn == "")
                    throw new Exception("Date incomplete. Repetati!");
                Adaugare_DB.inregistrariFurnizori(denFurn, adrFurn, telFurn, mailFurn);
                MessageBox.Show("Furnizor nou adaugat");
                textBoxDenumire.Text = "";
                textBoxAdresa.Text = "";
                textBoxTel.Text = "";
                textBoxMail.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 



        }
    }
}
