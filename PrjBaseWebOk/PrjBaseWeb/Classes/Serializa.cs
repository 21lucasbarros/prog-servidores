using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    public class Serializa
    {

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
                BinaryFormatter formatter = new BinaryFormatter();
                return (List<Usuario>)formatter.Deserialize(fs);

            }
        }
    }
}