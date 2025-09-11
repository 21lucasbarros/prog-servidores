using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    public class Util
    {
        public static bool ValidarCPF(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
                return false;

            int CalcularDigito(int length)
            {
                int soma = 0;
                for (int i = 0; i < length; i++)
                    soma += (cpf[i] - '0') * (length + 1 - i);

                int resto = soma % 11;
                return resto < 2 ? 0 : 11 - resto;
            }

            int digito1 = CalcularDigito(9);
            int digito2 = CalcularDigito(10);

            return cpf.EndsWith($"{digito1}{digito2}");
        }
    }
}