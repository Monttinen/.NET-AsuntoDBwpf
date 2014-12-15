using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsuntoDBweb
{
    public partial class Sukupuolijakauma : System.Web.UI.Page
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
            var result = from sj in db.raportti_sukupuolijakauma
                         select sj;
            if (result.Count() > 0)
            {
                gridSukupuolijakauma.DataSource = result.ToList();
                gridSukupuolijakauma.DataBind();
            }
        }
    }
}