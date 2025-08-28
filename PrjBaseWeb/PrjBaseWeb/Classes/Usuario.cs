using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    public class Usuario : Pessoa
    {
        public Usuario(string nome, string cpf, char sexo, DateTime dtNascimento, string login, string senha) 
            : base(nome, cpf, sexo, dtNascimento)
        {
            Login = login;
            Senha = senha;
        }

        public string Login { get; private set; }
        public string Senha { get; private set; }

        public bool Verifica(string login, string senha)
        {
            return this.Login.Equals(login) && 
                   this.Senha.Equals(senha);
        }
    }
}