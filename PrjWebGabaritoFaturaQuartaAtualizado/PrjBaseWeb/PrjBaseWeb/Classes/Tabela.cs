using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    public class Tabela
    {
        private int linhas;
        private int colunas;

        private string titulo;

        public string[,] celula;
        public string[,] alinhamento;

        public Tabela(int linhas, int colunas, String titulo)
        {
            celula = new string[linhas, colunas];
            alinhamento = new string[linhas, colunas];

            this.linhas = linhas;
            this.colunas = colunas;
            this.titulo = titulo;
        }

        public string tabela(string[] titulos)
        {
            StringBuilder str = new StringBuilder("<meta charset='UTF-8'/>");
            str.Append("<table style='width:100%'>");

            if (titulo != null && titulo != String.Empty)
            {
                str.AppendFormat("<TR><TD colspan='{0}'><hr /></TD></TR>",colunas);
                str.AppendFormat("<TR><TD style='text-align:center;font-size:larger;font-weight:bold;' colspan='{0}'>{1}</TD></TR>",colunas,titulo);
            }

            str.AppendFormat("<TR><TD colspan='{0}'><hr /></TD></TR>",colunas);
            str.Append("<tr>");
            for (int col = 0; col < colunas; col++)
            {
                str.AppendFormat("<TD>&nbsp;<B>{0}</B>&nbsp;</TD>", titulos[col]);
            }
            str.Append("</tr>");

            str.AppendFormat("<TR><TD colspan='{0}'><hr /></TD></TR>",colunas);

            for (int lin = 0; lin < linhas; lin++)
            {
              
                str.Append("<tr>");
                for (int col = 0; col < colunas; col++)
                {
                    if (String.IsNullOrEmpty(alinhamento[lin, col]))
                    {
                        alinhamento[lin, col] = "left";
                    }

                    if (Double.TryParse(celula[lin, col].Replace(",", "."), out double valor))
                    {
                        str.AppendFormat("<TD style='text-align:right'>&nbsp;{0}&nbsp;</TD>", celula[lin, col]);
                    }
                    else
                    {
                        str.AppendFormat("<TD style='text-align:{0}'>&nbsp;{1}&nbsp;</TD>", alinhamento[lin, col], celula[lin, col]);
                    }
                }
                str.Append("</tr>");
            }
            str.AppendFormat("<TR><TD colspan='{0}'><hr /></TD></TR>",colunas);
            str.Append("</table>");
            return str.ToString();
        }
    }
}