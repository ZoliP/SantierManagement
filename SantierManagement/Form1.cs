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
    public partial class Form1 : Form

    {
        public static int idConectat;
        int login; // login =0 cand nu este logat nimeni, =1 pt. admin si =2 pt. angajat
        string userTastat, parolaTastata, user_role, numeConectat;

        private static void Creare_DB()
        {
            // Se creaza baza de date fara tabele
            // String-ul de conexiune contine Data Source=...(calea spre serverul de baze de date) 
            // dar nu contine denumirea nici unei baze de date
            MySqlConnection conn = new MySqlConnection("DataSource=localhost; UserID=root;");
            MySqlCommand cmd = new MySqlCommand("CREATE DATABASE santiermanagement;", conn);
            try
            {
                conn.Open();
                // Tratarea exceptiei pentru situatia in care deja exista baza de date creata
                cmd.ExecuteNonQuery();
                MessageBox.Show("Baza de date santiermanagement a fost creata");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

         private static void Creare_Tabele_Relatii() 
         {
             // Se creaza tabelele cu legatura dintre ele
             // String-ul de conexiune contine si database=videoteca...(calea spre baza de date creata prin metoda Creare_DB())
             MySqlConnection conn = new MySqlConnection("DataSource=localhost; UserID=root; database=santiermanagement");
             MySqlCommand cmd = new MySqlCommand("CREATE TABLE furnizori (cod_furnizor int auto_increment, denumire varchar(100) NOT NULL, adresa_furnizor varchar(100), telefon varchar(10), email varchar(50), PRIMARY KEY (cod_furnizor))", conn);
             try 
             { 
                 conn.Open();
                 cmd.ExecuteNonQuery();
                 MessageBox.Show("Tabelul Furnizori a fost creat");
                 // Am creat intai tabela-parinte 
                 cmd.CommandText = "CREATE TABLE materiale (cod_mat int auto_increment, denumire_mat varchar(50) NOT NULL, UM varchar(5), pret_unitar int, codfurnizor int, PRIMARY KEY (cod_mat), FOREIGN KEY (codfurnizor) REFERENCES furnizori(cod_furnizor))"; 
                 cmd.ExecuteNonQuery(); 
                 MessageBox.Show("Tabelul Materiale a fost creat"); 
                 //Pentru tabela-copil am stabilit si cheia straina (legatura spre tabelaparinte)
             } 
             catch (Exception ex) 
             {  
                 MessageBox.Show(ex.Message); 
             } 
             finally 
             {  
                 conn.Close();
             } 
         } 


        public Form1()
        {
            InitializeComponent();
            Creare_DB();
            Creare_Tabele_Relatii();
            
            login = 0;
            userTastat = parolaTastata = "";
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (login == 0)
                {
                    //Preluam user si parola, stergem eventualele spatii
                    //   de la inceputul si sfarsitul numelui utilizator 
                    userTastat = textBoxUsername.Text.Trim();
                    parolaTastata = textBoxPassword.Text;
                    if (userTastat == "") throw new Exception("Completați câmpul Username!");
                    if (parolaTastata == "") throw new Exception("Completați câmpul Password!");
                    // Cautam in baza de date DBvideoteca combinatia user+parola care au fost tastate
                    // Daca gasim o inregistrare ce corespunde: aducem din baza de date
                    //   denumirea rolului acelui user, altfel user_role ramane sirul vid ="" 
                    user_role = Interogari_DB.caut_User(userTastat, parolaTastata);
                    numeConectat = Interogari_DB.userConectat(userTastat, parolaTastata, out idConectat);
                    //MessageBox.Show(numeConectat + idConectat);
                    if (user_role == "admin")
                    {
                        // Daca rolul este de administrator ="admin"  are drepturi depline  
                        login = 1;
                        buttonLogIn.Text = "Log Out";
                        Home acasa = new Home(idConectat, numeConectat, login);
                        acasa.ShowDialog();
                    }
                    if (user_role == "angajat")
                    {
                        // Daca rolul este de administrator ="angajat"  are drepturi limitate  
                        login = 2;
                        buttonLogIn.Text = "Log Out";
                        Home acasa = new Home(idConectat, numeConectat, login);
                        acasa.ShowDialog();
                    }
                    if (login == 0)
                        throw new Exception("Username sau Parola incorecte");
                }
                else
                {
                    //  A fost apasat butonul log-out. Resetam controalele, ascundem meniul 
                    textBoxUsername.Text = "";
                    textBoxPassword.Text = "";

                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }      
                 
        }

        
    }
}
