using PrjCalculadoraWeb.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjCalculadoraWeb
{
    public partial class CadUser : System.Web.UI.Page
    {
        private static List<Usuario> usuarios;

        private String nomeArquivo = "usuarios.dat";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (usuarios == null)
            {
                if (File.Exists(nomeArquivo))
                {
                    usuarios = Serializa.DesserializaUsuario(nomeArquivo);
                    txRelatorio.Text = Relatorio();
                }
                else
                {
                    usuarios = new List<Usuario>();
                }
            }

            btExcluir.Enabled = (Session["usuario"] != null);
        }

        protected void btLimpar_Click(object sender, EventArgs e)
        {
            txBusca.Text = 
                txCPF.Text =
                txLogin.Text =
                txNome.Text =
                lbMensagem.Text = String.Empty;

            rbADM.Checked =
                rbUSU.Checked = false;

            Session["usuario"] = null;

            btExcluir.Enabled = false;

            btOk.Text = "Cadastro";
        }

        protected void btOk_Click(object sender, EventArgs e)
        {
            if (txNome.Text.Trim().Equals(String.Empty))
            {
                lbMensagem.Text = "Nome é obrigatório";
                return;
            }
            if (!rbADM.Checked && !rbUSU.Checked)
            {
                lbMensagem.Text = "Perfil é obrigatório";
                return;
            }

            if(Session["usuario"] != null)
            {
                int pos = (int)Session["usuario"];
                usuarios[pos].Atualiza(txNome.Text, rbADM.Checked ? 'A' : 'U');
                txRelatorio.Text = Relatorio();
                Serializa.SerializaUsuario(usuarios, nomeArquivo);
                return;
            }

            if (!Util.ValidarCPF(txCPF.Text))
            {
                lbMensagem.Text = "CPF inválido";
                return;
            }
            if (txLogin.Text.Trim().Equals(String.Empty))
            {
                lbMensagem.Text = "Login é obrigatório";
                return;
            }

            Usuario u = new Usuario(txNome.Text, txCPF.Text, txLogin.Text, rbADM.Checked ? 'A' : 'U');

            foreach (Usuario usuario in usuarios)
            {
                if (u.Login.Equals(usuario.Login)) {
                    lbMensagem.Text = "Já exist um usuário com este login.";
                    return;
                }
            }

            foreach (Usuario usuario in usuarios)
            {
                if (u.CPF.Equals(usuario.CPF))
                {
                    lbMensagem.Text = "Já exist um usuário com este CPF.";
                    return;
                }
            }

            usuarios.Add(u);
            usuarios.Sort();
            btLimpar_Click(sender, e);
            Serializa.SerializaUsuario(usuarios, nomeArquivo);

            txRelatorio.Text = Relatorio();
        }

        private String Relatorio()
        {
            StringBuilder str = new StringBuilder();
            foreach (Usuario u in usuarios)
            {
                str.AppendLine(u.ToString());
            }
            return str.ToString();
        }

        private void Mostra(Usuario u)
        {
            txCPF.Text = u.CPF;
            txLogin.Text = u.Login;
            txNome.Text = u.Nome;

            rbADM.Checked = u.Perfil == 'A';
            rbUSU.Checked = u.Perfil == 'U';
        }

        protected void btBusca_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txBusca.Text, out int id))
            {
                lbMensagem.Text = "O ID do usuário deve ser um número inteiro.";
                return;
            }

            Usuario busca = new Usuario(id.ToString("D4"));

            int ind = usuarios.BinarySearch(busca);
            if(ind < 0)
            {
                lbMensagem.Text = "Não existe usuário com este ID";
                return;
            }

            Session["usuario"] = ind;
            Mostra(usuarios[ind]);
            btOk.Text = "Altera";
            btExcluir.Enabled = true;
        }

        protected void btExcluir_Click(object sender, EventArgs e)
        {
            if(Session["usuario"] == null)
            {
                return;
            }

            int pos = (int)Session["usuario"];
            usuarios.RemoveAt(pos);
            btLimpar_Click(sender, e);
            txRelatorio.Text = Relatorio();
            Serializa.SerializaUsuario(usuarios, nomeArquivo);
        }
    }
}