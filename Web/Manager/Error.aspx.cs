﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Web.Manager
{
    public partial class Error : Business.ManageWeb
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck();
            
        }
       
    }
}
