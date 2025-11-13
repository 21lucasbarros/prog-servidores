using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    [Serializable]
    public class Apresentacao
    {
        public static String nomeArquivo =
        String.Format("{0}{1}",
         AppDomain.CurrentDomain.BaseDirectory,
         "Dados\\dadosApresentacao.DAT");
        public Apresentacao(string descricao, int capacidade)
        {
            Descricao = descricao;
            Capacidade = capacidade;
        }

        public string Descricao { get; set;}
        public int Capacidade { get; private set;}
    }
}