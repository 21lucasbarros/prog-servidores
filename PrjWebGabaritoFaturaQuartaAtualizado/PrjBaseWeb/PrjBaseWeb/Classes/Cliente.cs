using PrjFaturamento.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// TP 22/10/2025
// 

namespace PrjCalculadoraWeb.Classes
{
    [Serializable]
    public class Cliente : PessoaJuridica, IComparable<Cliente>
    {
       

        public Contato contato;
        public string Endereco { get; set; }

        public Cliente(String cpnj) : base(cpnj, "", "", "", "")
        {
            //
        }

        public Decimal LimiteCredito { get; private set; }


        public Cliente(
            string cnpj, 
            string razaoSocial, 
            string nomeFantasia, 
            string inscricaoEstadual, 
            string inscricaoMunicipal) : 
            base(cnpj, razaoSocial, 
                nomeFantasia, 
                inscricaoEstadual, 
                inscricaoMunicipal)
        {
            LimiteCredito = 0;
            Endereco = String.Empty;
        }

        public void SubLimite(decimal valor)
        {
            if (valor <= LimiteCredito)
            {
                LimiteCredito -= valor;
                return;
            }

            throw 
                new ArgumentException("Valor passado é inválido: SubLimite");
        }

        public void AddLimite(decimal valor)
        {
            if (valor > 0)
            {
                LimiteCredito += valor;
                return;
            }

            throw new ArgumentException("Valor passado é inválido: AddLimite");
        }

        public static String nomeArquivo =
         String.Format("{0}{1}",
             AppDomain.CurrentDomain.BaseDirectory,
             "Dados\\dadosCliente.DAT");

        public static void CriaBaseDeClientes(String nomeArquivo)
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
               
                Contato helio = new Contato("Helio Rangel", "323.692.807/78", "halrangel@yaho.com.br", "", "(13) 9 9767 5502");
                Contato maria = new Contato("Maria Luiza", "210.801.420-96", "maria.luiza@yaho.com", "", "(13) 9 8900 5734");

                Cliente c1 = new Cliente("80.439.967/0001-03","Adega da Vila LTDA","Adega Villa","","");
                c1.contato = helio;
                c1.Endereco = "Av. Cons. Nébias 876, Santos/SP";
                c1.AddLimite(100000);

                
                Cliente c2 = new Cliente("36.624.270/0001-10", "Bebidas São Jorge LTDA","Adega São Jorge", "", "");
                c2.contato = helio;
                c2.Endereco = "Av. Cons. Nébias 1987, Santos/SP";
                c2.AddLimite(50000);


                Cliente c3 = new Cliente("19.778.723/0001-44", "Mercado São Pedro LTDA","Mercado Supimpa", "", "");
                c3.contato = helio;
                c3.Endereco = "Av. Ana Costa 1300, Santos/SP";
                c3.AddLimite(20000);

                Cliente c4 = new Cliente("47.704.675/0001-85", "Restaurante Paris LTDA","Paris Lanches", "", "");
                c4.contato = maria;
                c4.Endereco = "Rua Carvalho de Mendonça 345, Santos/SP";
                c4.AddLimite(5000);


                Cliente c5 = new Cliente("39.656.862/0001-02", "Atacado De Bebidas do Bairro LTDA","Atacadão Do Bairro", "", "");
                c5.contato = maria;
                c5.Endereco = "Rua Carvalho de Mendonça 245, Santos/SP";
                c5.AddLimite(5000);


                Cliente c6 = new Cliente("80.619.818/0001-26", "Bar e Restaurante Capricho LTDA","Bar Capricho", "", "");
                c6.contato = maria;
                c6.Endereco = "Pedro Américo 34, Santos/SP";
                c6.AddLimite(5000);

                clientes.Add(c1);
                clientes.Add(c2);
                clientes.Add(c3);
                clientes.Add(c4);
                clientes.Add(c5);
                clientes.Add(c6);

                Serializa.SerializaCliente(clientes, nomeArquivo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Cliente> Lista()
        {
            return Serializa.DesserializaCliente(nomeArquivo);
        }

        int IComparable<Cliente>.CompareTo(Cliente other)
        {
            return Cnpj.CompareTo(other.Cnpj);
        }
    }
}