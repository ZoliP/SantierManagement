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
    public partial class Home : Form
    {
        int login;
        int idCurentPrim, idCurentUltim;
        int idCurentPrimA, idCurentUltimA;
        int idConectat, idSantier;        
        int randuriSantiereDT, randuriSantiereDTA; // nr de santiere adus, foate avea valoarea 0,1,2,3
        DataTable santiereDT, santiereDTA; //"recipientul" pentru. santiere aduse din baza de date
        DataRow santiereDR, santiereDRA; // va pastra pe rand cate o inregistrare - santier- din DataTable

        private void reseteazaSantiere()
        {
            pictureBox1.Image = null;
            textBox1.Text = "";
            pictureBox2.Image = null;
            textBox2.Text = "";
            pictureBox3.Image = null;
            textBox3.Text = "";
        }

        public void completeazaSantiere(ref int idCurentPrim, ref int idCurentUltim, int dir, int idConectat)
        {
            try 
            {
                santiereDT = Interogari_DB.selectezSantiere(idCurentPrim, idCurentUltim, dir, idConectat);
                randuriSantiereDT = santiereDT.Rows.Count;
                //MessageBox.Show("" + randuriSantiereDT + idCurentUltim);
                if (randuriSantiereDT > 0)
                {
                    reseteazaSantiere();
                    santiereDR = santiereDT.Rows[0];
                    idCurentPrim = Convert.ToInt32(santiereDR["cod_santier"]);
                    idCurentUltim = Convert.ToInt32(santiereDR["cod_santier"]);
                    textBox1.Text = "Șantier: " + santiereDR["denSantier"] + Environment.NewLine + "Beneficiar: " + santiereDR["benSantier"] + Environment.NewLine + "Adresa: " + santiereDR["adrSantier"] + "Proiectant: " + santiereDR["proiSantier"];
                    pictureBox1.Image = Image.FromFile("Poze\\" + santiereDR["imagine"]);
                    pictureBox1.Visible = true;

                    if (randuriSantiereDT > 1)
                    {
                        santiereDR = santiereDT.Rows[1];
                        idCurentUltim = Convert.ToInt32(santiereDR["cod_santier"]);
                        textBox2.Text = "Șantier: " + santiereDR["denSantier"] + Environment.NewLine + "Beneficiar: " + santiereDR["benSantier"] + Environment.NewLine + "Adresa: " + santiereDR["adrSantier"] + Environment.NewLine + "Proiectant: " + santiereDR["proiSantier"];
                        pictureBox2.Image = Image.FromFile("Poze\\" + santiereDR["imagine"]);
                        pictureBox2.Visible = true;

                        if (randuriSantiereDT > 2)
                        {
                            santiereDR = santiereDT.Rows[2];
                            idCurentUltim = Convert.ToInt32(santiereDR["cod_santier"]);
                            textBox3.Text = "Șantier: " + santiereDR["denSantier"] + Environment.NewLine + "Beneficiar: " + santiereDR["benSantier"] + Environment.NewLine + "Adresa: " + santiereDR["adrSantier"] + Environment.NewLine + "Proiectant: " + santiereDR["proiSantier"];
                            pictureBox3.Image = Image.FromFile("Poze\\" + santiereDR["imagine"]);
                            pictureBox3.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

        public void completezAdminSantiere(ref int idCurentPrimA, ref int idCurentUltimA, int dir)
        {
            try
            {
                santiereDTA = Interogari_DB.selectezAdminSantiere(idCurentPrimA, idCurentUltimA, dir);
                randuriSantiereDTA = santiereDTA.Rows.Count;
                //MessageBox.Show("" + randuriSantiereDTA +" "+ idCurentUltimA);
                if (randuriSantiereDTA > 0)
                {
                    reseteazaSantiere();
                    santiereDRA = santiereDTA.Rows[0];
                    idCurentPrimA = Convert.ToInt32(santiereDRA["cod_santier"]);
                    idCurentUltimA = Convert.ToInt32(santiereDRA["cod_santier"]);
                    textBox1.Text = "Șantier: " + santiereDRA["denumire_santier"] + Environment.NewLine + "Beneficiar: " + santiereDRA["beneficiar"] + Environment.NewLine + "Adresa: " + santiereDRA["adresa"] + Environment.NewLine + "Proiectant: " + santiereDRA["proiectant"] + Environment.NewLine + Environment.NewLine + "Șef de șantier: " + santiereDRA["nume_prenume"];
                    pictureBox1.Image = Image.FromFile("Poze\\" + santiereDRA["imagine"]);
                    pictureBox1.Visible = true;

                    if (randuriSantiereDTA > 1)
                    {
                        santiereDRA = santiereDTA.Rows[1];
                        idCurentUltimA = Convert.ToInt32(santiereDRA["cod_santier"]);
                        textBox2.Text = "Șantier: " + santiereDRA["denumire_santier"] + Environment.NewLine + "Beneficiar: " + santiereDRA["beneficiar"] + Environment.NewLine + "Adresa: " + santiereDRA["adresa"] + Environment.NewLine + "Proiectant: " + santiereDRA["proiectant"] + Environment.NewLine + Environment.NewLine + "Șef de șantier: " + santiereDRA["nume_prenume"];
                        pictureBox2.Image = Image.FromFile("Poze\\" + santiereDRA["imagine"]);
                        pictureBox2.Visible = true;

                        if (randuriSantiereDTA > 2)
                        {
                            santiereDRA = santiereDTA.Rows[2];
                            idCurentUltimA = Convert.ToInt32(santiereDRA["cod_santier"]);
                            textBox3.Text = "Șantier: " + santiereDRA["denumire_santier"] + Environment.NewLine + "Beneficiar: " + santiereDRA["beneficiar"] + Environment.NewLine + "Adresa: " + santiereDRA["adresa"] + Environment.NewLine + "Proiectant: " + santiereDRA["proiectant"] + Environment.NewLine + Environment.NewLine + "Șef de șantier: " + santiereDRA["nume_prenume"];
                            pictureBox3.Image = Image.FromFile("Poze\\" + santiereDRA["imagine"]);
                            pictureBox3.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       

                                     
        public Home(int id_Conectat, string numeConectat, int loginC)
        {

            //parametrul id_Conectat aduce valoarea din Form1, Button LogIn, interogarea userConectat 
            InitializeComponent();         
            idCurentPrim = 0;
            idCurentUltim = 0;
            idCurentPrimA = idCurentUltimA = 0;
            idConectat = id_Conectat;
            login = loginC;

            if (login == 1)
            {
                labelTitlu.Text = "Logat ca administrator. Șantiere active";                
                completezAdminSantiere(ref idCurentPrimA, ref idCurentUltimA, 1);                
            }
            else
            {
                labelTitlu.Text += numeConectat;                
                santierToolStripMenuItem.Visible = false;
                furnizorToolStripMenuItem.Visible = false;
                funcțiiToolStripMenuItem.Visible = false;
                furnizorToolStripMenuItem1.Visible = false;
                completeazaSantiere(ref idCurentPrim, ref idCurentUltim, 1, idConectat);
            }

            labelDate.Text += DateTime.Now.ToShortDateString();

           // completeazaSantiere(ref idCurentPrim, ref idCurentUltim, 1, idConectat);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            
            if (login == 1)
            {               
                completezAdminSantiere(ref idCurentPrimA, ref idCurentUltimA, -1);
            }
            else
            {               
                completeazaSantiere(ref idCurentPrim, ref idCurentUltim, -1, idConectat);
            }
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {           
            if (login == 1)
                completezAdminSantiere(ref idCurentPrimA, ref idCurentUltimA, 1);
            else
                completeazaSantiere(ref idCurentPrim, ref idCurentUltim, 1, idConectat);
        }

        private void santierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSantier sant = new AddSantier();
            sant.ShowDialog();
        }

        private void materialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMaterial material = new AddMaterial();
            material.ShowDialog();
        }

        private void forțăDeMuncăToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddWorker manopera = new AddWorker();
            manopera.ShowDialog();
        }

        private void utilajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTool utilaj = new AddTool();
            utilaj.ShowDialog();
        }

        private void transportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTransport transport = new AddTransport();
            transport.ShowDialog();
        }

        private void furnizorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDealer furnizor = new AddDealer();
            furnizor.ShowDialog();
        }

        private void funcțiiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFunction functii = new AddFunction();
            functii.ShowDialog();
        }

        private void ieșireToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            Application.Exit();
        }

        private void materialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AlocareMaterial alMat = new AlocareMaterial(idConectat);
            alMat.ShowDialog();
        }

        private void forțăDeMuncăToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AlocareManopera alMan = new AlocareManopera(idConectat);
            alMan.ShowDialog();
        }

        private void utilajToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AlocareUtilaj alUt = new AlocareUtilaj(idConectat);
            alUt.ShowDialog();
        }

        private void transportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AlocareTransport alTr = new AlocareTransport(idConectat);
            alTr.ShowDialog();
        }

        private void rapoarteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfisareResurse afisResurse = new AfisareResurse(idConectat, idSantier);
            afisResurse.ShowDialog();
        }

        private void materialToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ModMat modificMat = new ModMat();
            modificMat.ShowDialog();
        }

        private void forțăDeMuncăToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ModMan modificMan = new ModMan();
            modificMan.ShowDialog();
        }

        private void utilajToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ModUt modificUt = new ModUt();
            modificUt.ShowDialog();           
        }

        private void transportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ModTr modificTr = new ModTr();
            modificTr.ShowDialog();
        }

        private void furnizorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ModFurn modificFurnizor = new ModFurn();
            modificFurnizor.ShowDialog();

        }
          
    }
}
