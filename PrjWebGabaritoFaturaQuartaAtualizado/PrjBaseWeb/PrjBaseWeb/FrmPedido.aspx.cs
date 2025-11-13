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

        public Pedido pedido;

        protected void Page_Load(object sender, EventArgs e)
        {
            pedido = (Pedido)Session["pedido"];


            //Cliente.CriaBaseDeClientes(Cliente.nomeArquivo);
            //Fornecedor.CadastroFornecedor(Fornecedor.nomeArquivo);

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
                    nomes.Add(c.NomeFantasia + " (" + String.Format("{0:###,###,##0.00}", c.LimiteCredito) + ")");
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

        protected void btOk_Click(object sender, EventArgs e)
        {
            if (pedido == null)
            {
                List<Cliente> lista = Cliente.Lista();
                lista.Sort();

                int posCli = lista.BinarySearch(new Cliente(comboCliente.SelectedValue));

                if (posCli == -1)
                {
                    Util.BoxOkJavaScript("Cliente não encontrado!", Page);
                    return;
                }

                Session["pedido"] = pedido = new Pedido(lista[posCli], usuario);
            }

            try
            {
                if (!int.TryParse(txQuantidade.Text, out int quantidade) || quantidade <= 0)
                {
                    Util.BoxOkJavaScript("Quantidade inválida!", Page);
                    return;
                }

                List<Produto> listaP = Produto.Lista();
                listaP.Sort();

                int posPro = listaP.BinarySearch(new Produto(comboProduto.SelectedValue));

                if (posPro == -1)
                {
                    Util.BoxOkJavaScript("Produto não encontrado!", Page);
                    return;
                }

                Produto prod = listaP[posPro];

                decimal subtotal = prod.Preco * quantidade;

                if (pedido.Comprador.LimiteCredito < subtotal)
                {
                    Util.BoxOkJavaScript("Limite de crédito insuficiente!", Page);
                    return;
                }

                if (quantidade > prod.Estoque)
                {
                    Util.BoxOkJavaScript("Estoque insuficiente!", Page);
                    return;
                }

                ItemPedido item = new ItemPedido(prod, quantidade);

                pedido.Add(item);

                pedido.Comprador.SubLimite(subtotal);

                lbSaldo.Text = "Saldo: " + pedido.Comprador.LimiteCredito.ToString("N2");

                txtRelatorio.Text = pedido.Relatorio();

                Util.BoxOkJavaScript("Item inserido com sucesso!", Page);
            }
            catch (Exception ex)
            {
                Util.BoxOkJavaScript(ex.Message, Page);
            }
        }


        protected void comboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboFornecedor.Enabled =
                comboProduto.Enabled =
                comboCliente.SelectedIndex > 0;

            List<Cliente> lista = Cliente.Lista();
            lista.Sort();

            int posCli = lista.BinarySearch(new Cliente(comboCliente.SelectedValue));
            if (posCli == -1)
            {
                Util.BoxOkJavaScript("Cliente não encontrado!", Page); 
                return;
            }

            DadosCliente(lista[posCli]);
        }

        private void DadosCliente(Cliente cli)
        {
            lbContato.Text = "Contato: " + cli.contato.Nome + " (" + cli.contato.TelMovel + ")";
            lbData.Text = "Data: " + DateTime.Now.ToString("dd/MM/yyyy");
            lbSaldo.Text = "Saldo: " + String.Format("{0:###,###,##0.00}", cli.LimiteCredito);
        }

        protected void comboProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            divQuantidade.Visible = true;
        }
    }
}
