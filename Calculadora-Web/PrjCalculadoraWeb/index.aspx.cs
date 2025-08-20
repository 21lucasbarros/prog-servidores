using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrjCalculadoraWeb.Classes;

namespace PrjCalculadoraWeb
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbParcelaA.Text = "Parcela A";
            lbParcelaB.Text = "Parcela B";
        }

        protected void btnClick(Object sender, EventArgs e)
        {
            if(!float.TryParse(parcelaAInput.Text, out float parcelaA) || 
                !float.TryParse(parcelaBInput.Text, out float parcelaB))
            {
                areaResultado.Text = "Parcela(s) digitada(s) inválidas";
                return;
            }

            Calculadora calc = new Calculadora(parcelaA, parcelaB);

            float resultado = 0;

            if (sender == adicao) resultado = calc.Soma();
            if (sender == subtracao) resultado = calc.Subtracao();
            if (sender == multiplicacao) resultado = calc.Multiplicar();
            if (sender == divisao)
            {
                try
                {
                    resultado = calc.Divide();
                }
                catch (Exception ex)
                {
                    areaResultado.Text = ex.Message;
                }
            }
            if (sender == raizQuadrada)
            {
                try
                {
                    resultado = calc.RaizQuadrada();
                }
                catch (Exception ex)
                {
                    areaResultado.Text = ex.Message;
                }
            }

            areaResultado.Text = resultado.ToString();
        }
        protected void btnSqrtClick(Object sender, EventArgs e)
        {
            if (!float.TryParse(parcelaAInput.Text, out float parcelaA))
            {
                areaResultado.Text = "ParcelaA digitada inválida";
                return;
            }

            Calculadora calc = new Calculadora(parcelaA, 0);

            float resultado = 0;

            if (sender == raizQuadrada)
            {
                try
                {
                    resultado = calc.RaizQuadrada();
                }
                catch (Exception ex)
                {
                    areaResultado.Text = ex.Message;
                }
            }

            areaResultado.Text = resultado.ToString();
        }
    }
}