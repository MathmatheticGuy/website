using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp.Views.Admin
{
    public partial class Books : System.Web.UI.Page
    {
        Models.Function Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Function();
            if (!IsPostBack)
            {
                ShowBooks();
                GetCategories();
                GetAuthors();
            }
        }

        private void ShowBooks()
        {
            // get data from Selrver and return back
            string Query = "Select * from BookTbl";
            BooksList.DataSource = Con.GetData(Query);
            BooksList.DataBind();
        }

        private void GetCategories()
        {
            string Query = "select * from CategoryTbl";
            BCateCb.DataTextField = Con.GetData(Query).Columns["CateName"].ToString();
            BCateCb.DataValueField = Con.GetData(Query).Columns["CateID"].ToString();
            BCateCb.DataSource = Con.GetData(Query);
            BCateCb.DataBind();
        }

        private void GetAuthors()
        {
            string Query = "select * from AuthorTbl";
            BAuthTb.DataTextField = Con.GetData(Query).Columns["AutName"].ToString();
            BAuthTb.DataValueField = Con.GetData(Query).Columns["AuID"].ToString();
            BAuthTb.DataSource = Con.GetData(Query);
            BAuthTb.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BNameTb.Value == "" || BAuthTb.SelectedIndex == -1 || BCateCb.SelectedIndex == -1 || BQuanTb.Value == "" || BPriceTb.Value == "")
                {
                    ErrMsg.Text = ">> Missing Data <<";
                }
                else
                {
                    // inSelrt Seller to DB
                    string BName = BNameTb.Value;
                    string BAuth = BAuthTb.SelectedValue.ToString();
                    string BCategories = BCateCb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(BQuanTb.Value);
                    int Price = Convert.ToInt32(BPriceTb.Value);

                    string Query = "Insert into BookTbl values('{0}', {1}, {2}, {3}, {4})";
                    Query = string.Format(Query, BName, BAuth, BCategories, Quantity, Price);
                    Con.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = ">> Book Inserted <<";
                    BNameTb.Value = "";
                    BAuthTb.SelectedIndex = -1;
                    BCateCb.SelectedIndex = -1;
                    BQuanTb.Value = "";
                    BPriceTb.Value = "";
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
            BNameTb.Value = BooksList.SelectedRow.Cells[2].Text;
            BAuthTb.SelectedValue = BooksList.SelectedRow.Cells[3].Text;
            BCateCb.SelectedValue = BooksList.SelectedRow.Cells[4].Text;
            BQuanTb.Value = BooksList.SelectedRow.Cells[5].Text;
            BPriceTb.Value = BooksList.SelectedRow.Cells[6].Text;


            if (BNameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(BooksList.SelectedRow.Cells[1].Text);
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BNameTb.Value == "" || BAuthTb.SelectedIndex == -1 || BCateCb.SelectedIndex == -1 || BQuanTb.Value == "" || BPriceTb.Value == "")
                {
                    ErrMsg.Text = ">> Missing Data <<";
                }
                else
                {
                    // inSelrt Seller to DB
                    string BName = BNameTb.Value;
                    string BAuth = BAuthTb.SelectedValue.ToString();
                    string BCategories = BCateCb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(BQuanTb.Value);
                    int Price = Convert.ToInt32(BPriceTb.Value);

                    string Query = "update BookTbl set BName = '{0}', BAuthor = {1}, BCategory = {2}, BQty = {3}, BPrice = {4} where BId = {5}";
                    Query = string.Format(Query, BName, BAuth, BCategories, Quantity, Price, BooksList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = ">> Book Updated <<";
                    BNameTb.Value = "";
                    BAuthTb.SelectedIndex = -1;
                    BCateCb.SelectedIndex = -1;
                    BQuanTb.Value = "";
                    BPriceTb.Value = "";
                }

            }
            catch (Exception ex)
            {
                // actice when error
                ErrMsg.Text = ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BNameTb.Value == "" || BAuthTb.SelectedIndex == -1 || BCateCb.SelectedIndex == -1 || BQuanTb.Value == "" || BPriceTb.Value == "")
                {
                    ErrMsg.Text = ">> Missing Data <<";
                }
                else
                {
                    // inSelrt Seller to DB
                    string BName = BNameTb.Value;
                    string BAuth = BAuthTb.SelectedValue.ToString();
                    string BCategories = BCateCb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(BQuanTb.Value);
                    int Price = Convert.ToInt32(BPriceTb.Value);

                    string Query = "delete BookTbl where BId = {0}";
                    Query = string.Format(Query, BooksList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = ">> Book Updated <<";
                    BNameTb.Value = "";
                    BAuthTb.SelectedIndex = -1;
                    BCateCb.SelectedIndex = -1;
                    BQuanTb.Value = "";
                    BPriceTb.Value = "";
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