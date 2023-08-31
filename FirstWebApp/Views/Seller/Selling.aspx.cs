using FirstWebApp.Views.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace FirstWebApp.Views.Seller
{
    public partial class Selling : System.Web.UI.Page
    {
        Models.Function Con;
        int Seller = Login.User;
        string SName = Login.UName;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Function();
            if (!IsPostBack)
            {
                ShowBooks();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5]
                {
                    new DataColumn("ID"),
                    new DataColumn("Book"),
                    new DataColumn("Price"),
                    new DataColumn("Quantity"),
                    new DataColumn("Total"),
                }
                );
                ViewState["Bill"] = dt;
                this.BindGrid();
            }
        } 

        protected void BindGrid()
        {
            BillList.DataSource = ViewState["Bill"];
            BillList.DataBind();
        }
        private void ShowBooks()
        {
            // get data from Selrver and return back
            string Query = "SELECT BId AS Code,BName AS Name,BQty AS Stock, BPrice AS Price FROM BookTbl";
            BooksList.DataSource = Con.GetData(Query);
            BooksList.DataBind();
        }

        int Key = 0;
        int Stock = 0;
        protected void AuthorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BNameTb.Value = BooksList.SelectedRow.Cells[2].Text;
            Stock = Convert.ToInt32(BooksList.SelectedRow.Cells[3].Text);
            BPriceTb.Value = BooksList.SelectedRow.Cells[4].Text;

            if (BNameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(BooksList.SelectedRow.Cells[1].Text);
            }
        }


        private void UpdateStock()
        {
            int NewQty; 
            NewQty = Convert.ToInt32(BooksList.SelectedRow.Cells[3].Text) + Convert.ToInt32(BQtyTb.Value);

            string Query = "update BookTbl set BQty = {0} where BId = {1}";
            Query = string.Format(Query, NewQty, BooksList.SelectedRow.Cells[1].Text);
            Con.SetData(Query);
            ShowBooks();
        }

        private void InsertBill()
        {
            try
            {
                string Query = "insert into BillTbl values('{0}', {1}, {2})";
                Query = string.Format(Query, System.DateTime.Today, Seller, Convert.ToInt32(GrdTotalTb.Text.Substring(2)));
                Con.SetData(Query);
                ShowBooks();
            }
            catch (Exception ex)
            {

            }

            //try
            //{
            //    string Query = "insert into BillTbl values(@date, @seller, @amount)";
            //    using (SqlCommand cmd = new SqlCommand(Query, Con))
            //    {
            //        cmd.Parameters.AddWithValue("@date", DateTb.Value);
            //        cmd.Parameters.AddWithValue("@seller", Seller);
            //        cmd.Parameters.AddWithValue("@amount", Amount);
            //        cmd.ExecuteNonQuery();
            //    }
            //    ShowBooks();
            //}
            //catch (Exception ex)
            //{

            //}
        }

        int GrdTotal = 0;
        int Amount;
        int Quant;
        protected void AddToBillBtn_Click(object sender, EventArgs e)
        {
            if (BQtyTb.Value == "" || BPriceTb.Value == "" || BNameTb.Value == ""){
                ErrMsg.Text = ">> Missing Data <<";
            }
            else
            {
                int total = Convert.ToInt32(BQtyTb.Value) * Convert.ToInt32(BPriceTb.Value);
                DataTable dt = (DataTable)ViewState["Bill"];
                dt.Rows.Add(
                    BillList.Rows.Count + 1,
                    BNameTb.Value.Trim(),
                    BPriceTb.Value.Trim(),
                    BQtyTb.Value.Trim(),
                    total);

                ViewState["Bill"] = dt;
                this.BindGrid();
                UpdateStock();

                // add-up all the Bills
                for (int i = 0; i < BillList.Rows.Count - 1; i++)
                {
                    GrdTotal = GrdTotal + Convert.ToInt32(BillList.Rows[i].Cells[5].Text);
                }
                // Quantity
                for (int i = 0; i < BillList.Rows.Count - 1; i++)
                {
                    Quant = Quant + Convert.ToInt32(BillList.Rows[i].Cells[4].Text);
                }

                Amount = GrdTotal;
                BNameTb.Value = "";
                BPriceTb.Value = "";
                BQtyTb.Value = "";
                Discount.Text = "Book Store Openning Discount: Get 1 Book Free";
                GrdTotalTb.Text = GrdTotal + " VNĐ with " + Quant + " Total Quantity" ;
                GrdTotal = 0;

            }
        }

        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            InsertBill();

        }
    }
}