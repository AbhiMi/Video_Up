﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Droptiles : System.Web.UI.MasterPage
{
    protected UserProfile UserProfile
    {
        get
        {
            return SecurityContextManager.GetUserProfile(Context);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
