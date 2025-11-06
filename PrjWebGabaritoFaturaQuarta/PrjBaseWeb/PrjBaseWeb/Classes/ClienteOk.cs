using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjFaturamento.Classes
{
    [Serializable]
    public class Cliente : PessoaJuridica
    {
        public static String nomeArquivo = AppDomain.CurrentDomain.BaseDirectory + "Dados/dadosCliente.DAT";

        private Decimal limiteCredito;
        public String Endereco { get; set; }   
        
        public Contato contato { get; private set; }
        public Cliente(
            string razaoSocial, 
            string nomeFantasia, 
            string inscricaoMunicipal, 
            string incricaoEstadual, 
            string cnpj) : 
            base(razaoSocial, 
                nomeFantasia, 
                inscricaoMunicipal, 
                incricaoEstadual, 
                cnpj)
        {
            limiteCredito = 0;
            Endereco = String.Empty;
        }

        public void AddLimiteCredito(Decimal limiteCredito)
        {
            if (limiteCredito > 0)
            {
                this.limiteCredito += limiteCredito;
            } 
            else
            {
                throw new
                    ArgumentException("Limite deve ser positivo");
            }
        }

        public void SubLimiteCredito(Decimal limiteCredito)
        {
            if (limiteCredito > this.limiteCredito)
            {
                throw new
                    ArgumentException("Limite Insuficiente");
            }

            this.limiteCredito -= limiteCredito;
        }

        public static void MontaTabelaDeClientes(String nomeDoArquivo)
        {
          
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                Contato helio = new Contato("Helio Rangel",
                    "323.692.807/78", "halrangel@yahoo.com.br", "Professor", "", "(13) 9 9767 5502");

                Contato maria = new Contato("Maria Helena",
                   "323.692.807/78", "maria.helena@yahoo.com", "Compradora", "", "(13) 9 7654 6677");

                Cliente c1 = new Cliente("Pedreira Pedra Dura LTDA",
                    "Pedra Dura", "", "", "52.964.674/0001-00");
                c1.contato = helio;
                c1.Endereco = "Estrada da colina, KM 12, Vitória/ES";

                Cliente c2 = new Cliente("Bar e Restaurante do Jose LTDA",
                    "Bar Do Zé", "", "", "05.850.773/0001-80");
                c2.contato = helio;
                c2.Endereco = "Conselheiro Nébias, 300, Santos/SP";

                Cliente c3 = new Cliente("Confecções da Moda Chique LTDA",
                    "Moda Chique", "", "", "38.322.285/0001-50");
                c3.contato = maria;
                c3.Endereco = "Carvalho de Mendonça 3456, Santos/SP";

                Cliente c4 = new Cliente("Armarinho Aguia de Ouro LTDA",
                    "Aguia de Ouro", "", "", "53.971.288/0001-08");
                c4.contato = maria;
                c4.Endereco = "Avenida Ana Costa 1243, Santos/SP";

                Cliente c5 = new Cliente("Casa de Carnes Boi Gordo LTDA",
                    "Boi Gordo", "", "", "79.503.424/0001-29");
                c5.contato = helio;
                c5.Endereco = "Avenida Ana Costa 187, Santos/SP";

                Cliente c6 = new Cliente("Sapataria & Reformas de Malas Santo Antônio",
                    "Sapataria Santo Antônio", "", "", "78.124.160/0001-30");
                c6.contato = helio;
                c6.Endereco = "Av. São João 876, Centro, São Paulo/SP";

                clientes.Add(c1);
                clientes.Add(c2);
                clientes.Add(c3);
                clientes.Add(c4);
                clientes.Add(c5);
                clientes.Add(c6);

                Serializa.SerializaCliente(clientes, nomeDoArquivo);

            } catch (Exception)
            {
                throw;
            }

        }

    }
}