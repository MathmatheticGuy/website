using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp.Views.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        Models.Function Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Function();
            ShowCategories();
        }

        private void ShowCategories()
        {
            // get data from server and return back
            string Query = "Select * from CategoryTbl";
            CategoriesList.DataSource = Con.GetData(Query);
            CategoriesList.DataBind();

        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "" || DescriptionTb.Value == "")
                {

                    ErrMsg.Text = ">> Missing Data<<";
                }
                else
                {
                    // insert Author to DB
                    string CName = CatNameTb.Value;
                    string CDesc = DescriptionTb.Value;

                    string Query = "insert into CategoryTbl values('{0}', '{1}')";
                    Query = string.Format(Query, CName, CDesc);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = ">> Category Inserted <<";
                    CatNameTb.Value = "";
                    DescriptionTb.Value = "";

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
            CatNameTb.Value = CategoriesList.SelectedRow.Cells[2].Text;
            DescriptionTb.Value = CategoriesList.SelectedRow.Cells[3].Text;
            if (CatNameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CategoriesList.SelectedRow.Cells[1].Text);
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "" || DescriptionTb.Value == "")
                {

                    ErrMsg.Text = ">> Missing Category<<";
                }
                else
                {
                    // insert Author to DB
                    string CName = CatNameTb.Value;
                    string CDesc = DescriptionTb.Value;

                    string Query = "update CategoryTbl set CateName = '{0}', CateDecription = '{1}' where CateId = {2}";
                    Query = string.Format(Query, CName, CDesc, CategoriesList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = ">> Category Updated <<";
                    CatNameTb.Value = "";
                    DescriptionTb.Value = "";

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
                // check if textbox is empty
                if (CatNameTb.Value == "" || DescriptionTb.Value == "")
                {

                    ErrMsg.Text = ">> Select an Category <<";
                }
                else
                {
                    // insert Author to DB
                    string CName = CatNameTb.Value;
                    string CDesc = DescriptionTb.Value;

                    string Query = "delete from CategoryTbl where CateID = {0}";
                    Query = string.Format(Query, CategoriesList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = ">> Category Deleted <<";
                    CatNameTb.Value = "";
                    DescriptionTb.Value = "";

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