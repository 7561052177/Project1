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
    public partial class add_product : System.Web.UI.Page
    {
        connectionclass obj = new connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {
          //  if (!IsPostBack)
           // {
            //    {
            //        string sel = "select category_id,cat_name from category";
            //        DataSet ds = obj.fn_dataset(sel);
           //         DropDownList1.DataSource = ds;
           //         DropDownList1.DataTextField = "cat_name";
           //         DropDownList1.DataValueField = "category_id";
           //         DropDownList1.DataBind();
          //          DropDownList1.Items.Insert(0, "-select");
          //      }

          //  }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string p = "~/phs/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string str = "insert into product values('" + DropDownList1.SelectedItem.Value + "', '" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + p + "', '" +
           TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "')";
            int j = obj.fn_nonquery(str);
            if (j == 1)
            {
                Label1.Visible = true;
                Label1.Text = "inserted";
            }
        }
    }
}

    
