using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsuntoDBweb
{
    public partial class Asuntotyyppi1 : System.Web.UI.Page
    {
        private AsuntoDBEntities db = new AsuntoDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            lblMessage.Text = "";
        }

        protected void BindGrid()
        {
            var result = from at in db.Asuntotyyppi
                         select at;
            if (result.Count() > 0)
            {
                gridAsuntotyyppi.DataSource = result.ToList();
                gridAsuntotyyppi.DataBind();
            }
        }

        protected void gridAsuntotyyppi_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridAsuntotyyppi.FooterRow;
                TextBox txtAsuntotyyppi = row.FindControl("txtAsuntotyyppiNew") as TextBox;
                if (txtAsuntotyyppi != null)
                {
                    Asuntotyyppi a = new Asuntotyyppi { Selite = txtAsuntotyyppi.Text };
                    db.Asuntotyyppi.Add(a);
                    db.SaveChanges();
                    lblMessage.Text = "Lisätty onnistuneesti";
                    BindGrid();
                }
            }
        }
        protected void gridAsuntotyyppi_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridAsuntotyyppi.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridAsuntotyyppi_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridAsuntotyyppi.EditIndex = -1;
            BindGrid();
        }
        protected void gridAsuntotyyppi_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridAsuntotyyppi.Rows[e.RowIndex];
            TextBox txtAsuntotyyppi = row.FindControl("txtAsuntotyyppi") as TextBox;
            if (txtAsuntotyyppi != null)
            {
                int Koodi = Convert.ToInt32(gridAsuntotyyppi.DataKeys[e.RowIndex].Value);
                var result = from at in db.Asuntotyyppi
                             where at.Koodi == Koodi
                             select at;
                Asuntotyyppi valittu = result.FirstOrDefault();
                valittu.Selite = txtAsuntotyyppi.Text;

                db.SaveChanges();
                lblMessage.Text = "Muokattu onnistuneesti";
                gridAsuntotyyppi.EditIndex = -1;
                BindGrid();
            }
        }
        protected void gridAsuntotyyppi_RowDataBound(object sender, GridViewRowEventArgs e) { }
        protected void gridAsuntotyyppi_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Koodi = Convert.ToInt32(gridAsuntotyyppi.DataKeys[e.RowIndex].Value);
            var result = from at in db.Asuntotyyppi
                         where at.Koodi == Koodi
                         select at;
            Asuntotyyppi valittu = result.FirstOrDefault();
            if (valittu.Asunto.Count() > 0)
            {
                lblMessage.Text = "Ei voida poistaa koska tämän tyyppisiä asuntoja on olemassa.";
                return;
            }
            db.Asuntotyyppi.Remove(valittu);
            db.SaveChanges();
            BindGrid();
            lblMessage.Text = "Poistettu onnistuneesti.";
        }
    }
}