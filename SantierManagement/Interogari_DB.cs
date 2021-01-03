using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient; // pentru legatura cu baza de date
using System.Data; // pentru DataTable
using System.Windows.Forms;

namespace SantierManagement
{
    class Interogari_DB
    {
        static string connstr = "Data Source=localhost;UserId=root;database=santiermanagement";
        static MySqlConnection conn = new MySqlConnection(connstr);

        public static DataTable selectezFurnizor()
        { 
            // aducem din baza de date santiermanagement date din tabelul furnizori
            MySqlCommand comFurnizor = new MySqlCommand();
            comFurnizor.Connection = conn;
            comFurnizor.CommandText = "SELECT * FROM furnizori ORDER BY denumire ASC";
            MySqlDataAdapter furnAdapt = new MySqlDataAdapter(comFurnizor);
            DataTable furnizoriDT = new DataTable();
            try
            {
                conn.Open();
                furnAdapt.Fill(furnizoriDT);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();            
            }
            return furnizoriDT;        
        }

        public static DataTable selectezFunctii()
        {
            // aducem din baza de date santiermanagement date din tabelul functii
            MySqlCommand comFunctii = new MySqlCommand();
            comFunctii.Connection = conn;
            comFunctii.CommandText = "SELECT * FROM functii ORDER BY denumire_functie ASC";
            MySqlDataAdapter funcAdapt = new MySqlDataAdapter(comFunctii);
            DataTable functiiDT = new DataTable();
            try
            {
                conn.Open();
                funcAdapt.Fill(functiiDT);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return functiiDT;
        }
       
        public static string caut_User(string u, string p)
        {
            //   -- Operatia de gasire --
            // Cautam in baza de date santiermanagement combinatia user+parola
            // transmisa prin parametrii: (string u, string p)
            MySqlCommand comUser = new MySqlCommand();
            comUser.Connection = conn;
            comUser.CommandText = "SELECT denumire_rol FROM utilizatori join roluri on idrol = id_rol where username = @paramUser and parola = @paramParola";
            comUser.Parameters.AddWithValue("@paramUser", u);
            comUser.Parameters.AddWithValue("@paramParola", p);
            string rol = "";
            try
            {
                conn.Open();
                MySqlDataReader readerUser = comUser.ExecuteReader();
                //  Daca a fost gasita o inregistrare in baza de date - preluam denumirea rolului 
                if (readerUser.Read())
                {
                    rol = readerUser["denumire_rol"].ToString();
                }
                //  Golim parametrii folositi de comUser pentru a-i putea   
                // reutiliza la un apel urmator al metodei: caut_user()
                comUser.Parameters.Clear();
            }
            catch (Exception)
            {
                //  Aruncam exceptia in Form1.cs (modulul apelant) 
                throw;
            }
            finally
            {
                //  Inchidem conexiunea cu baza de date 
                conn.Close();
            }
            return rol;
        }

        // pentru a afisa pe prima pagina numele caruia s-a conectat
        public static string userConectat(string u, string p, out int idConectat)
        {
            MySqlCommand comcon = new MySqlCommand();
            comcon.Connection = conn;                                  //JOIN santiere ON idu = id_u 
            comcon.CommandText = "SELECT nume_prenume,id_u FROM utilizatori  where username = @paramUser and parola = @paramParola";
            comcon.Parameters.AddWithValue("@paramUser", u);
            comcon.Parameters.AddWithValue("@paramParola", p);
            string numeConectat = "";
            idConectat = 0;
            try
            {
                conn.Open();
                MySqlDataReader readerConectat = comcon.ExecuteReader();
                if (readerConectat.Read())
                {
                    numeConectat = readerConectat["nume_prenume"].ToString();
                    idConectat = Convert.ToInt32( readerConectat["id_u"].ToString());
                    //return numeConectat;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();            
            }                        
            return numeConectat;             
        }


        public static DataTable selectezSantiere(int idCurentPrim,  int idCurentUltim, int dir, int idConectat)
        {
            // operatia de interogare
            MySqlCommand comSantiere = new MySqlCommand();
            comSantiere.Connection = conn;
            MySqlDataAdapter santiereAdapter = new MySqlDataAdapter(comSantiere);
            DataTable santiereDT = new DataTable();
            //MessageBox.Show(idConectat+"--" + idCurentUltim);
            if (dir == 1)
            {
                //cautam urmatoarele 3 santiere de dupa ultimul cod_santier al filmului afisat deja in ordine crescatoare a cod_santier (in tabela santiere)
                comSantiere.CommandText = "SELECT cod_santier, s.denumire_santier AS denSantier, s.beneficiar AS benSantier, s.adresa AS adrSantier, s.proiectant AS proiSantier, imagine FROM santiere s JOIN utilizatori u ON idu = id_u WHERE cod_santier > @paramID AND idu = @paramIDC ORDER BY cod_santier ASC LIMIT 3";
                comSantiere.Parameters.AddWithValue("@paramID", idCurentUltim);
                comSantiere.Parameters.AddWithValue("@paramIDC", idConectat);
            }
            else
            {
                // cautam cele 3 filme de inaintea primului cod_santier afisat deja  le obtinem in ordine descrescatoare a cod_santier si le includem intr-o alta comanda SELECT 
                // care sa le sorteze in ordinea crescatoare a cod_santier (in tabela santiere)
                comSantiere.CommandText = "SELECT * FROM ( SELECT cod_santier, s.denumire_santier AS denSantier, s.beneficiar AS benSantier, s.adresa AS adrSantier, s.proiectant AS proiSantier, imagine FROM santiere s JOIN utilizatori u ON idu = id_u WHERE cod_santier < @paramID AND idu = @paramIDC ORDER BY cod_santier DESC LIMIT 3) a ORDER BY cod_santier ASC";
                comSantiere.Parameters.AddWithValue("@paramID", idCurentPrim);
                comSantiere.Parameters.AddWithValue("@paramIDC", idConectat);
            }
            try
            {
                conn.Open();
                santiereAdapter.Fill(santiereDT);
            }
            catch (Exception)
            {
                //aruncam exceptia in Home.cs - modulul apelant
                throw;
            }
            finally
            {
                //  Curatam parametri comenzii comSantiere pentru a-i putea
                // reutiliza la un apel urmator al metodei: caut_santiere()
                comSantiere.Parameters.Clear();
                //  Inchidem conexiunea cu baza de date
                conn.Close();
            }
            return santiereDT;
        }

        public static DataTable selectezAdminSantiere(int idCurentPrimA, int idCurentUltimA, int dir)
        {
            // operatia de interogare
            MySqlCommand comSantiere = new MySqlCommand();
            comSantiere.Connection = conn;
            MySqlDataAdapter santiereAdapterA = new MySqlDataAdapter(comSantiere);
            DataTable santiereDTA = new DataTable();           
            if (dir == 1)
            {
                //cautam urmatoarele 3 santiere de dupa ultimul cod_santier al filmului afisat deja in ordine crescatoare a cod_santier (in tabela santiere)
                comSantiere.CommandText = "SELECT cod_santier, denumire_santier, beneficiar, adresa, proiectant, imagine, nume_prenume FROM santiere JOIN utilizatori ON idu = id_u WHERE cod_santier > @paramID ORDER BY cod_santier ASC LIMIT 3";
                comSantiere.Parameters.AddWithValue("@paramID", idCurentUltimA);       
            }
            else
            {
                // cautam cele 3 filme de inaintea primului cod_santier afisat deja  le obtinem in ordine descrescatoare a cod_santier si le includem intr-o alta comanda SELECT 
                // care sa le sorteze in ordinea crescatoare a cod_santier (in tabela santiere)
                comSantiere.CommandText = "SELECT * FROM ( SELECT cod_santier, denumire_santier, beneficiar, adresa, proiectant, imagine, nume_prenume FROM santiere JOIN utilizatori ON idu = id_u WHERE cod_santier < @paramID ORDER BY cod_santier DESC LIMIT 3) a ORDER BY cod_santier ASC";
                comSantiere.Parameters.AddWithValue("@paramID", idCurentPrimA);
            }
            try
            {
                conn.Open();
                santiereAdapterA.Fill(santiereDTA);
            }
            catch (Exception)
            {
                //aruncam exceptia in Home.cs - modulul apelant
                throw;
            }
            finally
            {
                //  Curatam parametri comenzii comSantiere pentru a-i putea
                // reutiliza la un apel urmator al metodei: caut_santiere()
                comSantiere.Parameters.Clear();
                //  Inchidem conexiunea cu baza de date
                conn.Close();
            }
            return santiereDTA;
        }

        public static DataTable selectezSefSantier()
        {
            // aducem din baza de date santiermanagement date din tabelul materiale
            MySqlCommand comSefSant = new MySqlCommand();
            comSefSant.Connection = conn;
            comSefSant.CommandText = "SELECT id_u, nume_prenume FROM utilizatori ORDER BY nume_prenume ASC";
            MySqlDataAdapter sefSantAdapt = new MySqlDataAdapter(comSefSant);
            DataTable sefSantDT = new DataTable();
            try
            {
                conn.Open();
                sefSantAdapt.Fill(sefSantDT);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return sefSantDT;
        }

        public static DataTable selectezSantiere_Alocare(int idConectat)
        {
            // aducem din baza de date santiermanagement date din tabelul materiale
            MySqlCommand comAlocSant = new MySqlCommand();
            comAlocSant.Connection = conn;
            comAlocSant.CommandText = "SELECT cod_santier, CONCAT (denumire_santier,', Beneficiar: ', beneficiar, ', Adresa: ', adresa) AS informatiiSantier FROM santiere JOIN utilizatori ON idu = id_u WHERE idu = @paramID ORDER BY denumire_santier ASC";
            comAlocSant.Parameters.AddWithValue("@paramID", idConectat);
            MySqlDataAdapter alocareSantiereAdapt = new MySqlDataAdapter(comAlocSant);
            DataTable alocareSantiereDT = new DataTable();
            try
            {
                conn.Open();
                alocareSantiereAdapt.Fill(alocareSantiereDT);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return alocareSantiereDT;
        }

        public static DataTable selectezMateriale()
        {
            // aducem din baza de date santiermanagement date din tabelul materiale
            MySqlCommand comMateriale = new MySqlCommand();
            comMateriale.Connection = conn;
            comMateriale.CommandText = "SELECT cod_mat, CONCAT (materiale.denumire_mat, ', ', materiale.pret_unitar, ' lej / ', materiale.UM, ', furnizor: ', furnizori.denumire) AS informatiiMat FROM materiale, furnizori WHERE codfurnizor =cod_furnizor ORDER BY denumire_mat ASC";
            MySqlDataAdapter materialeAdapt = new MySqlDataAdapter(comMateriale);
            DataTable materialeDT = new DataTable();
            try
            {
                conn.Open();
                materialeAdapt.Fill(materialeDT);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return materialeDT;
        }

        public static DataTable selectezManopera()
        {
            // aducem din baza de date santiermanagement date din tabelul materiale
            MySqlCommand comManopera = new MySqlCommand();
            comManopera.Connection = conn;
            comManopera.CommandText = "SELECT cod_man, CONCAT (angajati.nume, ' ', angajati.prenume, ', ', functii.denumire_functie) AS informatiiMan FROM angajati, functii WHERE codfunctie = cod_functie ORDER BY nume ASC";
            MySqlDataAdapter manoperaAdapt = new MySqlDataAdapter(comManopera);
            DataTable manoperaDT = new DataTable();
            try
            {
                conn.Open();
                manoperaAdapt.Fill(manoperaDT);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return manoperaDT;
        }

        public static DataTable selectezUtilaj()
        {
            // aducem din baza de date santiermanagement date din tabelul materiale
            MySqlCommand comUtilaj = new MySqlCommand();
            comUtilaj.Connection = conn;
            comUtilaj.CommandText = "SELECT cod_ut, denumire_ut FROM utilaje ORDER BY denumire_ut ASC";
            MySqlDataAdapter utilajAdapt = new MySqlDataAdapter(comUtilaj);
            DataTable utilajDT = new DataTable();
            try
            {
                conn.Open();
                utilajAdapt.Fill(utilajDT);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return utilajDT;
        }

        public static DataTable selectezTransport()
        {
            // aducem din baza de date santiermanagement date din tabelul materiale
            MySqlCommand comTransport = new MySqlCommand();
            comTransport.Connection = conn;
            comTransport.CommandText = "SELECT cod_tr, denumire_mat_tr FROM transport ORDER BY denumire_mat_tr ASC";
            MySqlDataAdapter transportAdapt = new MySqlDataAdapter(comTransport);
            DataTable transportDT = new DataTable();
            try
            {
                conn.Open();
                transportAdapt.Fill(transportDT);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return transportDT;
        }

        public static DataTable selectezSantiereAfisareResurse(int idConectat)
        {
            // aducem din baza de date santiermanagement date din tabelul materiale
            MySqlCommand comSantAfisRes = new MySqlCommand();
            comSantAfisRes.Connection = conn;
            comSantAfisRes.CommandText = "SELECT cod_santier, CONCAT (denumire_santier,', Beneficiar: ', beneficiar, ', Adresa: ', adresa) AS informatiiSantier FROM santiere JOIN utilizatori ON idu = id_u WHERE idu = @paramID ORDER BY denumire_santier ASC";
            comSantAfisRes.Parameters.AddWithValue("@paramID", idConectat);
            MySqlDataAdapter santiereAfisResAdapt = new MySqlDataAdapter(comSantAfisRes);
            DataTable santiereAfisResDT = new DataTable();
            try
            {
                conn.Open();
                santiereAfisResAdapt.Fill(santiereAfisResDT);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return santiereAfisResDT;
        }

        public static DataTable selectezResurseMaterial(int idSantier)
        {            
            MySqlCommand afisMaterial = new MySqlCommand();
            afisMaterial.Connection = conn;
            afisMaterial.CommandText = "SELECT cod_misc_mat, CONCAT (materiale.denumire_mat, ', ',miscari_materiale.cantitate_mat,' ', materiale.UM, ', ',miscari_materiale.valoare_mat, ' lej') AS infoAfisMat FROM miscari_materiale, materiale WHERE codmat = cod_mat AND codsantier = @paramIDS ORDER BY data_misc_mat ASC";            
            afisMaterial.Parameters.AddWithValue("@paramIDS", idSantier);
            //MessageBox.Show(" db "+ idSantier);
            MySqlDataAdapter afisMatAdapt = new MySqlDataAdapter(afisMaterial);
            DataTable afisMatDT = new DataTable();
            try
            {
                conn.Open();
                afisMatAdapt.Fill(afisMatDT);
                //afisMaterial.Parameters.Clear();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return afisMatDT;                
        }

        public static DataTable selectezResurseManopera(int idSantier)
        {
            MySqlCommand afisMan = new MySqlCommand();
            afisMan.Connection = conn;
            afisMan.CommandText = "SELECT cod_misc_man, CONCAT (angajati.nume, ' ', angajati.prenume, ', functia:', functii.denumire_functie, ', cost: ', miscari_manopera.valoare_man, ' lej') AS infoMan FROM miscari_manopera, angajati, functii WHERE codman = cod_man AND cod_functie =codfunctie AND codsantier = @paramIDS ORDER BY data_inceput_man ASC"; 
            afisMan.Parameters.AddWithValue("@paramIDS", idSantier);            
            MySqlDataAdapter afisManAdapt = new MySqlDataAdapter(afisMan);
            DataTable afisManDT = new DataTable();
            try
            {
                conn.Open();
                afisManAdapt.Fill(afisManDT);
                //afisMaterial.Parameters.Clear();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return afisManDT;
        }

        public static DataTable selectezResurseUtilaj(int idSantier)
        {
            MySqlCommand afisUt = new MySqlCommand();
            afisUt.Connection = conn;
            afisUt.CommandText = "SELECT cod_misc_ut, CONCAT (utilaje.denumire_ut,', valoare: ', miscari_utilaje.valoare_ut, ' lej') AS infoUt FROM miscari_utilaje, utilaje WHERE codut = cod_ut AND codsantier = @paramIDS ORDER BY data_inceput_ut ASC"; 
            afisUt.Parameters.AddWithValue("@paramIDS", idSantier);           
            MySqlDataAdapter afisUtAdapt = new MySqlDataAdapter(afisUt);
            DataTable afisUtDT = new DataTable();
            try
            {
                conn.Open();
                afisUtAdapt.Fill(afisUtDT);
                //afisMaterial.Parameters.Clear();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return afisUtDT;
        }

        public static DataTable selectezResurseTransport(int idSantier)
        {
            MySqlCommand afisTr = new MySqlCommand();
            afisTr.Connection = conn;
            afisTr.CommandText = "SELECT cod_misc_tr, CONCAT (transport.denumire_mat_tr, ', valoare: ', transport.valoare_tr, ' lej') AS infoTr FROM miscari_transport, transport WHERE codtr = cod_tr AND codsantier = @paramIDS";// ORDER BY data_misc_mat ASC";
            afisTr.Parameters.AddWithValue("@paramIDS", idSantier);
            //MessageBox.Show(" db "+ idSantier);
            MySqlDataAdapter afisTrAdapt = new MySqlDataAdapter(afisTr);
            DataTable afisTrDT = new DataTable();
            try
            {
                conn.Open();
                afisTrAdapt.Fill(afisTrDT);
                //afisMaterial.Parameters.Clear();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return afisTrDT;
        }
       
    }
}
