using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp.Views.Admin
{
    public partial class Seller : System.Web.UI.Page
    {
        Models.Function Con;
        protected void Page_Load(object Sender, EventArgs e)
        {
            Con = new Models.Function();
            ShowCategories();
        }

        private void ShowCategories()
        {
            // get data from Selrver and return back
            string Query = "Select * from SellerTbl";
            SellerList.DataSource = Con.GetData(Query);
            SellerList.DataBind();

        }

        protected void SaveBtn_Click(object Sender, EventArgs e)
        {
            try
            {
                if (SelNameTb.Value == "" || SelEmailTb.Value == "" || SelPhoneTb.Value == "" || SelAddressTb.Value == "")
                {
                    ErrMsg.Text = ">> Choose an Selller <<";
                }
                else
                {
                    // inSelrt Seller to DB
                    string SName = SelNameTb.Value;
                    string SEmail = SelEmailTb.Value;
                    string SPhone = SelPhoneTb.Value;
                    string SAddress = SelAddressTb.Value;


                    string Query = "Insert into SellerTbl values('{0}', '{1}', '{2}', '{3}')";
                    Query = string.Format(Query, SName, SEmail, SPhone, SAddress);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = ">> Seller Inserted <<";
                    SelNameTb.Value = "";
                    SelEmailTb.Value = "";
                    SelPhoneTb.Value = "";
                    SelAddressTb.Value = "";
                }
            }
            catch (Exception ex)
            {
                // actice when error
                ErrMsg.Text = ex.Message;
            }
        }

        int Key = 0;
        protected void AuthorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelNameTb.Value = SellerList.SelectedRow.Cells[2].Text;
            SelEmailTb.Value = SellerList.SelectedRow.Cells[3].Text;
            SelPhoneTb.Value = SellerList.SelectedRow.Cells[4].Text;
            SelAddressTb.Value = SellerList.SelectedRow.Cells[5].Text;

            if (SelNameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(SellerList.SelectedRow.Cells[1].Text);
            }
        }

        protected void UpdateBtn_Click(object Sender, EventArgs e)
        {
            try
            {
                if (SelNameTb.Value == "" || SelEmailTb.Value == "" || SelPhoneTb.Value == "" || SelAddressTb.Value == "")
                {
                    ErrMsg.Text = ">> Choose an Seller <<";
                }
                else
                {
                    // inSelrt Author to DB
                    string SName = SelNameTb.Value;
                    string SEmail = SelEmailTb.Value;
                    string SPhone = SelPhoneTb.Value;
                    string SAddress = SelAddressTb.Value;


                    string Query = "Update SellerTbl set SelName = '{0}', SelEmail = '{1}', SelPhone = '{2}', SelPass = '{3}' where SelID = {4}";
                    Query = string.Format(Query, SName, SEmail, SPhone, SAddress, SellerList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    // reSelt
                    ErrMsg.Text = ">> Seller Updated <<";
                    SelNameTb.Value = "";
                    SelEmailTb.Value = "";
                    SelPhoneTb.Value = "";
                    SelAddressTb.Value = "";
                }
            }
            catch (Exception ex)
            {
                // actice when error
                ErrMsg.Text = ex.Message;
            }
        }

        protected void DeleteBtn_Click(object Sender, EventArgs e)
        {
            try
            {
                if (SelNameTb.Value == "" || SelEmailTb.Value == "" || SelPhoneTb.Value == "" || SelAddressTb.Value == "")
                {
                    ErrMsg.Text = ">> Choose an Seller <<";
                }
                else
                {
                    // inSelrt Author to DB
                    string SName = SelNameTb.Value;
                    string SEmail = SelEmailTb.Value;
                    string SPhone = SelPhoneTb.Value;
                    string SAddress = SelAddressTb.Value;

                    string Query = "delete from SellerTbl where SelID = {0}";
                    Query = string.Format(Query, SellerList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = ">> Author Deleted <<";
                    SelNameTb.Value = "";
                    SelEmailTb.Value = "";
                    SelPhoneTb.Value = "";
                    SelAddressTb.Value = "";
                }
            }
            catch (Exception ex)
            {
                // actice when error
                ErrMsg.Text = ex.Message;
            }
        }

  
    }
}