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
        public string Codigo { get; private set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public ItemPedido(Produto produto, int quantidade)
        {
            Codigo = (++contador).ToString("D6");
            Produto = produto;
            Quantidade = quantidade;
        }

        int IComparable<ItemPedido>.CompareTo(ItemPedido other)
        {
            return Codigo.CompareTo(other.Codigo);
        }

        public override string ToString()
        {
            return String.Format("{0}{1}{2}{3}{4}{5}{6}",
                Codigo.PadLeft(8),
                Produto.Codigo.PadLeft(8),
                Produto.Nome.PadRight(20),
                Produto.apresentacao.Descricao.PadRight(20),
                String.Format("{0:###,##0.00}", Quantidade).PadLeft(10),
                String.Format("{0:###,##0.00}", Produto.Preco).PadLeft(10),
                String.Format("{0:###,##0.00}", Produto.Preco * Quantidade).PadLeft(10)
            );
        }
    }
}