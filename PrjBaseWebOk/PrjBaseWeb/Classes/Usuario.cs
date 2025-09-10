using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    public class Usuario : Object, IComparable<Usuario>
    {
        public String Nome { get; private set; }
        public String CPF { get; private set; }
        public String Login { get; private set; }
        public String Senha { get; private set; }
        public char Perfil { get; private set; }

        public String Id;

        private static int contador = 0;

        public Usuario(string nome, string cPF, string login, char perfil)
        {
            Nome = nome;
            CPF = cPF;
            Login = login;
            Perfil = perfil;
            Senha = cPF;
            Id = (++contador).ToString("D4");
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
                Senha.Equals(CPF) ? "Não trocou a senha" : "Trocou a senha"
            );
        }
    }
}