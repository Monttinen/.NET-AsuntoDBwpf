using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsuntoDBweb
{
    public partial class Asunto1 : System.Web.UI.Page
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
        /// <summary>
        /// Bind Asunto data to grid
        /// </summary>
        protected void BindGrid()
        {
            var result = from h in db.Asunto
                         select h;

            if (result.Count() > 0)
            {
                gridAsunto.DataSource = result.ToList();
                gridAsunto.DataBind();
            }
            else
            {
                var obj = new List<Asunto>();
                obj.Add(new Asunto());
                // Bind the DataTable which contain a blank row to the GridView
                gridAsunto.DataSource = obj;
                gridAsunto.DataBind();
                int columnsCount = gridAsunto.Columns.Count;
                gridAsunto.Rows[0].Cells.Clear();// clear all the cells in the row
                gridAsunto.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                gridAsunto.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                //You can set the styles here
                gridAsunto.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gridAsunto.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                gridAsunto.Rows[0].Cells[0].Font.Bold = true;
                //set No Results found to the new added cell
                gridAsunto.Rows[0].Cells[0].Text = "NO RESULT FOUND!";
            }

        }

        protected void gridAsunto_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList ddl = null;
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlAsuntotyyppiNew") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlAsuntotyyppi") as DropDownList;
            }
            if (ddl != null)
            {
                var result = from at in db.Asuntotyyppi
                             select at;

                ddl.DataSource = result.ToList();
                ddl.DataTextField = "Selite";
                ddl.DataValueField = "Koodi";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem(""));

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((Asunto)(e.Row.DataItem)).AsuntotyyppiKoodi.ToString();
                }
            }
        }

        protected void gridAsunto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridAsunto.FooterRow;
                TextBox txtOsoite = row.FindControl("txtOsoiteNew") as TextBox;
                TextBox txtPinta_ala = row.FindControl("txtPinta_alaNew") as TextBox;
                TextBox txtAsuntonumero = row.FindControl("txtAsuntonumeroNew") as TextBox;
                TextBox txtHuonelukumaara = row.FindControl("txtHuonelukumaaraNew") as TextBox;
                DropDownList ddlAsuntotyyppi = row.FindControl("ddlAsuntotyyppiNew") as DropDownList;
                if (txtOsoite != null && txtPinta_ala != null && txtAsuntonumero != null && txtAsuntonumero != null && ddlAsuntotyyppi != null)
                {
                    int AsuntotyyppiKoodi = Convert.ToInt32(ddlAsuntotyyppi.SelectedValue);
                    var result = from s in db.Asuntotyyppi
                                 where s.Koodi == AsuntotyyppiKoodi
                                 select s;
                    Asuntotyyppi Asuntotyyppi = result.FirstOrDefault();

                    Asunto a = new Asunto { Osoite = txtOsoite.Text, Pinta_ala = int.Parse(txtPinta_ala.Text), Asuntonumero = txtAsuntonumero.Text, Huonelukumaara = int.Parse(txtHuonelukumaara.Text), Asuntotyyppi = Asuntotyyppi };

                    db.Asunto.Add(a);
                    db.SaveChanges();
                    lblMessage.Text = "Lisätty onnistuneesti.";
                    BindGrid();

                }
            }
        }

        protected void gridAsunto_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridAsunto.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridAsunto_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridAsunto.EditIndex = -1;
            BindGrid();
        }
        protected void gridAsunto_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridAsunto.Rows[e.RowIndex];
            TextBox txtOsoite = row.FindControl("txtOsoite") as TextBox;
            TextBox txtPinta_ala = row.FindControl("txtPinta_ala") as TextBox;
            TextBox txtAsuntonumero = row.FindControl("txtAsuntonumero") as TextBox;
            TextBox txtHuonelukumaara = row.FindControl("txtHuonelukumaara") as TextBox;
            DropDownList ddlAsuntotyyppi = row.FindControl("ddlAsuntotyyppi") as DropDownList;
            if (txtOsoite != null && txtPinta_ala != null && txtAsuntonumero != null && txtHuonelukumaara != null && ddlAsuntotyyppi != null)
            {

                int Avain = Convert.ToInt32(gridAsunto.DataKeys[e.RowIndex].Value);

                var result = from h in db.Asunto
                             where h.Avain == Avain
                             select h;
                Asunto obj = result.FirstOrDefault();

                obj.Osoite = txtOsoite.Text;
                obj.Pinta_ala = int.Parse(txtPinta_ala.Text);
                obj.Asuntonumero = txtAsuntonumero.Text;
                obj.Huonelukumaara = int.Parse(txtHuonelukumaara.Text);
                obj.AsuntotyyppiKoodi = Convert.ToInt32(ddlAsuntotyyppi.SelectedValue);

                db.SaveChanges();
                lblMessage.Text = "Tallennettu onnistuneesti.";
                gridAsunto.EditIndex = -1;
                BindGrid();

            }
        }

        protected void gridAsunto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Avain = Convert.ToInt32(gridAsunto.DataKeys[e.RowIndex].Value);

            var result = from a in db.Asunto
                         where a.Avain == Avain
                         select a;
            Asunto obj = result.FirstOrDefault();

            if (obj.Henkilo.Count() > 0)
            {
                lblMessage.Text = "Ei voida poistaa, koska asunnossa asuu henkilöitä.";
                return;
            }
            db.Asunto.Remove(obj);
            db.SaveChanges();
            BindGrid();
            lblMessage.Text = "Poistettu onnistuneesti.";

        }
    }
}