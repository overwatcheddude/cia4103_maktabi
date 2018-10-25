using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class BookDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            //Read query string
            int id = int.Parse(Request.QueryString["id"]);

            //Calls GetAllBooks method which returns selected book ID, and store it in a DataTable datatype.
            DataTable dataTableBooks = Book.GetBookByID(id);

            //Set the data source to the DataTable, and then bind (apply) it.
            dlBooks.DataSource = dataTableBooks;
            dlBooks.DataBind();

            //Gets the reviews
            DataTable dataTableReviews = BookReview.GetReviewsByBook(id);

            dlReviews.DataSource = dataTableReviews;
            dlReviews.DataBind();
        }
        else
        {
            Response.Redirect("SearchBook.aspx");
        }
    }
}