using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    public class Calculadora
    {
        public float parcelaA { private set; get; }
        public float parcelaB { private set; get; }


        public Calculadora(float parcelaA, float parcelaB)
        {
            this.parcelaA = parcelaA;
            this.parcelaB = parcelaB;
        }

        public float Soma()
        {
            return parcelaA + parcelaB;
        }
        public float Subtracao()
        {
            return parcelaA - parcelaB;
        }
        public float Multiplicar()
        {
            return parcelaA * parcelaB;
        }
        public float Divide()
        {
            if(parcelaB == 0 ) throw new Exception("Divisão não pode ser feita por zero");
            return parcelaA / parcelaB;
        }
        public float RaizQuadrada()
        {
            if (parcelaA < 0)
                throw new Exception("Não existe raiz real para número negativo");
            return (float)Math.Sqrt(parcelaA);
        }

    }
}