using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;  //  Pentru legatura cu baza de date 
using System.Data;  // Pentru DataTable 
using System.Collections;  //  Pentru ArrayList

namespace SantierManagement
{
    class Alocari_DB
    {
        static string connstr = "Data Source=localhost;UserId=root;database=santiermanagement";
        static MySqlConnection conn = new MySqlConnection(connstr);

        public static void inregistrez_alocareMat_in_BD(int codSantier, ArrayList codMateriale, int cantitateMat, int valMat)
        {
            conn.Open(); 
            DateTime azi = DateTime.Now;
            MySqlCommand alocMat = new MySqlCommand("INSERT INTO miscari_materiale (cod_santier, cod_mat, cantitate_mat, valoare_mat, data_misc_mat) VALUES (@idsant, @idmat, @cantmat, null, CAST(@data_misc_mat as datetime))", conn);
            //MySqlCommand scadFilme = new MySqlCommand("UPDATE filme SET nrdisponibile=nrdisponibile-1 WHERE idf=@idf", conn);
            // Instantiez si incep o tranzactie
            MySqlTransaction tx = conn.BeginTransaction(); 
            try
            {
                // Atasez cele doua comenzi adaugImpr si scadFilme tranzactiei tx
                alocMat.Transaction = tx;
                //scadFilme.Transaction = tx;
                foreach (int cod_miscMat in codMateriale)
                {
                    //  Adaug                    
                    alocMat.Parameters.AddWithValue("@idsant", codSantier);
                    alocMat.Parameters.AddWithValue("@idmat", cod_miscMat);
                    alocMat.Parameters.AddWithValue("@cantmat", cantitateMat);
                    alocMat.Parameters.AddWithValue("@valmat", valMat);
                    alocMat.ExecuteNonQuery();
                    //  Golim parametrii utilizati in comanda SQL pentru a-i putea reutiliza
                    alocMat.Parameters.Clear();
                    //scadFilme.Parameters.AddWithValue("@idf", idfi);
                    //scadFilme.ExecuteNonQuery();
                    //  Golim parametrii utilizati in comanda SQL pentru a-i putea reutiliza
                    //scadFilme.Parameters.Clear();
                }
                // Modificarile devin permanente
                tx.Commit();
            }
            catch (Exception)
            {
                //  Daca a aparut o eroare in timpul executiei vreuneia dintre operatiile asupra bazei de date
                // se vor anula si operatiile care au fost facute inaintea erorii
                tx.Rollback(); 
                throw;
            }  
            finally  
            {     
                //  Inchidem conexiunea cu baza de date  
                conn.Close(); 
            }
        } 
    }
}
