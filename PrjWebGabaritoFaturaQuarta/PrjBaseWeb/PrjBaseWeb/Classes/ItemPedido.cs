using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    [Serializable]
    public class ItemPedido : IComparable<ItemPedido>
    {
        private static int contador = 0;
        public String Codigo { get; private set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public ItemPedido(string codigo, Produto produto, int quantidade)
        {
            Codigo = (++contador).ToString("D6");
            Produto = produto;
            Quantidade = quantidade;
        }

        int IComparable<ItemPedido>.CompareTo(ItemPedido other)
        {
            return Codigo.CompareTo(other.Codigo);
        }
    }
}