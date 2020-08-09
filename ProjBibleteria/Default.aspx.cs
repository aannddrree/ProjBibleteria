using Dados;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjBibleteria
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void LoadTable()
        {
            GDVBilhete.DataSource = new BilheteriaDB().FindAll();
            GDVBilhete.DataBind();
        }

        protected void BtnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroBilhete.aspx");
        }

        protected void GDVBilhete_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int line = int.Parse(e.CommandArgument.ToString());
            int id = int.Parse(GDVBilhete.Rows[line].Cells[0].Text);

            Bilheteria bilheteria = new BilheteriaDB().FindById(id);

            if (e.CommandName == "A")
            {
                Response.Redirect("CadastroBilhete.aspx?idItem=" + id);
            }
            else if (e.CommandName == "E")
            {
                lblExcluir.Text = id.ToString();
                DisplayModal(this);
            }
        }

        private void DisplayModal(Page page)
        {
            ClientScript.RegisterStartupScript(typeof(Page), 
                                               Guid.NewGuid().ToString(), 
                                               "MostrarModal();", 
                                               true);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblExcluir.Text);
            new BilheteriaDB().Delete(id);
        }
    }
}