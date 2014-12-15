using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsuntoDBweb
{
    public partial class AsunnonValinta : System.Web.UI.Page
    {
        private AsuntoDBEntities db = new AsuntoDBEntities();
        private int valittuHenkiloAvain = -1;
        private Henkilo valittuHenkilo = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            String henkiloAvainString = Request.QueryString["valittuHenkiloAvain"];
            if (henkiloAvainString == null || henkiloAvainString.Length < 1)
            {
                return;
            }
            valittuHenkiloAvain = int.Parse(henkiloAvainString);

            if (!IsPostBack)
            {
                HaeHenkilo();
                if (valittuHenkilo == null)
                {
                    lblMessage.Text = "Virhe valitessa henkilöä.";
                    return;
                }
                BindGrid();
            }
            lblMessage.Text = "";
        }

        protected void HaeHenkilo()
        {
            var result = from h in db.Henkilo
                         where h.Avain == valittuHenkiloAvain
                         select h;
            if (result.Count() > 0)
            {
                valittuHenkilo = result.First();
                lblValittuHenkilo.Text = string.Format("  {0}, {1}", valittuHenkilo.Sukunimi, valittuHenkilo.Etunimi);
                if (valittuHenkilo.AsuntoAvain != null)
                {
                    lblValitunHenkilonAsunto.Text = string.Format("  {0}", valittuHenkilo.Asunto.Osoite);
                }
                else
                {
                    lblValitunHenkilonAsunto.Text = "  (ei asuntoa)";
                }
            }

        }
        protected void BindGrid()
        {
            var result = from a in db.Asunto
                         select a;
            if (result.Count() > 0)
            {
                gridAsunnonValinta.DataSource = result.ToList();
                gridAsunnonValinta.DataBind();
            }
        }
        protected void gridAsunnonValinta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Valitse")
            {
                if (valittuHenkiloAvain > -1)
                {
                    int valittuAsuntoAvain = int.Parse(e.CommandArgument.ToString());

                    HaeHenkilo();
                    valittuHenkilo.AsuntoAvain = valittuAsuntoAvain;
                    db.SaveChanges();
                    Response.Redirect(Request.RawUrl);
                    //lblValitunHenkilonAsunto.Text = string.Format("{0}", valittuHenkilo.Asunto.Osoite);
                }
            }
        }

        protected void lnkPoista_Click(object sender, EventArgs e)
        {
            HaeHenkilo();
            valittuHenkilo.Asunto = null;
            db.SaveChanges();
            Response.Redirect(Request.RawUrl);
            //lblValitunHenkilonAsunto.Text = "  (ei asuntoa)";
        }
    }
}