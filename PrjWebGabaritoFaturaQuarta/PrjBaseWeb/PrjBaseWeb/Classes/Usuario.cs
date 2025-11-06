using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjFaturamento.Classes
{
    [Serializable]
    public class Usuario : IComparable<Usuario>  
    {

        public static String nomeArquivo = 
            
            String.Format("{0}{1}",
                AppDomain.CurrentDomain.BaseDirectory ,
                "Dados\\dadosUsuario.DAT");       
        public string Id { get; private set; }
        public string Nome { get; private set; }

        public string Cpf { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }

        public char Perfil { get; private set; }

        public static int contador = 0;

        public Usuario(string id)
        {
            Id = id;
        }

        public void Atualiza(String nome, char perfil)
        {
            Nome = nome;
            Perfil = perfil;
        }

        public Usuario(string nome,
            string cpf,
            string login,         
            char perfil)
        {
            Nome = nome;
            Cpf = Util.FormatarCpf(cpf);
            Login = login;
            Senha = Cpf;
            Perfil = perfil;
            Id = (++contador).ToString("D4");

            

        }

        public override string ToString()
        {
            return String.Concat(Id , ", " ,
                Nome , ", " , 
                Cpf , ", " ,
                Login , ", " ,
                Perfil , ", "  ,
               (Util.ValidarCPF(Senha) ? "Não trocada" : "Trocada"));
        }

        public static void AjustaId(List<Usuario> lista)
        {
            if (lista.Count == 0)
            {
                contador = 0;
                return;
            }
            Usuario u = lista[lista.Count - 1];
            int.TryParse(u.Id, out contador);
        }

        int IComparable<Usuario>.CompareTo(Usuario user)
        {
            return Id.CompareTo(user.Id);
        }

        public static String ValidaSenha(String senha)
        {
            int cNum = 0;
            int cMa = 0;
            int cMi = 0;
            int cEspecial = 0;
            int cEspaco = 0;

            char[] c = senha.ToCharArray();

            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] >= 'a' && c[i] <= 'z') cMi++;
                else
                if (c[i] >= 'A' && c[i] <= 'Z') cMa++;
                else
                if (c[i] == ' ') cEspaco++;
                else
                if (c[i] >= '0' && c[i] <= '9') cNum++;
                else cEspecial++;
            }

            if (cNum == 0) return "Deve conter pelo menos um número";
            if (cMi == 0) return "Deve conter pelo menos uma minuscula";
            if (cMa == 0) return "Deve conter pelo menos uma maiúscula";
            if (cEspecial == 0) return "Deve conter pelo menos um caracter especial";
            if (cEspaco > 0) return "Não deve conter espaços";

            return "";

        }

        public void AlteraSenha(String senha)
        {
            Senha =  Util.ValidarCPF(senha) ? senha :
                Util.MyHash(senha,Login);
        }


    }
}