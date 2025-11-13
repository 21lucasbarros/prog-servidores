using PrjCalculadoraWeb.Classes;
using PrjFaturamento.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjFaturamento
{
    public partial class Default : System.Web.UI.Page
    {
        private static List<Usuario> usuarios;      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (usuarios == null)
            {
                if (File.Exists(Usuario.nomeArquivo))
                {
                    usuarios = Serializa.DesserializaUsuario(Usuario.nomeArquivo);
                }
                else
                {
                    usuarios = new List<Usuario>();
                }
            }

            lbMensagem.Text = String.Empty;
        }

        protected void btOk_Click(object sender, EventArgs e)
        {
            if (Util.ValidarCPF(txSenha.Text))
            {
                foreach (Usuario usuario in usuarios)
                {
                    if (usuario.Login == txLogin.Text.Trim())
                    {
                        String formatado = Util.FormatarCpf(txSenha.Text);
                        if (usuario.Senha != formatado)
                        {
                            lbMensagem.Text = "Usuário Já trocou a senha";

                            return;
                        }
                    }
                }

                tbRecadastra.Visible = true;
                return;
            }

            //if (usuarios.Count == 0) // Para o caso de nenhum usuário cadastrado
            //{
            //    Usuario primeiro = new Usuario("Helio Rangel", "323.692.807-78", "helio.rangel", 'A');
            //    primeiro.AlteraSenha("Brasil@2000");
            //    List<Usuario> u = new List<Usuario>();
            //    u.Add(primeiro);
            //    Serializa.SerializaUsuario(u, Usuario.nomeArquivo);
            //    Session["usuario"]=primeiro;
            //    Response.Redirect("CadUser.aspx", true);
            //    return;
            //}

            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Login.Equals(txLogin.Text) &&
                    (usuario.Senha.Equals(Util.MyHash(txSenha.Text,txLogin.Text)) 
                         /* || usuario.Senha.Equals(txSenha.Text) */))
                {                    

                    Session["usuario"] = usuario;

                    if (usuario.Perfil == 'U')
                    {
                        Response.Redirect("Faturamento.aspx", true);
                    }
                    else
                    {
                        tablePerfil.Visible = true;
                    }
                    try
                    {
                        Cliente.CriaBaseDeClientes(Cliente.nomeArquivo);
                        Fornecedor.CadastroFornecedor(Fornecedor.nomeArquivo);
                    } 
                    catch (Exception ex)
                    {
                        lbAviso.Text = ex.Message;
                    }
                    return;
                }
            }

            lbMensagem.Text = "Usuário não encontrado!";
            Session["usuario"] = null;
        }

        protected void btOk2_Click(object sender, EventArgs e)
        {
            String ok = Util.ValidaSenha(txSenhaA.Text);
            if (ok != "")
            {
                lbMensagem.Text = ok;
                return;
            }

            if (!txSenhaA.Text.Equals(txSenhaB.Text))
            {
                lbMensagem.Text = "Senhas não conferem!";
                return;
            }

            lbMensagem.Text = Usuario.ValidaSenha(txSenhaB.Text);

            if (lbMensagem.Text != String.Empty)
            {
                return;
            }

            for (int i = 0; i < usuarios.Count; i++)
            {
                if (txLogin.Text.Equals(usuarios[i].Login))
                {

                    

                    usuarios[i].AlteraSenha(txSenhaA.Text);
                    Serializa.SerializaUsuario(usuarios, Usuario.nomeArquivo);
                    tbRecadastra.Visible = false;
                    return;
                }
            }

            lbMensagem.Text = "Usuário não encontrado!";
            Session["usuario"] = null;

        }
    }
}