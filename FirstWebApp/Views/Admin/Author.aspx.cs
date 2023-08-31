using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp.Views.Admin
{
    public partial class Author : System.Web.UI.Page
    {
        Models.Function Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Function();
            ShowAuthors();
        }
        private void ShowAuthors()
        {
            // get data from server and return back
            string Query = "Select * from AuthorTbl";
            AuthorsList.DataSource = Con.GetData(Query);
            AuthorsList.DataBind();

        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ANameTb.Value == "" || GenCb.SelectedIndex == -1 || CountryDropDown.SelectedIndex == -1)
                {
                    ErrMsg.Text = ">> Missing Data <<";
                }
                else
                {
                    // insert Author to DB
                    string AName = ANameTb.Value;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Country = CountryDropDown.SelectedItem.ToString();

                    string Query = "insert into AuthorTbl values('{0}', '{1}', '{2}')";
                    Query = string.Format(Query, AName, Gender, Country);
                    Con.SetData(Query);
                    ShowAuthors();
                    ErrMsg.Text = ">> Author Inserted <<";
                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryDropDown.SelectedIndex = -1;
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
            ANameTb.Value = AuthorsList.SelectedRow.Cells[2].Text;
            GenCb.SelectedItem.Value = AuthorsList.SelectedRow.Cells[3].Text;
            CountryDropDown.SelectedItem.Value = AuthorsList.SelectedRow.Cells[4].Text;
            if (ANameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(AuthorsList.SelectedRow.Cells[1].Text);
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ANameTb.Value == "" || GenCb.SelectedIndex == -1 || CountryDropDown.SelectedIndex == -1)
                {
                    ErrMsg.Text = ">> Select an Author<<";
                }
                else
                {
                    // insert Author to DB
                    string AName = ANameTb.Value;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Country = CountryDropDown.SelectedItem.ToString();

                    string Query = "update AuthorTbl set AutName = '{0}', AutGender= '{1}', AutCountry= '{2}' where AuID = {3}";
                    // take input as update data
                    try
                    {
                        Query = string.Format(Query, AName, Gender, Country, AuthorsList.SelectedRow.Cells[1].Text);
                        Con.SetData(Query);
                        ShowAuthors();
                        ErrMsg.Text = ">> Author Update <<";
                        ANameTb.Value = "";
                        GenCb.SelectedIndex = -1;
                        CountryDropDown.SelectedIndex = -1;
                    }
                    catch {
                        
                    }
                    
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
                if (ANameTb.Value == "" || GenCb.SelectedIndex == -1 || CountryDropDown.SelectedIndex == -1)
                {
                    ErrMsg.Text = ">> Select an Author <<";
                }
                else
                {
                    // insert Author to DB 
                    string AName = ANameTb.Value;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Country = CountryDropDown.SelectedItem.ToString();

                    string Query = "DELETE from AuthorTbl WHERE AuID = {0}";
                    Query = string.Format(Query, AuthorsList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowAuthors();
                    ErrMsg.Text = ">> Author Deleted <<";
                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryDropDown.SelectedIndex = -1;
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