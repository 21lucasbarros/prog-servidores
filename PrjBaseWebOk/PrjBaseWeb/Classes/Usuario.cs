using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    [Serializable]
    public class Usuario : IComparable<Usuario>
    {
        public String Nome { get; private set; }
        public String CPF { get; private set; }
        public String Login { get; private set; }
        public String Senha { get; private set; }
        public char Perfil { get; private set; }

        public String Id;

        private static int contador = 0;

        public static void AjustaId(List<Usuario> lista)
        {
            if(lista.Count == 0)
            {
                contador = 0;
                return;
            }
            Usuario u = lista[lista.Count - 1];
            int.TryParse(u.Id, out contador);
        }

        public Usuario(string nome, string cPF, string login, char perfil)
        {
            Nome = nome;
            CPF = cPF;
            Login = login;
            Perfil = perfil;
            Senha = cPF;
            Id = (++contador).ToString("D4");
        }
        
        public void Atualiza(String nome, char perfil)
        {
            Nome = nome;
            Perfil = perfil;
        }

        public void AlteraSenha(String senha)
        {
            Senha = senha;
        }

        public Usuario(string id)
        {
            Id = id;
        }

        int IComparable<Usuario>.CompareTo(Usuario usuario)
        {
            return Id.CompareTo(usuario.Id);
        }

        public override string ToString()
        {
            return string.Concat(
                Id, ", ",
                Nome, ", ",
                CPF, ", ",
                Login, ", ",
                Perfil, ", ",
                Senha.Equals(CPF) ? "Não trocou a senha" : "Trocou a senha"
            );
        }
    }
}