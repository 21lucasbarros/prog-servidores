using PrjCalculadoraWeb.Classes;
using System;
using System.Collections.Generic;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (usuarios == null)
            {
                usuarios = new List<Usuario>();
            }
        }

        protected void btLimpar_Click(object sender, EventArgs e)
        {
            txCPF.Text =
                txLogin.Text =
                txNome.Text =
                lbMensagem.Text = String.Empty;

            rbADM.Checked =
                rbUSU.Checked = false;

            Session["usuario"] = null;
        }

        private bool ValidarCPF(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
                return false;

            int CalcularDigito(int length)
            {
                int soma = 0;
                for (int i = 0; i < length; i++)
                    soma += (cpf[i] - '0') * (length + 1 - i);

                int resto = soma % 11;
                return resto < 2 ? 0 : 11 - resto;
            }

            int digito1 = CalcularDigito(9);
            int digito2 = CalcularDigito(10);

            return cpf.EndsWith($"{digito1}{digito2}");
        }

        protected void btOk_Click(object sender, EventArgs e)
        {
            if (!ValidarCPF(txCPF.Text))
            {
                lbMensagem.Text = "CPF inválido";
                return;
            }
            if (txNome.Text.Trim().Equals(String.Empty))
            {
                lbMensagem.Text = "Nome é obrigatório";
                return;
            }
            if (txLogin.Text.Trim().Equals(String.Empty))
            {
                lbMensagem.Text = "Login é obrigatório";
                return;
            }
            if (!rbADM.Checked && !rbUSU.Checked)
            {
                lbMensagem.Text = "Perfil é obrigatório";
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
        }
    }
}