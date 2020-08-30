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
            DadosEntities context = new DadosEntities();
            List<tb_bilheteria> list = context.tb_bilheteria.ToList<tb_bilheteria>();

            GDVBilhete.DataSource = list; //new BilheteriaDB().FindAll();
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

            //Bilheteria bilheteria = new BilheteriaDB().FindById(id);
            DadosEntities context = new DadosEntities();
            tb_bilheteria bilheteria = context.tb_bilheteria.First(c => c.Id == id);

            if (e.CommandName == "A")
            {
                Response.Redirect("CadastroBilhete.aspx?idItem=" + id);
            }
            else if (e.CommandName == "E")
            {
                lblExcluir.Text = id.ToString();
                lblMsg.Text = "Tem certeza que deseja excluir este registro?";
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

            DadosEntities context = new DadosEntities();
            tb_bilheteria bilheteria = context.tb_bilheteria.First(c => c.Id == id);
            context.tb_bilheteria.Remove(bilheteria);
            context.SaveChanges();

            //new BilheteriaDB().Delete(id);
            LoadTable();
        }
    }
}