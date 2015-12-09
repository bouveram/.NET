using FormationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormationWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BookRepository repo = new BookRepository { Entities = new FormationEntities() };
            Label3.Text = repo.GetById(int.Parse(TextBox1.Text)).Title;
        }
    }
}