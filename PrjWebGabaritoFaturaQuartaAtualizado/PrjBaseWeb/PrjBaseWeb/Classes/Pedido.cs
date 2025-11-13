using PrjFaturamento.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public String Relatorio()
        {
            StringBuilder txt = new StringBuilder();

            txt.AppendLine(

                String.Format("{0}{1}{2}{3}{4}{5}{6}",
                "Item".PadLeft(8),
                "Código".PadLeft(8),
                "Produto".PadRight(20),
                "Apresentação".PadRight(20),
                "Quantidade".PadLeft(10),
                "Preço".PadLeft(10),
                "Total".PadLeft(10))
                );

            foreach(ItemPedido item in itens)
            {
                txt.AppendLine(item.ToString());
            }

            return txt.ToString();
        }

        int IComparable<Pedido>.CompareTo(Pedido other)
        {
            return Numero.CompareTo(other.Numero);
        }
    }
}