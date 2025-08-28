using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    public class Pessoa
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public char Sexo { get; private set; }
        public DateTime DtNascimento { get; private set; }

        public Pessoa(string nome, string cpf, char sexo, DateTime dtNascimento)
        {
            Nome = nome;
            Cpf = NormalizarCpf(cpf);
            Sexo = sexo;
            DtNascimento = dtNascimento;
        }

        public static string NormalizarCpf(string cpf)
        {
            return new string(cpf.Where(char.IsDigit).ToArray());
        }
    }
}