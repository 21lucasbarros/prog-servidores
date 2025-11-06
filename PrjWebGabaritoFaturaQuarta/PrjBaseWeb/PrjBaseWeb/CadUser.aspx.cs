
using PrjCalculadoraWeb.Classes;
using PrjFaturamento.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjFaturamento
{
    public partial class CadUser : System.Web.UI.Page
    {
        private static List<Usuario> usuarios;

        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null)
            {
                Response.Redirect("LogIn.aspx", true);
                return;
            }

            if (usuarios == null)
            {
                if (File.Exists(Usuario.nomeArquivo))
                {
                    usuarios = Serializa.DesserializaUsuario(Usuario.nomeArquivo);
                    Usuario.AjustaId(usuarios);                   
                }
                else
                {
                    usuarios = new List<Usuario>();
                }
            }

            ltRelatorio.Text = Relatorio();

            btInicializaSenha.Enabled = 
            btExluir.Enabled = (Session["idUsuarioBusca"] != null);

            btOk.Text = Session["idUsuarioBusca"] == null ? "Insere" : "Altera";

        }

        protected void btLimpar_Click(object sender, EventArgs e)
        {

            btInicializaSenha.Enabled =
            btExluir.Enabled = false;

            lbMensagem.Text =
            txCPF.Text =
                txLogin.Text =
                txNome.Text = String.Empty;

            rbAdm.Checked =  
            rbUser.Checked = false;

            txCPF.Enabled =
                txLogin.Enabled =
                txNome.Enabled =  
            rbUser.Enabled =
                rbAdm.Enabled = true;

            Session["idUsuarioBusca"] = null;

            btOk.Text = "Insere";


        }

        protected void btOk_Click(object sender, EventArgs e)
        {
            if (txNome.Text.Trim().Equals(String.Empty))
            {
                lbMensagem.Text = "Digite o nome";
                return;
            }

            if (!rbAdm.Checked && !rbUser.Checked)
            {
                lbMensagem.Text = "Selecione o perfil";
                return;
            }

            if (Session["idUsuarioBusca"] != null)
            {
                int pos = (int)Session["idUsuarioBusca"];
                usuarios[pos].Atualiza(txNome.Text,
                    rbAdm.Checked ? 'A' : 'U');

                ltRelatorio.Text = Relatorio();

                Serializa.SerializaUsuario(usuarios, Usuario.nomeArquivo);

                return;

            }

            if (!ValidarCPF(txCPF.Text))
            {
                lbMensagem.Text = "CPF inválido";
                return;
            }

            if (txLogin.Text.Trim().Equals(String.Empty))
            {
                lbMensagem.Text = "Digite o login";
                return;
            }

                       

            foreach(Usuario usuario in usuarios)
            {
                if (txCPF.Text.Equals(usuario.Cpf))
                {
                    lbMensagem.Text = 
                        "Já existe um usuário com este CPF";
                    return;
                }
            }
            foreach (Usuario usuario in usuarios)
            {
                if (txLogin.Text.Equals(usuario.Login))
                {
                    lbMensagem.Text =
                        "Já existe um usuário com este Login";
                    return;
                }
            }

            Usuario u = new Usuario(txNome.Text,
                txCPF.Text,
                txLogin.Text,
                rbAdm.Checked ? 'A' : 'U');

            usuarios.Add(u);
            usuarios.Sort();

            Serializa.SerializaUsuario(usuarios, Usuario.nomeArquivo);

            ltRelatorio.Text = Relatorio();

            btLimpar_Click(btLimpar, e);          

        }

        private string Relatorio ()
        {
            Tabela tabela = new Tabela(usuarios.Count, 6, "Usuários Cadastrados");

            String[] titulos = { "Código","Nome","Cpf", "Login", 
                                 "Perfil", "Situação Senha" };

            for(int i=0; i<  usuarios.Count; i++)
            {
              
                tabela.celula[i, 0] = usuarios[i].Id;
                tabela.celula[i, 1] = usuarios[i].Nome;
                tabela.celula[i, 2] = usuarios[i].Cpf;
                tabela.celula[i, 3] = usuarios[i].Login;
                tabela.celula[i, 4] = usuarios[i].Perfil.ToString();
                tabela.celula[i, 5] = Util.ValidarCPF(usuarios[i].Senha) ?"Não trocou":"Trocou";
            }

            return tabela.tabela(titulos);
        }



        public static bool ValidarCPF(string cpf)
        {
     
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

    
            if (cpf.Length != 11)
                return false;

           
            if (cpf.Distinct().Count() == 1)
                return false;

        
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int digito1 = soma % 11;
            digito1 = digito1 < 2 ? 0 : 11 - digito1;

          
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            int digito2 = soma % 11;
            digito2 = digito2 < 2 ? 0 : 11 - digito2;

            
            return cpf[9] - '0' == digito1 && cpf[10] - '0' == digito2;
        }

        private void Mostra(Usuario u)
        {
            txCPF.Text = u.Cpf;
            txLogin.Text = u.Login;
            txNome.Text = u.Nome;           

            rbAdm.Checked = u.Perfil == 'A';
            rbUser.Checked = u.Perfil == 'U';

        }

        protected void btBusca_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txBusca.Text, out int num))
            {
                lbMensagem.Text = "ID de usuário inválido";
                return;
            }

            Usuario busca = new Usuario(num.ToString("D4"));
            int pos = usuarios.BinarySearch(busca);

            if (pos < 0)
            {                 
                    lbMensagem.Text = "ID de usuário não existe";
                    return;                 
            }           

            Session["idUsuarioBusca"] = pos;

            btOk.Text = "Altera";

            btInicializaSenha.Enabled =
            btExluir.Enabled = true;

            Mostra(usuarios[pos]);
        }

        protected void btExluir_Click(object sender, EventArgs e)
        {
            if (Session["idUsuarioBusca"] == null)
            {
                throw new Exception("Erro inesperado - Excluir ");
            }

            int pos = (int)Session["idUsuarioBusca"];

            usuarios.RemoveAt(pos);
            btLimpar_Click(btExluir, e);
            ltRelatorio.Text = Relatorio();

            Serializa.SerializaUsuario(usuarios, Usuario.nomeArquivo);
        }

        protected void btInicializaSenha_Click(object sender, EventArgs e)
        {
            if (Session["idUsuarioBusca"] == null)
            {
                throw new Exception("Erro inesperado - Inicializa senha");
            }

            int pos = (int)Session["idUsuarioBusca"];

            usuarios[pos].AlteraSenha(usuarios[pos].Cpf);            
            ltRelatorio.Text = Relatorio();

            Serializa.SerializaUsuario(usuarios, Usuario.nomeArquivo);
        }

        protected void btSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx", true);
        }
    }
}