using PrjCalculadoraWeb.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjBaseWeb
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txAltura.Text =
                txCPF.Text =
                txDataNascimento.Text =
                txNome.Text =
                txPeso.Text =
                txResultado.Text = String.Empty;

            rbFeminino.Checked =
                rbMasculino.Checked =
                rbOutro.Checked = false;

            lbErro.Text = 
                lbErroCPF.Text =
                lbErroDataN.Text =
                lbErroPeso.Text =
                lbErroAltura.Text = String.Empty;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool temErro = false;

            // Valida Data de Nascimento
            if (!DateTime.TryParse(txDataNascimento.Text, out DateTime dataNascimento))
            {
                lbErroDataN.Text = "Data digitada é inválida!";
                temErro = true;
            }
            else
            {
                var hoje = DateTime.Today;
                int idade = hoje.Year - dataNascimento.Year;
                if (dataNascimento > hoje.AddYears(-idade)) idade--;

                if (idade > 100 || idade < 15)
                {
                    lbErroDataN.Text = "Data inválida: idade deve ser entre 15 e 100 anos.";
                    temErro = true;
                }
                else
                {
                    lbErroDataN.Text = "";
                }
            }

            // Valida Nome
            if (string.IsNullOrWhiteSpace(txNome.Text))
            {
                lbErro.Text = "O nome é obrigatório.";
                temErro = true;
            }
            else
            {
                lbErro.Text = "";
            }

            // Validação dos RadioButtons de sexo
            if (!rbFeminino.Checked && !rbMasculino.Checked && !rbOutro.Checked)
            {
                lbErroSexo.Text = "Selecione uma opção de sexo.";
                temErro = true;
            }
            else
            {
                lbErroSexo.Text = "";
            }

            // Valida CPF
            string cpf = txCPF.Text.Trim();

            if (string.IsNullOrWhiteSpace(cpf))
            {
                lbErroCPF.Text = "O CPF é obrigatório.";
                temErro = true;
            }
            else
            {
                string cpfNumeros = new string(cpf.Where(char.IsDigit).ToArray());

                if (cpfNumeros.Length != 14)
                {
                    lbErroCPF.Text = "Digite um CPF válido com 14 números.";
                    temErro = true;
                }
                else
                {
                    lbErroCPF.Text = "";
                }
            }

            // Valida Altura
            if (!decimal.TryParse(txAltura.Text, out decimal altura))
            {
                lbErroAltura.Text = "Informe uma altura válida.";
                temErro = true;
            }
            else
            {
                if (altura < 1.40m || altura > 2.20m)
                {
                    lbErroAltura.Text = "Altura deve ser entre 1,40m e 2,20m.";
                    temErro = true;
                }
                else
                {
                    lbErroAltura.Text = "";
                }
            }

            // Valida Peso
            if (!float.TryParse(txPeso.Text.Replace(',', '.'), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float peso))
            {
                lbErroPeso.Text = "Informe um peso válido.";
                temErro = true;
            }
            else
            {
                lbErroPeso.Text = "";
            }

            if (!temErro)
            {
                lbErro.Text = "";
                lbErroCPF.Text = "";
                lbErroDataN.Text = "";
                lbErroAltura.Text = "";
                lbErroPeso.Text = "";
                lbErroSexo.Text = "";

                IMC imc = new IMC(peso, (float)altura);
                string resultado = imc.Diagnostico();

                txResultado.Text = $"{ (peso / (float)(altura * altura)):F2} - {resultado}";
            }
        }


    }
}