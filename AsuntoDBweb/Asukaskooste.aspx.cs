using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsuntoDBweb
{
    public partial class Asukaskooste : System.Web.UI.Page
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
            var result = from ak in db.raportti_asukaskooste
                         select ak;
            if (result.Count() > 0)
            {
                gridAsukaskooste.DataSource = result.ToList();
                gridAsukaskooste.DataBind();
            }
        }
    }
}