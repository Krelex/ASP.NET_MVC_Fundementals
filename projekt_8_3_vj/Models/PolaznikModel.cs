using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace projekt_8_3_vj.Models
{
    public class PolaznikModel
    {
        public int IdPolaznik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public int IdGrad { get; set; }
        public List<GradModel> lstGradovi { get; set; }

        public PolaznikModel()
        {

        }


        public PolaznikModel(bool isSingle)
        {
            if (isSingle)
            {
                this.lstGradovi= new List<GradModel>();
                string conString = ConfigurationManager.ConnectionStrings["sqlConnString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM tblGradovi";

                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GradModel grad = new GradModel
                            {
                                IdGrad = int.Parse(reader["IdGrada"].ToString()),
                                Naziv = reader["Naziv"].ToString(),
                                IdDrzava = int.Parse(reader["IdDrzave"].ToString())
                            };

                            this.lstGradovi.Add(grad);
                        }
                    }
                    
                }
            }
        }

        public string ImeGrad()
        {
            string ime;
            GradModel obj = this.lstGradovi.Where(grad => grad.IdGrad == this.IdGrad).SingleOrDefault();
            if(obj != null)
            {
                ime = obj.Naziv;
            }
            else
            {
                ime = "";
            }
            return ime;
        }
    }
}