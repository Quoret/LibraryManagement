using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true; // user login visible huncha
                    LinkButton2.Visible = true; // user signup visible huncha

                    LinkButton3.Visible = false; // log out
                    LinkButton5.Visible = false; // hello user

                    LinkButton6.Visible = true; // admin login
                    LinkButton8.Visible = false; // book inventory
                    LinkButton9.Visible = false; // book issuing
                    LinkButton10.Visible = false; // member management
                    LinkButton11.Visible = false; // author management
                    LinkButton12.Visible = false; //publisher managemen
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; // user login visible hudaina
                    LinkButton2.Visible = false; // user signup visible hudaina
                    
                    LinkButton3.Visible = true; // log out huncha
                    LinkButton5.Visible = true; // hello usee huncha
                    LinkButton5.Text="Hello "+ Session["username"].ToString();
                    
                    LinkButton6.Visible =  false; // admin login
                    LinkButton8.Visible = false; // book inventory
                    LinkButton9.Visible = false; // book issuing
                    LinkButton10.Visible = false; // member management
                    LinkButton11.Visible = false; // author management
                    LinkButton12.Visible = false; //publisher management
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; // user login visible huncha
                    LinkButton2.Visible = false; // user signup visible huncha

                    LinkButton3.Visible = true; // log out
                    LinkButton5.Visible = true; // hello user
                    LinkButton5.Text = "Hello " + Session["username"].ToString();


                    LinkButton6.Visible = false; // admin login
                    LinkButton8.Visible = true; // book inventory
                    LinkButton9.Visible = true; // book issuing
                    LinkButton10.Visible = true; // member management
                    LinkButton11.Visible = true; // author management
                    LinkButton12.Visible = true; //publisher managemen
                }
                
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAuthorMgmt.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublisherMgmt.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookInventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookIssuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUserMgmt.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserSignup.aspx");
        }



        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton1.Visible = true; // user login visible huncha
            LinkButton2.Visible = true; // user signup visible huncha

            LinkButton3.Visible = false; // log out
            LinkButton5.Visible = false; // hello user

            LinkButton6.Visible = true; // admin login
            LinkButton8.Visible = false; // book inventory
            LinkButton9.Visible = false; // book issuing
            LinkButton10.Visible = false; // member management
            LinkButton11.Visible = false; // author management
            LinkButton12.Visible = false; //publisher management

            Response.Redirect("HomePage.aspx");
        }
    }
}