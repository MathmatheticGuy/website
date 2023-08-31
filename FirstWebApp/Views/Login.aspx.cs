using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp.Views
{
    public partial class Login : System.Web.UI.Page
    {
        Models.Function Con;
      

        protected void Page_Load(object sender, EventArgs e )
        {
            Con = new Models.Function();
        }

        public static string UName = "";
        public static int User;

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            // Check input with SQL table
            if (UNameTb.Value == "" || UPassTb.Value == "")
            {
                ErrMsg.Text = ">> Missing Data <<";
            }
            // If Admin account go to Books
            else if (UNameTb.Value == "Admin@gmail.com" && UPassTb.Value == "Password")
            {
                Response.Redirect("Admin/Books.aspx");
            }
            else
            {
                // Select every Gmail and Passwordin SellerTbl as User Admin
                string Query = "SELECT * FROM SellerTbl WHERE SelEmail='{0}' AND SelPass='{1}' ";
                Query = string.Format(Query, UNameTb.Value, UPassTb.Value);
                DataTable dt = Con.GetData(Query);

                if (dt.Rows.Count == 0) {
                    Response.Redirect("Admin/Books.aspx");
                }
                else
                {
                    // if there isn't any Admin accounts
                    UName = UNameTb.Value;
                    User = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Response.Redirect("Seller/Selling.aspx");
                }
            }
        }
    }
}