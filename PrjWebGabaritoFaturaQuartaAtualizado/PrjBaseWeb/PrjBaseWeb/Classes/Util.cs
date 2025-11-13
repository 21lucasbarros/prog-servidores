using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjFaturamento.Classes
{
    public class Util
    {

        public static void MontaCombo(DropDownList combo, List<String> indices, List<String> textos, String abertura)
        {

            if (indices.Count != textos.Count)
            {
                throw new Exception("Dados inconsistentes na criação de combo Box");
            }

            try
            {
                combo.Items.Clear();

                ListItem listItem = new ListItem();
                listItem.Text = abertura;
                listItem.Value = "0";
                combo.Items.Add(listItem);

                for (int i = 0; i < indices.Count; i++)
                {
                    listItem = new ListItem();
                    listItem.Text = textos[i];
                    listItem.Value = indices[i];
                    combo.Items.Add(listItem);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        static public void BoxOkJavaScript(string mens, Page page)
        {
            try
            {
                StringBuilder myScript = new StringBuilder(String.Empty);
                myScript.Append("<script type='text/javascript' language='javascript'> ");
                myScript.Append(String.Concat("alert('", mens.Replace("<br />", "\\n"), "'); "));
                myScript.Append("</script> ");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "msg", myScript.ToString(), false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        static public void BoxOkCancelaJavaScript(string mens, string funcao, Page page)
        {
            try
            {
                // Exemplo Chamando :  Util.BoxOkCancelaJavaScript("Confirma Excluir regostro bla bla bla ?", "excluir", Page);
                StringBuilder myScript = new StringBuilder(String.Empty);
                myScript.Append("<script type='text/javascript' language='javascript'> ");
                myScript.Append(String.Concat("var result = window.confirm('", mens.Replace("<br />", "\\n"), "'); "));
                myScript.Append(String.Concat("__doPostBack('", funcao, "', result); "));
                myScript.Append("</script> ");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "msg", myScript.ToString(), false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //  Exemplo usando janela de confirmação / Colocar isso no PageLoad
        //  if (IsPostBack)
        //  {
        //      string evento = this.Request["__EVENTTARGET"] ?? String.Empty;
        //      string resposta = this.Request["__EVENTARGUMENT"] ?? String.Empty;


        //      if (resposta.Equals("true"))
        //      {
        //          switch (evento)
        //          {
        //              case "excluir": Excluir(); break;
        //          }
        //      }
        //}
        public static String MyHash(string str, string salt)
        {
            if (String.IsNullOrEmpty(str))
            {
                return 0.ToString("D10");
            }

            try
            {
                Int64 hash = 0;

                Int32[] chave = {
                            0x4adfae,
                            0x3bcd13,
                            0x4afe56,
                            0x1fda56,
                            0x653219,
                            0x765754,
                            0x124678,
                            0x014321,
                            0x58fba0,
                            0xfad5fa,
                            0x234987,
                            0xdfa5bc,
                            0xabcdef,
                            0xfedcab,
                            0x1234ab,
                            0xab1234,
                            0x112233,
                            0x445566,
                            0xaabbcc,
                            0xddeeff,
                          };

                char[] bytes = String.Concat(str.Trim(), salt.Trim()).Trim().ToArray();

                for (int i = 0; i < bytes.Length; i++)
                {
                    hash += bytes[i] * (chave[i % 20] + chave[bytes[i] % 20]);
                }

                return (hash % 0xffffffff).ToString("D10");
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static String FormatarCpf(String cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "").
                Replace(" ", "").Replace("/", "");


            if (cpf.Length != 11)
            {
                return String.Empty;
            }

            if (!float.TryParse(cpf, out float n))
            {
                return String.Empty;
            }

            //return cpf.Substring(0, 3) + "." +
            //       cpf.Substring(3, 3) + "." +
            //       cpf.Substring(6, 3) + "-" +
            //       cpf.Substring(9, 3);

            return String.Concat(cpf[0], cpf[1], cpf[2], ".",
                                 cpf[3], cpf[4], cpf[5], ".",
                                 cpf[6], cpf[7], cpf[8], "-",
                                 cpf[9], cpf[10]);

        }
        public static String ValidaSenha(String senha)
        {
            int nMa = 0, nMi = 0, nN = 0, nE = 0;

            if (senha.Length < 8)
            {
                return "Número mínimo de 8 caracteres";
            }

            char[] vet = senha.ToCharArray();

            foreach (char c in vet)
            {
                if (c >= 'A' && c <= 'Z') nMa++;
                else if (c >= 'a' && c <= 'z') nMi++;
                else if (c >= '0' && c <= '9') nN++;
                else nE++;
            }

            if (nMa == 0) return "Obrigatório pelo menos uma maiúscula";
            if (nMi == 0) return "Obrigatório pelo menos uma minúscula";
            if (nN == 0) return "Obrigatório pelo menos um numérico";
            if (nE == 0) return "Obrigatório pelo menos um especial";

            return "";
        }

        public static bool ValidarCPF(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int digito1 = soma % 11;
            digito1 = digito1 < 2 ? 0 : 11 - digito1;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            int digito2 = soma % 11;
            digito2 = digito2 < 2 ? 0 : 11 - digito2;

            return cpf[9] - '0' == digito1 && cpf[10] - '0' == digito2;
        }
        public static bool ValidarCNPJ(string cnpj)
        {
           
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            if (cnpj.Length != 14)
                return false;

           
            if (cnpj.Distinct().Count() == 1)
                return false;

            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            tempCnpj += digito1;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            string digitosVerificadores = cnpj.Substring(12, 2);
            return digitosVerificadores == $"{digito1}{digito2}";
        }

    }
}