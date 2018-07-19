using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace projekt_8_3_vj.Models.DAL
{
    public class Repozitorij
    {
        string conString = ConfigurationManager.ConnectionStrings["sqlConnString"].ConnectionString;

        public List<PolaznikModel> GetPolaznike()
        {
            List<PolaznikModel> polaznici = new List<PolaznikModel>();

            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DohvatiPolaznike";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PolaznikModel polaznik = new PolaznikModel(true);
                        polaznik.IdPolaznik = int.Parse(reader["IdPolaznik"].ToString());
                        polaznik.Ime = reader["Ime"].ToString();
                        polaznik.Prezime = reader["Prezime"].ToString();
                        polaznik.Email = reader["Email"].ToString();
                        if(!string.IsNullOrEmpty(reader["IdGrada"].ToString()))
                        {
                            polaznik.IdGrad = int.Parse(reader["IdGrada"].ToString());
                        }

                        polaznici.Add(polaznik);
                    }
                }
            }

            return polaznici;
        }

        public PolaznikModel GetPolaznik(int IdPolaznik)
        {
            PolaznikModel polaznik = new PolaznikModel(true);
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DohvatiPolaznika";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdPolaznika", IdPolaznik);
                //cmd.Parameters["IdPolaznika"].Value = IdPolaznik;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        polaznik.IdPolaznik = int.Parse(reader["IdPolaznik"].ToString());
                        polaznik.Ime = reader["Ime"].ToString();
                        polaznik.Prezime = reader["Prezime"].ToString();
                        polaznik.Email = reader["Email"].ToString();
                        polaznik.IdGrad = int.Parse(reader["IdGrada"].ToString());

                    }
                }

                return polaznik;
            }
        }

        public int KreirajPolaznika(PolaznikModel polaznik)
        {
            int scoopeIdentity;
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "KreirajPolaznika";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Ime",polaznik.Ime);
                //cmd.Parameters["Ime"].Value = polaznik.Ime;
                cmd.Parameters.AddWithValue("Prezime", polaznik.Prezime);
                //cmd.Parameters["Prezime"].Value = polaznik.Prezime;
                cmd.Parameters.AddWithValue("Email", polaznik.Email);
                //cmd.Parameters["Email"].Value = polaznik.Email;
                cmd.Parameters.AddWithValue("IdGrad", polaznik.IdGrad);
                //cmd.Parameters["IdGrad"].Value = polaznik.IdGrad;

                scoopeIdentity = int.Parse(cmd.ExecuteScalar().ToString());
            }

            return scoopeIdentity;
        }

        public bool IzbrisiPolaznika(int IdPolaznik)
        {
            bool obrisan;

            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "IzbrisiPolaznika";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdPolaznika", IdPolaznik);
                //cmd.Parameters["IdPolaznika"].Value = IdPolaznik;

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    obrisan = true;
                }
                else
                {
                    obrisan = false;
                }

            }
            return obrisan;
        }

        public void UrediPolaznika(PolaznikModel polaznik)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UrediPolaznika";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdPolaznika", polaznik.IdPolaznik);
                //cmd.Parameters["IdPolaznika"].Value = polaznik.IdPolaznik;
                cmd.Parameters.AddWithValue("Ime", polaznik.Ime);
                //cmd.Parameters["Ime"].Value = polaznik.Ime;
                cmd.Parameters.AddWithValue("Prezime", polaznik.Prezime);
                //cmd.Parameters["Prezime"].Value = polaznik.Prezime;
                cmd.Parameters.AddWithValue("Email", polaznik.Email);
                //cmd.Parameters["Email"].Value = polaznik.Email;
                cmd.Parameters.AddWithValue("IdGrad", polaznik.IdGrad);

                cmd.ExecuteNonQuery();
            }
        }

        public List<TecajModel> GetTecaje()
        {
            List<TecajModel> tecajevi = new List<TecajModel>();

            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DohvatiTecajeve";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TecajModel tecaj = new TecajModel();
                        tecaj.IdTecaj = int.Parse(reader["IdTecaj"].ToString());
                        tecaj.Naziv = reader["Naziv"].ToString();
                        tecaj.Opis = reader["Opis"].ToString();

                        tecajevi.Add(tecaj);
                    }
                }
            }

            return tecajevi;
        }

        public TecajModel GetTecaj(int IdTecaj)
        {
            TecajModel tecaj = new TecajModel();

            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DohvatiTecaj";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdTecaj", IdTecaj);
                //md.Parameters["IdTecaj"].Value = IdTecaj;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tecaj.IdTecaj = int.Parse(reader["IdTecaj"].ToString());
                        tecaj.Naziv = reader["Naziv"].ToString();
                        tecaj.Opis = reader["Opis"].ToString();

                    }
                }

                return tecaj;
            }


        }

        public void KreirajTecaj(TecajModel tecaj)
        {
            int scoopeIdentity;
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "KreirajTecaj";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Naziv", tecaj.Naziv);
                //cmd.Parameters["Naziv"].Value = tecaj.Naziv;
                cmd.Parameters.AddWithValue("Opis", tecaj.Opis);
                //cmd.Parameters["Opis"].Value = tecaj.Opis;

                cmd.ExecuteNonQuery();
            }
        }

        public bool IzbrisiTecaj(int IdTecaj)
        {
            bool obrisan;

            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "IzbrisiTecaj";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdTecaj", IdTecaj);
                //cmd.Parameters["IdPolaznika"].Value = IdTecaj;

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    obrisan = true;
                }
                else
                {
                    obrisan = false;
                }

            }
            return obrisan;
        }

        public void UrediTecaj(TecajModel tecaj)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UrediTecaj";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdTecaj", tecaj.IdTecaj);
                //cmd.Parameters["IdTecaj"].Value = tecaj.IdTecaj;
                cmd.Parameters.AddWithValue("Naziv", tecaj.Naziv);
                //cmd.Parameters["Naziv"].Value = tecaj.Naziv;
                cmd.Parameters.AddWithValue("Opis" , tecaj.Opis);
                //cmd.Parameters["Opis"].Value = tecaj.Opis;
                cmd.ExecuteNonQuery();
            }
        }

        public void KreirajUpis(UpisModel  upis)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "KreirajUpis";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("DatumUpisa", upis.DatumUpisa);
                //cmd.Parameters["DatumUpisa"].Value = upis.DatumUpisa;
                cmd.Parameters.AddWithValue("IdPolaznik", upis.IdPolaznik);
                //cmd.Parameters["IdPolaznika"].Value = upis.IdPolaznik;
                cmd.Parameters.AddWithValue("IdTecaj", upis.IdTecaj);
                //cmd.Parameters["IdTecaj"].Value = upis.IdTecaj;

                cmd.ExecuteNonQuery();
            }
        }

        public List<UpisDetailModel> GetUpis()
        {
            List<UpisDetailModel> upisDetailsList = new List<UpisDetailModel>();

            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "upisimasterdetails";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UpisDetailModel details = new UpisDetailModel();
                        details.Ime = reader["Ime"].ToString();
                        details.Prezime = reader["Prezime"].ToString();
                        details.Email = reader["Email"].ToString();
                        details.DatumUpisa = DateTime.Parse(reader["IdPolaznik"].ToString());
                        details.Naziv = reader["Naziv"].ToString();
                        details.Opis = reader["Opis"].ToString();


                        upisDetailsList.Add(details);
                    }
                }
            }

            return upisDetailsList;
        }

        public string GetGrad(int id)
        {
            string data;

            using (SqlConnection conn = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT Naziv FROM tblGradovi WHERE IdGrada = @IdGrada";
                cmd.Parameters.AddWithValue("IdGrada", id);

                data = cmd.ExecuteScalar().ToString();
            }

            return data;
        }

        public List<UpisDetailModel> GetDetailMaster()
        {
            List<UpisDetailModel> masterDetails = new List<UpisDetailModel>() ;
            using (SqlConnection conn = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpisiMasterDetails";

                cmd.Connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        UpisDetailModel master = new UpisDetailModel();
                        master.Ime = reader["Ime"].ToString();
                        master.Prezime = reader["Prezime"].ToString();
                        master.Email = reader["Email"].ToString();
                        master.Naziv = reader["Naziv"].ToString();
                        master.Opis = reader["Opis"].ToString();
                        master.DatumUpisa = DateTime.Parse(reader["DatumUpisa"].ToString());

                        masterDetails.Add(master);
                    }
                }

            }

            return masterDetails;
        }
    }
}

