using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PolaznickiForum
{
    public partial class MojProfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(bool)Session["logedIn"])
            {
                Response.Redirect("Login.aspx");
            }

            lblKorisnik.Text = (string)Session["userName"];
            lblGrupa.Text = (string)Session["userGroup"];


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MojaKonekcija"].ConnectionString);

            var cmd = new SqlCommand("SELECT * FROM korisnici WHERE korisnicko_ime LIKE @username", con);

            cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = lblKorisnik.Text;

            SqlDataAdapter adptr = new SqlDataAdapter();

            adptr.SelectCommand = cmd;

            SqlCommandBuilder cmdBld = new SqlCommandBuilder(adptr);

            DataTable mojDataTable = new DataTable();
            DataSet mojDataSet = new DataSet();

            adptr.Fill(mojDataSet);
            adptr.Fill(mojDataTable);

           var email= (string)mojDataTable.Rows[0]["email"];
           txtMail.Text = email;

            






        }

        protected void btnUrediPwd_Click(object sender, EventArgs e)
        {

           

        }

        protected void btnUrediMail_Click(object sender, EventArgs e)
        {

        }
    }
}