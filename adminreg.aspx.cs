using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace Project1
{
    public partial class adminreg : System.Web.UI.Page
    {
        connectionclass obj = new connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            string sel = "select max(Reg_Id) from login";
            string regid = obj.fn_scalar(sel);
            int reg_id = 0;
            if (regid == "")
            {
                reg_id = 1;
            }
            else
            {
                int newgrid = Convert.ToInt32(regid);
                reg_id = newgrid + 1;
            }
            string ins = "insert into AdminReg values(" + reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')";
            int i = obj.fn_nonquery(ins);
            if (i != 0)
            {
                string inslog = "insert into login values(" + reg_id + ",'" + TextBox4.Text + "','" + TextBox5.Text + "','admin','active')";
                int j = obj.fn_nonquery(inslog);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}