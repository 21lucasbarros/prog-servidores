using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjFaturamento.Classes
{
    [Serializable]
    public class Contato
    {
        public Contato(
            string nome, 
            string cpf, 
            string email, 
            string cargo, 
            string telFixo, 
            string telMovel)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Cargo = cargo;
            TelFixo = telFixo;
            TelMovel = telMovel;
        }

        public String Nome { get; private set; }
        public String Cpf { get; private set; }

        public String Email { get; private set; }
        public String Cargo { get; private set; }

        public String TelFixo { get; private set; }
        public String TelMovel { get; private set; }
    }
}