using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;

namespace Lab5
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditItem((int)GridView1.SelectedValue);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EditItem(0);
        }

        /// <summary>
        /// Редакирование записи
        /// </summary>
        /// <param name="id">Идентификатор записи, если 0 то создать новую запись</param>
        private void EditItem(int id)
        {
            var redirectUrl = "~/Edit";
            redirectUrl += "?Id=" + id;
            Response.Redirect(redirectUrl);
        }
    }
}