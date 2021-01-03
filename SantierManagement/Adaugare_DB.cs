using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient; //pt legatura cu baza de date

namespace SantierManagement
{
    class Adaugare_DB
    {
        static string connstr = "Data Source=localhost;UserId=root;database=santiermanagement";
        static MySqlConnection conn = new MySqlConnection(connstr);

        public static void inregistrezSantierDB(string denSantier, string benSantier, string adrSantier, string proiSantier, int manager, string imgSantier)
        {
            MySqlCommand cmdAddSantier = new MySqlCommand();
            cmdAddSantier.Connection = conn;
            cmdAddSantier.CommandText = "INSERT INTO santiere(denumire_santier, beneficiar, adresa, proiectant, idu, imagine) VALUES (@denumire, @beneficiar, @adresa, @proiectant, @idmanager, @imagine);";
            try
            {
                conn.Open();
                cmdAddSantier.Parameters.AddWithValue("@denumire", denSantier);
                cmdAddSantier.Parameters.AddWithValue("@beneficiar", benSantier);
                cmdAddSantier.Parameters.AddWithValue("@adresa", adrSantier);
                cmdAddSantier.Parameters.AddWithValue("@proiectant", proiSantier);
                cmdAddSantier.Parameters.AddWithValue("@idmanager", manager);
                cmdAddSantier.Parameters.AddWithValue("@imagine", imgSantier);
                cmdAddSantier.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;            
            }
            finally
            {
                conn.Close();            
            }        
        }

        public static void inregistrariMateriale(string denMat, string umMat, int pretMat, int furnizor)
        {
            MySqlCommand cmdAddMat = new MySqlCommand();
            cmdAddMat.Connection = conn;
            cmdAddMat.CommandText = "INSERT INTO materiale(denumire_mat, UM, pret_unitar, codfurnizor) VALUES (@den, @um, @pret, @furn);";
            try
            {
                conn.Open();
                cmdAddMat.Parameters.AddWithValue("@den", denMat);
                cmdAddMat.Parameters.AddWithValue("@um", umMat);
                cmdAddMat.Parameters.AddWithValue("@pret", pretMat);
                cmdAddMat.Parameters.AddWithValue("@furn", furnizor);
                cmdAddMat.ExecuteNonQuery();            
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }        
        }

        public static void inregistrariFurnizori(string denFurn, string adrFurn, string telFurn, string mailFurn)
        {
            MySqlCommand cmdAddFurn = new MySqlCommand();
            cmdAddFurn.Connection = conn;
            cmdAddFurn.CommandText = "INSERT INTO furnizori(denumire, adresa_furnizor, telefon, email) VALUES (@den, @adr, @tel, @mail);";
            try
            {
                conn.Open();
                cmdAddFurn.Parameters.AddWithValue("@den", denFurn);
                cmdAddFurn.Parameters.AddWithValue("@adr", adrFurn);
                cmdAddFurn.Parameters.AddWithValue("@tel", telFurn);
                cmdAddFurn.Parameters.AddWithValue("@mail", mailFurn);
                cmdAddFurn.ExecuteNonQuery();            
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();            
            }        
        }

        public static void inregistrariManopera(string numeMan, string prenumeMan, int codfctMan, int tarifMan)
        {
            MySqlCommand cmdAddMan = new MySqlCommand();
            cmdAddMan.Connection = conn;
            cmdAddMan.CommandText = "INSERT INTO angajati(nume, prenume, codfunctie, tarif_orar_man) VALUES (@num, @prenum, @codfct, @tarif);";
            try
            {
                conn.Open();
                cmdAddMan.Parameters.AddWithValue("@num", numeMan);
                cmdAddMan.Parameters.AddWithValue("@prenum", prenumeMan);
                cmdAddMan.Parameters.AddWithValue("@codfct", codfctMan);
                cmdAddMan.Parameters.AddWithValue("@tarif", tarifMan);
                cmdAddMan.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void inregistrariFunctie(string numeFct)
        {
            MySqlCommand cmdAddFct = new MySqlCommand();
            cmdAddFct.Connection = conn;
            cmdAddFct.CommandText = "INSERT INTO functii(denumire_functie) VALUES (@fct);";
            try
            {
                conn.Open();
                cmdAddFct.Parameters.AddWithValue("@fct", numeFct);                
                cmdAddFct.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void inregistrariUtilaj(string numeUt, string prodUt, int tarifUt)
        {
            MySqlCommand cmdAddUt = new MySqlCommand();
            cmdAddUt.Connection = conn;
            cmdAddUt.CommandText = "INSERT INTO utilaje(denumire_ut, producator, tarif_orar_ut) VALUES (@den, @prod, @tarif);";
            try
            {
                conn.Open();
                cmdAddUt.Parameters.AddWithValue("@den", numeUt);
                cmdAddUt.Parameters.AddWithValue("@prod", prodUt);
                cmdAddUt.Parameters.AddWithValue("@tarif", tarifUt);
                cmdAddUt.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void inregistrariTransport(string numeTr, int valTr)
        {
            MySqlCommand cmdAddTr = new MySqlCommand();
            cmdAddTr.Connection = conn;
            cmdAddTr.CommandText = "INSERT INTO transport(denumire_mat_tr,valoare_tr) VALUES (@den, @val);";
            try
            {
                conn.Open();
                cmdAddTr.Parameters.AddWithValue("@den", numeTr);                
                cmdAddTr.Parameters.AddWithValue("@val", valTr);
                cmdAddTr.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
