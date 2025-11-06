using PrjCalculadoraWeb.Classes;
using PrjFaturamento.Classes;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace PrjCalculadoraWeb
{
    public partial class FrmPedido : System.Web.UI.Page
    {
        public Usuario usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (Usuario)Session["usuario"];

            // para testes (remover quando estiver usando login)
            usuario = new Usuario("Lucas Barros", "46176835852", "21lucasbarros", 'A');

            if (usuario == null)
            {
                Response.Redirect("Login.aspx", true);
                return;
            }

            if (!IsPostBack)
            {
                CarregarClientes();
                CarregarFornecedores();
            }
        }

        private void CarregarClientes()
        {
            if (comboCliente.Items.Count == 0)
            {
                List<Cliente> lista = Cliente.Lista();
                lista.Sort();

                List<String> nomes = new List<String>();
                List<String> indices = new List<String>();

                foreach (Cliente c in lista)
                {
                    nomes.Add(c.NomeFantasia + " (" + c.Cnpj + ")");
                    indices.Add(c.Cnpj);
                }

                Util.MontaCombo(comboCliente, indices, nomes, "Selecione");
            }
        }

        private void CarregarFornecedores()
        {
            if (comboFornecedor.Items.Count == 0)
            {
                List<Fornecedor> lista = Fornecedor.Lista();
                lista.Sort();

                List<String> nomes = new List<String>();
                List<String> indices = new List<String>();

                foreach (Fornecedor f in lista)
                {
                    nomes.Add(f.NomeFantasia + " (" + f.Cnpj + ")");
                    indices.Add(f.Cnpj);
                }

                Util.MontaCombo(comboFornecedor, indices, nomes, "Selecione");
            }
        }

        protected void comboFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboProduto.Items.Clear();

            if (comboFornecedor.SelectedValue == "Selecione")
                return;

            List<Produto> lista = Produto.Lista();
            lista.Sort();

            List<String> nomes = new List<String>();
            List<String> indices = new List<String>();

            foreach (Produto p in lista)
            {
                if (p.fornecedor.Cnpj == comboFornecedor.SelectedValue)
                {
                    nomes.Add(p.Nome + " - " + p.apresentacao.Descricao);
                    indices.Add(p.Codigo);
                }
            }

            Util.MontaCombo(comboProduto, indices, nomes, "Selecione");
        }
    }
}
