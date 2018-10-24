using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SearchBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        //Get book title from textbook.
        string title = txtTitle.Text;

        //Call the GetBookByTitle method to get all books with matching title.
        DataTable dt = Book.GetBookByTitle(title);

        //Set the datasource of the data list and bind it.
        dlBooks.DataSource = dt;
        dlBooks.DataBind();
    }
}