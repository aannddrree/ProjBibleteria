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
    public partial class CadastroBilhete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataPage();
            }
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {

            string idItem = Request.QueryString["idItem"];

            Bilheteria bilheteria = new Bilheteria()
            {
                Descricao = TxtDescricao.Text,
                DataEvento = DateTime.Parse(TxtDataEvento.Text),
                Local = TxtLocal.Text,
                QtdPessoas = int.Parse(TxtQtdPessoas.Text)
            };

            if (String.IsNullOrEmpty(idItem))
            {
                new BilheteriaDB().Save(bilheteria);
                lblMSG.Text = "Registro Inserido!";
            }
            else
            {
                bilheteria.Id = int.Parse(idItem);
                new BilheteriaDB().Update(bilheteria);
                lblMSG.Text = "Registro Atualizado!";
            }
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        private void LoadDataPage()
        {
            string idItem = Request.QueryString["idItem"];
            
            if (!String.IsNullOrEmpty(idItem))
            {
                Bilheteria bilheteria = new BilheteriaDB().FindById(int.Parse(idItem));

                lblId.Visible = true;
                TxtId.Visible = true;

                TxtDataEvento.Text = bilheteria.DataEvento.ToString();
                TxtDescricao.Text = bilheteria.Descricao;
                TxtId.Text = bilheteria.Id.ToString();
                TxtLocal.Text = bilheteria.Local;
                TxtQtdPessoas.Text = bilheteria.QtdPessoas.ToString();
            }
        }  
    }
}