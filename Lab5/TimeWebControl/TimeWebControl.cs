using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimeWebControl
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TimeWebControl runat=server></{0}:TimeWebControl>")]
    public class TimeWebControl : WebControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ServerDateTime
        {
            get
            {
                return DateTime.Now.ToLongTimeString();
            }
        }
 
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(ServerDateTime);
        }
    }
}
