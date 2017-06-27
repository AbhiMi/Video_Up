using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_CampaignPreview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string innerHTML =
           "<source src='http://localhost:57187/Media/test.mp4'></source>";
        //WebControl control = (WebControl)e.Row.Cells[4].FindControl("ctrlVideo");
        ctrlVideo.InnerHtml = innerHTML;
        //e.Row.Cells[4].FindControl("ctrlVideo").InnerHtml = innerHTML;
        hdnVideoNames.Value = "http://localhost:57187/Media/test.mp4" + "," + "http://localhost:57187/Media/test_1.mp4";
    }
}