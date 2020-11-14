using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace AlumniiUT
{
    public partial class loginadmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("~/studentsadmin.aspx");
            }

        }
        SqlConnection conn = new SqlConnection("Data Source=ERMIRA\\ERMIRA;Initial Catalog=AlumniUT;Integrated Security=True");

        protected void Button1_Click(object sender, EventArgs e)
        {
            string kycu = "Select count (*) from admin where username='"+TextBox1.Text+"' and password='"+TextBox2.Text+"'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(kycu, conn);
            string output = cmd.ExecuteScalar().ToString();
            if (output == "1")
            { 
                Session["User"] = TextBox1.Text;
                Response.Redirect("~/studentsadmin.aspx");
                
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Wrong username or password. Please try again!')", true);
                
            }
            conn.Close();
        }
       
    }
}