using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class BooksByCategory : System.Web.UI.Page
{
    //Used for testing and debugging
    private void Log(String msg)
    {
        System.Diagnostics.Debug.WriteLine(msg);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtCategories = Category.GetAllCategories();
            ddlCategories.DataSource = dtCategories;
            ddlCategories.DataTextField = "CategoryName";
            ddlCategories.DataValueField = "CategoryID";
            ddlCategories.DataBind();
        }
        else
        {
            //Gets the categoryID from the dropdown list.
            String CategoryID = ddlCategories.SelectedValue;
            Log("CategoryID is " + CategoryID);
            
            //Gets the books based on the category
            DataTable dt = Book.GetBookByCategoryID(CategoryID);

            //Sets the datalist based on the results.
            dlBooks.DataSource = dt;
            dlBooks.DataBind();
        }
    }
}