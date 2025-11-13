using PrjFaturamento.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    [Serializable]
    public class Contato
    {
        public Contato(string nome, string cpf, string email, string telFixo, string telMovel)
        {
            if (!Util.ValidarCPF(cpf))
            {
                throw 
                    new ArgumentException("Cpf do contato inválido");
            }

            Nome = nome;
            Cpf = cpf;
            Email = email;
            TelFixo = telFixo;
            TelMovel = telMovel;
        }

        public String Nome { get; private set; }
        public String Cpf { get; private set; }
        public String Email { get; private set; }
        public String TelFixo { get; private set; }
        public String TelMovel { get; private set; }

    }
}