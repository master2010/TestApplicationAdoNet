using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PolaznickiForum
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = this.tbxUsername.Text;
            string password = this.tbxPassword.Text;

            SqlConnection conn =
                new SqlConnection(
                    ConfigurationManager.ConnectionStrings["MojaKonekcija"].ConnectionString);

            string mojaKomanda =
                "SELECT TOP 1 k.hash_zaporke, g.naziv_grupe FROM korisnici k " +
                "INNER JOIN grupe_korisnika g ON g.id_grupa = k.grupa_id WHERE korisnicko_ime LIKE @username";

            SqlParameter paramUsername = new SqlParameter("@username", username);


            SqlCommand cmd =
                new SqlCommand(mojaKomanda, conn);

            cmd.Parameters.Add(paramUsername);

            conn.Open();
            var rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();


                var hash = (string)rdr["hash_zaporke"];

                if (PasswordHash.ValidatePassword(password, hash))
                {
                    Session["logedIn"] = true;
                    Session["userName"] = username;
                    Session["userGroup"] = (string)rdr["naziv_grupe"];
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Response.Write("Krivo korisnicko ime ili zaporka, pokusajte ponovno!");
                }

            }
            else
            {
                Response.Write("Krivo korisnicko ime ili zaporka, pokusajte ponovno!");
            }
            conn.Close();
        }
    }
}