using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    public class Paciente : Pessoa
    {
        public IMC imc;
        public string Registro { get; private set; }

        private static int contID = 0;

        public Paciente(string nome, 
            string cpf, 
            char sexo, 
            DateTime dtNascimento, float peso, float altura) : base(nome, cpf, sexo, dtNascimento)
        {
            imc = new IMC(peso, altura);
            Registro = (++contID).ToString();
        }
    }
}