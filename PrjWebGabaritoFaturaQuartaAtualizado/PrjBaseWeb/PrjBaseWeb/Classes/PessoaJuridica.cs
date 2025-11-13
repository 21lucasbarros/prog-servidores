using PrjFaturamento.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    [Serializable]
    public class PessoaJuridica
    {       
        public PessoaJuridica(
            string cnpj, 
            string razaoSocial, 
            string nomeFantasia, 
            string inscricaoEstadual, 
            string inscricaoMunicipal)
        {
            if (!Util.ValidarCNPJ(cnpj))
            {
                throw new 
                    ArgumentException("CNPJ Inválido: " + cnpj);
            }

            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            InscricaoEstadual = inscricaoEstadual;
            InscricaoMunicipal = inscricaoMunicipal;
        }

        public String Cnpj { get; private set; }
        public String RazaoSocial { get; private set; }
        public String NomeFantasia { get; private set; }
        public String InscricaoEstadual { get; private set; }
        public String InscricaoMunicipal { get; private set; }


    }
}