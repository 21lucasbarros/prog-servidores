using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjCalculadoraWeb
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InicLabels();
        }

        private void InicLabels()
        {
            lbParcelaA.Text = "Parcela A:";
            lbParcelaB.Text = "Parcela B:";
        }

        protected void btCls_Click(object sender, EventArgs e)
        {
            txtParcelaA.Text = txtParcelaB.Text = String.Empty;
        }
    }
}