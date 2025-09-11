using PrjCalculadoraWeb.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjCalculadoraWeb
{
    public partial class Default : System.Web.UI.Page
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
                }
                else
                {
                    usuarios = new List<Usuario>();
                }
            }
        }

        protected void btOk_Click(object sender, EventArgs e)
        {
            if (Util.ValidarCPF(txSenha.Text))
            {
                tbRecadastra.Visible = true;
                return;
            }

            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Login.Equals(txUsuario.Text) && usuario.Senha.Equals(txSenha.Text))
                {
                    Response.Redirect("CadUser.aspx", true);
                    return;
                }
            }

            lbMensagem.Text = "Usuario não encontrado!";
        }

        protected void btOk2_Click(object sender, EventArgs e)
        {
            if (txSenhaA.Text.Length < 8)
            {
                lbMensagem.Text = "Use pelo menos 8 caracteres para senha";
                return;
            }

            if (!txSenhaA.Text.Equals(txSenhaB.Text))
            {
                lbMensagem.Text = "Senhas não conferem.";
                return;
            }

            lbMensagem.Text = "";

            bool temMaiuscula = txSenhaA.Text.Any(char.IsUpper);
            bool temMinuscula = txSenhaA.Text.Any(char.IsLower);
            bool temNumero = txSenhaA.Text.Any(char.IsDigit);
            bool temSimboloEspecial = txSenhaA.Text.Any(ch => !char.IsLetterOrDigit(ch));
            bool temEspacos = txSenhaA.Text.Contains(" ");

            string mensagemFaltando = "";

            if (!temMaiuscula) mensagemFaltando += "A senha precisa de uma letra maiúscula. ";
            if (!temMinuscula) mensagemFaltando += "A senha precisa de uma letra minúscula. ";
            if (!temNumero) mensagemFaltando += "A senha precisa de um número de 0 a 9. ";
            if (!temSimboloEspecial) mensagemFaltando += "A senha precisa de um símbolo especial. ";
            if (temEspacos) mensagemFaltando += "A senha não pode conter espaços. ";

            if (!string.IsNullOrEmpty(mensagemFaltando))
            {
                lbMensagem.Text = mensagemFaltando.Trim();
                return;
            }

            for (int i = 0; i < usuarios.Count; i++)
            {
                if (txUsuario.Text.Equals(usuarios[i].Login))
                {
                    usuarios[i].AlteraSenha(txSenhaA.Text);
                    Serializa.SerializaUsuario(usuarios, nomeArquivo);
                    tbRecadastra.Visible = false;
                    return;
                }
            }

            lbMensagem.Text = "Usuário não encontrado";
        }
    }
}