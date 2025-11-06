using PrjFaturamento.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    [Serializable]
    public class Pedido : IComparable<Pedido>
    {
        public string Numero { get; private set; }
        public Cliente Comprador { get; private set; }
        public DateTime DataPedido { get; private set; }
        public Usuario Vendedor { get; private set; }

        private static int contador = 0;
        private List<ItemPedido> itens;

        public Pedido(Cliente comprador, Usuario vendedor)
        {
            Comprador = comprador;
            DataPedido = DateTime.Now;
            Vendedor = vendedor;
            Numero = (++contador).ToString("D6");
            itens = new List<ItemPedido>();
        }

        public void Add(ItemPedido item) 
        {
            if(item.Quantidade > item.Produto.Estoque)
            {
                throw new Exception("Estoque insuficiente.");
            }
            itens.Add(item);
            item.Produto.Estoque -= item.Quantidade;
            return;
        }

        public bool Remove(ItemPedido item)
        {
            bool ok = itens.Remove(item);

            if(ok) item.Produto.Estoque += item.Quantidade;

            return ok;
        }

        public Decimal Total()
        {
            Decimal total = 0;
            foreach(ItemPedido item in itens)
            {
                total += item.Produto.Preco;
            }

            return total;
        }

        int IComparable<Pedido>.CompareTo(Pedido other)
        {
            return Numero.CompareTo(other.Numero);
        }
    }
}