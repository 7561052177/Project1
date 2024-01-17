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
    public partial class grid : System.Web.UI.Page
    {
        connectionclass obj = new connectionclass();
            
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grid_bind();
            }
        }

        public void grid_bind()
        {
            string str = "select * from category";
            DataSet ds = obj.fn_dataset(str);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(e.commandArgument);
            string sel = "select cat_status from category where category_id=" + id + "";
            string s = obj.fn_scalar(sel);
            if (s == "available")
            {
                string upd = "update category set cat_status='unavailable' where category_id = " + id + "";
            int i = obj.fn_nonquery(upd);
                if (i == 1)
                {
                    Label1.Visible = true;
                    Label1.Text = "blocked";
                }

            }
            else if (s == "unavailable")
            {
                string upd1 = "update category set cat_status='available' where category_id = " + id + "";
            int i = obj.fn_nonquery(upd1);
                if (i == 1)
                {
                    Label1.Visible = true;
                    Label1.Text = "unblocked";
                }
            }
            grid_bind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            grid_bind();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            grid_bind();

        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            int i = e.RowIndex;
            int id = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtcatn = (TextBox)GridView1.Rows[i].Cells[1].Controls[0];
            TextBox txtdes = (TextBox)GridView1.Rows[i].Cells[3].Controls[0];

            string str = "update category set cat_name = '"+txtcatn.Text+"',cat_description = '"+txtdes.Text+"' where category_id = " + id + 
"";
            int j = obj.fn_nonquery(str);
            GridView1.EditIndex = -1;
            grid_bind();
        }
    }

}
    
   
