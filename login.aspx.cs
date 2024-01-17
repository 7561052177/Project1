using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Project1
{
    public partial class login : System.Web.UI.Page
    {
        connectionclass obj = new connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(Reg_id) from login where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
            string cid = obj.fn_scalar(str);
            int cid1 = Convert.ToInt32(cid);
            if (cid1 == 1)
            {
                string str1 = "select Reg_id from login where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                int regid = Convert.ToInt32(obj.fn_scalar(str1));
                Session["userid"] = regid;
                string str2 = "select logtype  from login where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                string logtype = obj.fn_scalar(str2);
                if (logtype == "admin")
                {
                    Response.Redirect("product.aspx");
                }
                else if (logtype == "user")
                {
                    Response.Redirect("menu.aspx");
                }

            }
        }


    }
}