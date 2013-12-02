using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab5
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.HasKeys())
            {
                var keyValue = Request.QueryString["Id"];
                if (keyValue != null && keyValue == 0.ToString())
                {
                    DetailsView1.ChangeMode(DetailsViewMode.Insert);
                }
            }
            
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}