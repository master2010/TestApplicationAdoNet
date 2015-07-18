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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            var username = this.tbxUsername.Text;

            if (!(this.tbxPw1.Text == this.tbxPw2.Text))
            {
                this.par_obj.InnerText = "Zaporke se ne poklapaju!";
                return;
            }

            var password = this.tbxPw1.Text;

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString =
                ConfigurationManager.ConnectionStrings["MojaKonekcija"].ConnectionString;

            var mojaKomanda = 
                "SELECT TOP 1 id_korisnik FROM " +
                "korisnici WHERE korisnicko_ime LIKE @username";

            var komanda = new SqlCommand(mojaKomanda, conn);

            komanda.Parameters.
                Add("@username", System.Data.SqlDbType.NVarChar).
                Value = username;

            try
            {
                conn.Open();

                SqlDataReader rdr = komanda.ExecuteReader();

                if (rdr.HasRows)
                {
                    this.par_obj.InnerText = "Korisnik s tim imenom već postoji!";
                    return;
                }

                rdr.Close();

                var hash = PasswordHash.CreateHash(password);

                mojaKomanda = 
                    "INSERT INTO korisnici (korisnicko_ime, hash_zaporke, grupa_id) "+
                    "VALUES (@username, @hash, 1003)";

                komanda = new SqlCommand(mojaKomanda, conn);

                komanda.Parameters.
                    Add("@username", System.Data.SqlDbType.NVarChar).Value = username;

                komanda.Parameters.
                    Add("@hash", System.Data.SqlDbType.NVarChar).Value = hash;

                var brojPromjena = komanda.ExecuteNonQuery();

                if (brojPromjena == 1)
                {
                    this.par_obj.InnerText = "Uspjesno kreiran novi korisnik!";
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
        }

    }
}