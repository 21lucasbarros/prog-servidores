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
        private static List<Paciente> pacientes = new List<Paciente>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario u = (Usuario)Session["usuario"];

            if(u == null)
            {
                Response.Redirect("FrmLogin.aspx", true);
                //Sempre depois de um Redirect, tem que colocar um return.
                //A area aplication é uma area de dados comum a todos que estão logados. A vantagem de colocar a lista de usuarios na aplication é que ele faz uma carga só.
                return;
            }

            btExcluir.Enabled = Session["paciente"] != null;

            if (!IsPostBack)
            {
                if (pacientes.Count == 0)
                {
                    pacientes.Add(new Paciente("Carol", "33333333333", 'F', new DateTime(2004, 03, 02), 55, 1.65f));
                    pacientes.Add(new Paciente("João", "11111111111", 'M', new DateTime(2004, 03, 02), 70, 1.75f));
                    pacientes.Add(new Paciente("Janaina", "22222222222", 'F', new DateTime(2004, 03, 02), 60, 1.68f));
                }
            }
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
                lbErroSexo.Text =
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
            string nome = txNome.Text.Trim();
            if (string.IsNullOrWhiteSpace(nome))
            {
            lbErro.Text = "O nome é obrigatório.";
            temErro = true;
            }
            else
            {
            lbErro.Text = "";
            }

            // Validação dos RadioButtons de sexo
            char sexo = ' ';
            if (rbFeminino.Checked)
            sexo = 'F';
            else if (rbMasculino.Checked)
            sexo = 'M';
            else if (rbOutro.Checked)
            sexo = 'O';
            else
            {
            lbErroSexo.Text = "Selecione uma opção de sexo.";
            temErro = true;
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
            string cpfNumeros = Pessoa.NormalizarCpf(cpf);

            if (cpfNumeros.Length != 11)
            {
                lbErroCPF.Text = "Digite um CPF válido com 11 números.";
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

            if (Session["paciente"] != null)
            {
            Paciente paciente = (Paciente)Session["paciente"];
            paciente.Atualiza(peso, (float)altura);
            /*txResultado.Text = "Paciente atualizado.";*/
            //Mostrar(paciente); Não fiz ainda
            return;
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

            try
            {
                Paciente p = new Paciente(nome, cpf, sexo, dataNascimento, peso, (float)altura);

                foreach (Paciente paciente in pacientes)
                {
                if (cpf.Equals(paciente.Cpf))
                {
                    txResultado.Text = "Paciente já cadastrado";
                    return;
                }
                }

                pacientes.Add(p);

                txResultado.Text = p.Diagnostico();
            }
            catch (Exception ex)
            {
                txResultado.Text = ex.ToString();
            }
            }
        }

        private void Mostrar(Paciente p)
        {
            txAltura.Text = p.Altura().ToString(System.Globalization.CultureInfo.InvariantCulture);
            txCPF.Text = p.Cpf;
            txDataNascimento.Text = p.DtNascimento.ToString("dd/MM/yyyy");
            txNome.Text = p.Nome;
            txPeso.Text = p.Peso().ToString(System.Globalization.CultureInfo.InvariantCulture);
            txResultado.Text = p.Diagnostico();

            rbFeminino.Checked = p.Sexo == 'F';
            rbMasculino.Checked = p.Sexo == 'M';
            rbOutro.Checked = p.Sexo == 'O';
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            string cpfBusca = Pessoa.NormalizarCpf(txCPF.Text);

            if (string.IsNullOrWhiteSpace(cpfBusca))
            {
                lbErroCPF.Text = "Informe um CPF para buscar.";
                return;
            }

            Paciente pacienteEncontrado = pacientes.FirstOrDefault(p => p.Cpf == cpfBusca);

            if (pacienteEncontrado == null)
            {
                txResultado.Text = "Paciente não encontrado.";
                Session["paciente"] = null;
                btExcluir.Enabled = false;
                return;
            }

            // Salva na sessão
            Session["paciente"] = pacienteEncontrado;
            btExcluir.Enabled = true;

            // Chama o método Mostrar pra preencher os inputs
            Mostrar(pacienteEncontrado);
        }

        protected void btExcluir_Click(object sender, EventArgs e)
        {
            if (Session["paciente"] != null)
            {
                Paciente paciente = (Paciente)Session["paciente"];

                pacientes.RemoveAll(p => p.Cpf == paciente.Cpf);

                Session["paciente"] = null;

                Button2_Click(sender, e);

                btExcluir.Enabled = false;

                txResultado.Text = "Paciente excluído com sucesso.";
            }
            else
            {
                txResultado.Text = "Nenhum paciente selecionado para excluir.";
                btExcluir.Enabled = false;
            }
        }
    }
}