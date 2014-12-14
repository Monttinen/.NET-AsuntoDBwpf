using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsuntoDBweb
{
    public partial class Henkilo1 : System.Web.UI.Page
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
        /// Bind Henkilo data to grid
        /// </summary>
        void BindGrid()
        {
            var result = from h in db.Henkilo
                         select h;

            if (result.Count() > 0)
            {
                gridSample.DataSource = result.ToList();
                gridSample.DataBind();
            }
            else
            {
                var obj = new List<Henkilo>();
                obj.Add(new Henkilo());
                // Bind the DataTable which contain a blank row to the GridView
                gridSample.DataSource = obj;
                gridSample.DataBind();
                int columnsCount = gridSample.Columns.Count;
                gridSample.Rows[0].Cells.Clear();// clear all the cells in the row
                gridSample.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                gridSample.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                //You can set the styles here
                gridSample.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gridSample.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                gridSample.Rows[0].Cells[0].Font.Bold = true;
                //set No Results found to the new added cell
                gridSample.Rows[0].Cells[0].Text = "NO RESULT FOUND!";
            }

        }

        protected void gridSample_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList ddl = null;
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlSukupuoliNew") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlSukupuoli") as DropDownList;
            }
            if (ddl != null)
            {
                var result = from s in db.Sukupuoli
                             select s;

                ddl.DataSource = result.ToList();
                ddl.DataTextField = "Selite";
                ddl.DataValueField = "Koodi";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem(""));

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((Henkilo)(e.Row.DataItem)).SukupuoliKoodi.ToString();
                }
            }
        }

        protected void gridSample_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridSample.FooterRow;
                TextBox txtEtunimi = row.FindControl("txtEtunimiNew") as TextBox;
                TextBox txtSukunimi = row.FindControl("txtSukunimiNew") as TextBox;
                TextBox txtHenkilonumero = row.FindControl("txtHenkilonumeroNew") as TextBox;
                TextBox txtSyntymaaika = row.FindControl("txtSyntymaaikaNew") as TextBox;
                DropDownList ddlSukupuoli = row.FindControl("ddlSukupuoliNew") as DropDownList;
                if (txtEtunimi != null && txtSukunimi != null && txtHenkilonumero != null && txtHenkilonumero != null && ddlSukupuoli != null)
                {
                    int SukupuoliKoodi = Convert.ToInt32(ddlSukupuoli.SelectedValue);
                    var result = from s in db.Sukupuoli
                                    where s.Koodi == SukupuoliKoodi
                                    select s;
                    Sukupuoli sukupuoli = result.FirstOrDefault();

                    Henkilo h = new Henkilo { Etunimi = txtEtunimi.Text, Sukunimi = txtSukunimi.Text, Henkilonumero = txtHenkilonumero.Text, Syntymaaika = txtSyntymaaika.Text, Sukupuoli = sukupuoli };

                    db.Henkilo.Add(h);
                    db.SaveChanges();
                    lblMessage.Text = "Lisätty onnistuneesti.";
                    BindGrid();

                }
            }
        }

        protected void gridSample_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridSample.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridSample_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridSample.EditIndex = -1;
            BindGrid();
        }
        protected void gridSample_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridSample.Rows[e.RowIndex];
            TextBox txtEtunimi = row.FindControl("txtEtunimi") as TextBox;
            TextBox txtSukunimi = row.FindControl("txtSukunimi") as TextBox;
            TextBox txtHenkilonumero = row.FindControl("txtHenkilonumero") as TextBox;
            TextBox txtSyntymaaika = row.FindControl("txtSyntymaaika") as TextBox;
            DropDownList ddlSukupuoli = row.FindControl("ddlSukupuoli") as DropDownList;
            if (txtEtunimi != null && txtSukunimi != null && txtHenkilonumero != null && txtSyntymaaika != null && ddlSukupuoli != null)
            {

                int Avain = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);

                var result = from h in db.Henkilo
                             where h.Avain == Avain
                             select h;
                Henkilo obj = result.FirstOrDefault();

                obj.Etunimi = txtEtunimi.Text;
                obj.Sukunimi = txtSukunimi.Text;
                obj.Henkilonumero = txtHenkilonumero.Text;
                obj.Syntymaaika = txtSyntymaaika.Text;
                obj.SukupuoliKoodi = Convert.ToInt32(ddlSukupuoli.SelectedValue);

                db.SaveChanges();
                lblMessage.Text = "Tallennettu onnistuneesti.";
                gridSample.EditIndex = -1;
                BindGrid();

            }
        }

        protected void gridSample_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Avain = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);

            var result = from h in db.Henkilo
                         where h.Avain == Avain
                         select h;
            Henkilo obj = result.FirstOrDefault();

            db.Henkilo.Remove(obj);
            db.SaveChanges();
            BindGrid();
            lblMessage.Text = "Poistettu onnistuneesti.";

        }
    }
}