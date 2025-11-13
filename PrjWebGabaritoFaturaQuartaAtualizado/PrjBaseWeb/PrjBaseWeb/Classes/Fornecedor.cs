using PrjFaturamento.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    // TP de 29/10/2025
    // Popular 3 listas, Fornecedores, Produtos e
    //                                  Apresentacao
    // Fornecedores: Pelo menos 6 fornecedores
    // Apresentação: Pelo menos 10 apresentações 
    // Produtos: Pelo menos 30 produtos;

    // Fazer todo o cadastro na classe Fornecedor
    // Email: halrangel@yahoo.com.br
    // Colar no corpo do email a classe Fornecedor
    // (Não é necessário colar os .DAT)
    // Assunto: FAT-FOR-PRO-MANHA Nome do aluno
    // 
    // Usuário: helio.rangel, Senha: Brasil@2000


    [Serializable]
    public class Fornecedor : PessoaJuridica, IComparable<Fornecedor>
    {
        public static String nomeArquivo =
       String.Format("{0}{1}",
           AppDomain.CurrentDomain.BaseDirectory,
           "Dados\\dadosFornecedor.DAT");

        public Contato contato;
        public Fornecedor(
            string cnpj, 
            string razaoSocial, 
            string nomeFantasia, 
            string inscricaoEstadual, 
            string inscricaoMunicipal) : 
            base(cnpj, razaoSocial, nomeFantasia, inscricaoEstadual, inscricaoMunicipal)
        {

        }

        public static string CadastroFornecedor(String nomeArquivo)
        {
            try
            {

                Contato ceci = new Contato("Cecilia", "831.981.740-40",
                    "cecilia@yahoo.com", "", "(13) 8765 7890");

                Contato ana = new Contato("Ana Clara", "721.655.840-51",
                  "ana.clara.yahoo.com", "", "(13) 8890 7678");

                Contato artur = new Contato("Arthur Bueno", "541.839.880-63",
                  "arthur.Bueno@yahoo.com", "", "(13) 4856 7657");

                Fornecedor coca = new Fornecedor("16.867.403/0001-72",
                    "Cocacola Bebidas SA", "Cocacola", "123456", "54321");
                coca.contato = ceci;

                Fornecedor skin = new Fornecedor("50.626.082/0001-52",
                    "Schincariol Bebidas SA", "Schin", "123456", "54321");
                skin.contato = ceci;

                Fornecedor ambev = new Fornecedor("21.500.526/0001-00",
                   "Ambev industrias de Bebidas SA", "AMBEV", "123456", "54321");
                ambev.contato = ana;

                Fornecedor bonafont = new Fornecedor("39.096.488/0001-38",
                   "Aguas Minerais BONAFONT SA", "Bonafont", "", "");
                bonafont.contato = ana;

                Fornecedor heineken = new Fornecedor("44.992.828/0001-49",
                 "Servejaria heineken SA", "Heineken", "", "");
                heineken.contato = artur;

                Fornecedor pepsi = new Fornecedor("81.367.727/0001-03",
                 "Refrigerantes pepsi SA", "Pepsi", "", "");
                pepsi.contato = artur;

                List<Fornecedor> fornecedores = new List<Fornecedor>();

                fornecedores.Add(pepsi);
                fornecedores.Add(heineken);
                fornecedores.Add(ambev);
                fornecedores.Add(bonafont);
                fornecedores.Add(coca);
                fornecedores.Add(skin);

                Serializa.SerializaFornecedor(fornecedores, Fornecedor.nomeArquivo);

                List<Apresentacao> apresentacao = new List<Apresentacao>();

                Apresentacao v5000 = new Apresentacao("5 Litros", 5000);
                Apresentacao v2000P = new Apresentacao("2 Litros Pet", 2000);
                Apresentacao v1000P = new Apresentacao("Litro Pet", 1000);
                Apresentacao v1000 = new Apresentacao("Litrão", 1000);
                Apresentacao v600 = new Apresentacao("Pet 600 ml", 600);
                Apresentacao v660 = new Apresentacao("Garrafa 660 ml", 660);
                Apresentacao v330 = new Apresentacao("Long Neck", 330);
                Apresentacao v270 = new Apresentacao("Lata 270 ml", 270);
                Apresentacao v330L = new Apresentacao("Lata 330 ml", 330);
                Apresentacao v500 = new Apresentacao("Pet 500 ml", 500);
                Apresentacao v200 = new Apresentacao("Copo", 200);
                Apresentacao v5000b = new Apresentacao("Barril", 5000);

                apresentacao.Add(v5000);
                apresentacao.Add(v2000P);
                apresentacao.Add(v1000);
                apresentacao.Add(v1000P);
                apresentacao.Add(v600);
                apresentacao.Add(v660);
                apresentacao.Add(v330);
                apresentacao.Add(v330L);
                apresentacao.Add(v270);
                apresentacao.Add(v500);
                apresentacao.Add(v200);
                apresentacao.Add(v5000b);

                Serializa.SerializaApresentacao(apresentacao, Apresentacao.nomeArquivo);

                List<Produto> produtos = new List<Produto>();

                produtos.Add(new Produto(coca, "Coca Cola 1L",  1000, v1000P) { Preco = 7.50m, Estoque = 1000 });
                produtos.Add(new Produto(coca, "Coca Cola 600ml",  600, v600) { Preco = 5.60m, Estoque = 1000 });
                produtos.Add(new Produto(coca, "Coca Cola Lata 270ml", 5000,  v270) { Preco = 4.60m, Estoque = 100 });
                produtos.Add(new Produto(coca, "Coca Cola Lata 330ml", 5000,  v330) { Preco = 5.60m, Estoque = 1000 });
                produtos.Add(new Produto(coca, "Coca Cola 2L", 5000, v2000P) { Preco = 12.60m, Estoque = 100 });

                produtos.Add(new Produto(bonafont, "Agua 500ml", 1000,  v500) { Preco = 3.50m, Estoque = 100 });
                produtos.Add(new Produto(bonafont, "Agua 1L", 2000,  v1000) { Preco = 6.50m, Estoque = 100 });
                produtos.Add(new Produto(bonafont, "Agua 2L", 2000,  v2000P) { Preco = 7.80m, Estoque = 100 });
                produtos.Add(new Produto(bonafont, "Agua Copo", 20000,  v200) { Preco = 2.60m, Estoque = 1000 });
                produtos.Add(new Produto(bonafont, "Agua 5L", 1000,  v5000) { Preco = 12.65m, Estoque = 50 });

                produtos.Add(new Produto(pepsi, "Pepsi 1L", 1000, v1000) { Preco = 9.50m, Estoque = 100 });
                produtos.Add(new Produto(pepsi, "Pepsi 600ml", 1000,  v600) { Preco = 5.60m, Estoque = 1000 });
                produtos.Add(new Produto(pepsi, "Pepsi Lata 270ml", 5000, v270) { Preco = 4.60m, Estoque = 1000 });
                produtos.Add(new Produto(pepsi, "Pepsi Lata 330ml", 5000,  v330) { Preco = 5.30m, Estoque = 1000 });
                produtos.Add(new Produto(pepsi, "Pepsi 2L", 5000,  v2000P) { Preco = 9.60m, Estoque = 100 });

                produtos.Add(new Produto(heineken, "Heineken Litro", 1000, v1000) { Preco = 14.96m, Estoque = 100 });
                produtos.Add(new Produto(heineken, "Heineken Garrafa", 1000,  v660) { Preco = 8.50m, Estoque = 300 });
                produtos.Add(new Produto(heineken, "Heineken Lata 270", 5000,  v270) { Preco = 4.60m, Estoque = 100 });
                produtos.Add(new Produto(heineken, "Heineken Lata 330", 5000,  v330L) { Preco = 5.60m, Estoque = 1000 });
                produtos.Add(new Produto(heineken, "Heineken Long Neck", 15000,  v330) { Preco = 6.20m, Estoque = 1000 });
                produtos.Add(new Produto(heineken, "Heineken Barril", 15000, v5000b) { Preco = 69.20m, Estoque = 100 });

                produtos.Add(new Produto(ambev, "Sckol Litro", 1000, v1000) { Preco = 12.40m, Estoque = 1000 });
                produtos.Add(new Produto(ambev, "Sckol Garrafa", 1000, v660) { Preco = 9.60m, Estoque = 1000 });
                produtos.Add(new Produto(ambev, "Sckol Lata 270", 5000,  v270) { Preco = 4.60m, Estoque = 100 });
                produtos.Add(new Produto(ambev, "Sckol Lata 330", 5000,  v330L) { Preco = 5.10m, Estoque = 1000 });
                produtos.Add(new Produto(ambev, "Sckol Long Neck", 15000,  v330) { Preco = 5.60m, Estoque = 1000 });


                produtos.Add(new Produto(ambev, "Brahma Litro", 1000,  v1000) { Preco = 9.90m, Estoque = 2000 });
                produtos.Add(new Produto(ambev, "Brahma Garrafa", 1000, v660) { Preco = 8.60m, Estoque = 5000 });
                produtos.Add(new Produto(ambev, "Brahma Lata 270", 5000,  v270) { Preco = 4.60m, Estoque = 100 });
                produtos.Add(new Produto(ambev, "Brahma Lata 330", 5000, v330L) { Preco = 3.20m, Estoque = 1000 });
                produtos.Add(new Produto(ambev, "Brahma Long Neck", 15000, v330) { Preco = 5.30m, Estoque = 1000 });

                Serializa.SerializaProduto(produtos, Produto.nomeArquivo);


                

            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "Clientes cadastrados";
        }

        int IComparable<Fornecedor>.CompareTo(Fornecedor other)
        {
            return Cnpj.CompareTo(other.Cnpj);
        }

        public static List<Fornecedor> Lista()
        {
            return Serializa.DesserializaFornecedor(nomeArquivo);
        }
    }
}