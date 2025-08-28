using PrjCalculadoraWeb.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjCalculadoraWeb
{
    public partial class FrmLogin1 : System.Web.UI.Page
    {
        //Qualquer tipo de static é aplication
        private static List<Usuario> usuarios;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(usuarios == null) 
            {
                usuarios = new List<Usuario>();
                usuarios.Add(new Usuario("João", "1111111111111", 'M', new DateTime(2004, 03, 02), "joao", "12345"));
                usuarios.Add(new Usuario("Janaina", "2111111111111", 'F', new DateTime(2004, 03, 02), "janaina", "12345"));
                usuarios.Add(new Usuario("Carol", "3111111111111", 'F', new DateTime(2004, 03, 02), "carol", "12345"));
                usuarios.Add(new Usuario("Correia", "4111111111111", 'M', new DateTime(2004, 03, 02), "correia", "12345"));
                usuarios.Add(new Usuario("Lins", "5111111111111", 'F', new DateTime(2004, 03, 02), "lins", "12345"));
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            foreach(Usuario u in usuarios)
            {
                if(u.Verifica(txLogin.Text, txSenha.Text))
                {
                    Session["usuario"] = u;
                    Response.Redirect("index.aspx", true);
                    return;
                }
            }

            lbMensage.Text = "Usuário não reconhecido.";
        }
    }
}