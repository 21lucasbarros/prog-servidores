using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    public class IMC
    {
        public float Peso { get; private set; }
        public float Altura { get; private set; }

        public IMC(float peso, float altura)
        {
            Peso = peso;
            Altura = altura;
        }

        public string Diagnostico()
        {
            try
            {
                float IMC = Calculo();

                if (IMC < 16) return "Baixo peso Grau 3";
                if (IMC < 17) return "Baixo peso Grau 2";
                if (IMC < 18) return "Baixo peso Grau 1";
                if (IMC < 25) return "Peso ideal";
                if (IMC < 30) return "Sobrepeso";
                if (IMC < 35) return "Obesidade grau 1";
                if (IMC < 40) return "Obesidade grau 2";
                return "Obesidade Grau 3 (Morbida)";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private float Calculo()
        {
            try
            {
                return Peso / (Altura * Altura);
            } 
            catch(Exception)
            {
                throw;
            }
        }
    }
}