using PrjFaturamento.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    [Serializable]
    public class Produto : IComparable<Produto>
    {
        private static int contador = 0;

        public static String nomeArquivo =
       String.Format("{0}{1}",
           AppDomain.CurrentDomain.BaseDirectory,
           "Dados\\dadosProduto.DAT");


        public Produto(Fornecedor fornecedor, 
            string nome, 
            int estoqueMinimo,
            Apresentacao apresentacao)
        {
           
            this.fornecedor = fornecedor;
            Nome = nome;            
            EstoqueMinimo = estoqueMinimo;
            this.apresentacao = apresentacao;

            Codigo = (++contador).ToString("D6");
        }

        public String Codigo { get; private set; }
        public Fornecedor fornecedor { get; private set; }
        public string Nome { get; private set; }

        public Decimal Preco { get; set; }
        public int Estoque { get; set; }

        public int EstoqueMinimo { get; set; }

        public Apresentacao apresentacao { get; private set; }

        int IComparable<Produto>.CompareTo(Produto other)
        {
            return Codigo.CompareTo(other.Codigo);
        }

        public static List<Produto> Lista()
        {
            return Serializa.DesserializaProduto(nomeArquivo);
        }

    }
}