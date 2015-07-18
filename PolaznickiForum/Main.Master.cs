using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PolaznickiForum
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logedIn"])
            {
                this.div_korisnik.InnerHtml =
                    String.Format(@"Zdravo {0}! <a href=""Logout.aspx"">Odjava</a> | <a href=""MojProfil.aspx"">Moj profil</a>", Session["userName"]);
            }
            else
            {
                this.div_korisnik.InnerHtml =
                    @"Zdravo! <a href=""Login.aspx"">Prijava</a> | <a href=""Register.aspx"">Registracija</a>";
            }
        }
    }
}