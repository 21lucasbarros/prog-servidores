using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjFaturamento.Classes
{
    [Serializable]
    public class PessoaJuridica
    {
        public PessoaJuridica(
            string razaoSocial, 
            string nomeFantasia, 
            string inscricaoMunicipal, 
            string incricaoEstadual, 
            string cnpj)
        {

            if (!Util.ValidarCNPJ(cnpj))
            {
                throw new Exception("CNPJ inválido");
            }

            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            InscricaoMunicipal = inscricaoMunicipal;
            IncricaoEstadual = incricaoEstadual;
            Cnpj = cnpj;
        }

        public String RazaoSocial { get; private set; }
        public String NomeFantasia  { get; private set; }
        public String InscricaoMunicipal { get; private set; }
        public String IncricaoEstadual { get; private set; }
        public String Cnpj { get; private set; }
    }
}