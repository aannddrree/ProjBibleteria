using Dados;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            DadosEntities context = new DadosEntities();

            tb_bilheteria bilheteria = new tb_bilheteria()
            {
                descricao = TxtDescricao.Text,
                dt_evento = TxtDataEvento.Text,
                local = TxtLocal.Text,
                qtd_pessoas = int.Parse(TxtQtdPessoas.Text)
            };

            /*Bilheteria bilheteria = new Bilheteria()
            {
                Descricao = TxtDescricao.Text,
                DataEvento = DateTime.Parse(TxtDataEvento.Text),
                Local = TxtLocal.Text,
                QtdPessoas = int.Parse(TxtQtdPessoas.Text)
            };*/

            if (String.IsNullOrEmpty(idItem))
            {
                //new BilheteriaDB().Save(bilheteria);
                context.tb_bilheteria.Add(bilheteria);
                lblMSG.Text = "Registro Inserido!";
            }
            else
            {
                //bilheteria.Id = int.Parse(idItem);
                //new BilheteriaDB().Update(bilheteria);
                int idNew = int.Parse(idItem);
                tb_bilheteria b = context.tb_bilheteria.First(c => c.Id == idNew);
                b.descricao = TxtDescricao.Text;
                b.dt_evento = TxtDataEvento.Text;
                b.local = TxtLocal.Text;
                b.qtd_pessoas = int.Parse(TxtQtdPessoas.Text);

                lblMSG.Text = "Registro Atualizado!";
            }

            context.SaveChanges();
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
                //Bilheteria bilheteria = new BilheteriaDB().FindById(int.Parse(idItem));
                DadosEntities context = new DadosEntities();
                int idNew = int.Parse(idItem);
                tb_bilheteria bilheteria  = context.tb_bilheteria.First(c => c.Id == idNew);

                lblId.Visible = true;
                TxtId.Visible = true;

                /*
                TxtDataEvento.Text = bilheteria.DataEvento.ToString();
                TxtDescricao.Text = bilheteria.Descricao;
                TxtId.Text = bilheteria.Id.ToString();
                TxtLocal.Text = bilheteria.Local;
                TxtQtdPessoas.Text = bilheteria.QtdPessoas.ToString();
                */

                TxtDataEvento.Text = bilheteria.dt_evento;
                TxtDescricao.Text = bilheteria.descricao;
                TxtId.Text = bilheteria.Id.ToString();
                TxtLocal.Text = bilheteria.local;
                TxtQtdPessoas.Text = bilheteria.qtd_pessoas.ToString();
            }
        }  
    }
}