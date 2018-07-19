using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;

namespace projekt_8_1_vj.Controllers
{
    public class ConnStrController : Controller
    {
        // GET: ConnStr
        public string  ConnectionWinAuth()
        {
            string winConn = ConfigurationManager.ConnectionStrings["WinConnString"].ConnectionString;
            string state;

            using (SqlConnection conn = new SqlConnection(winConn) )
            {
                conn.Open();
                state = conn.State.ToString();
            }

            return "Stanje konekecije na BAZU : " + state;
        }

        public string ConnectionSQLAuth()
        {
            string sqlConn = ConfigurationManager.ConnectionStrings["sqlConnString"].ConnectionString;
            string state;

            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                state = conn.State.ToString();
            }

            return "Stanje konekecije na BAZU : " + state;
        }
    }
}