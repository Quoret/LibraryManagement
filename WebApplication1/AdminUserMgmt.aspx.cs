using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminUserMgmt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }


        //delete user permanently
        protected void Button2_Click(object sender, EventArgs e)
        {

        }
        // active button
        protected void LinkButton1_Click(object sender, CommandEventArgs e)
        {

        }

        //pending
        protected void LinkButton2_Click(object sender, EventArgs e)
        {

        }

        //not verified
        protected void LinkButton3_Click(object sender, EventArgs e)
        {

        }

        //Tick button or go button 
        
        protected void LinkButton4_Click(object sender, EventArgs e)
        {

        }
        void getUserById()
        {

        }
    }
}