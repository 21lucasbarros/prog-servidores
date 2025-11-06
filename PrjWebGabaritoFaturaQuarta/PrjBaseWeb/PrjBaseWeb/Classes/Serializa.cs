using PrjCalculadoraWeb.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace PrjFaturamento.Classes
{
    public class Serializa
    {

        public static void SerializaApresentacao(List<Apresentacao> lista, String arq)
        {
            using (FileStream fs = new FileStream(arq, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, lista);
            }
        }

        public static List<Apresentacao> DesserializaApresentacao(String arq)
        {
            using (FileStream fs = new FileStream(arq, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (List<Apresentacao>)formatter.Deserialize(fs);

            }
        }

        public static void SerializaProduto(List<Produto> lista, String arq)
        {
            using (FileStream fs = new FileStream(arq, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, lista);
            }
        }

        public static List<Produto> DesserializaProduto(String arq)
        {
            using (FileStream fs = new FileStream(arq, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (List<Produto>)formatter.Deserialize(fs);

            }
        }
        public static void SerializaFornecedor(List<Fornecedor> lista, String arq)
        {
            using (FileStream fs = new FileStream(arq, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, lista);
            }
        }

        public static List<Fornecedor> DesserializaFornecedor(String arq)
        {
            using (FileStream fs = new FileStream(arq, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (List<Fornecedor>)formatter.Deserialize(fs);
            }
        }

        public static void SerializaCliente(List<Cliente> lista, String arq)
        {
            using (FileStream fs = new FileStream(arq, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, lista);
            }
        }

        public static List<Cliente> DesserializaCliente(String arq)
        {
            using (FileStream fs = new FileStream(arq, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (List<Cliente>)formatter.Deserialize(fs);

            }
        }

        public static void SerializaUsuario(List<Usuario> lista, String arq)
        {         

            

            using (FileStream fs = new FileStream(arq, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, lista);
            }
        }

        public static List<Usuario> DesserializaUsuario(String arq)
        {
            using (FileStream fs = new FileStream(arq, FileMode.Open))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (List<Usuario>)formatter.Deserialize(fs);
                } catch(Exception)
                {
                    return new List<Usuario>();
                }

            }
        }
    }
}