using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConvertidordeBase.Models;

namespace ConvertidordeBase
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            long number = Convert.ToInt64(txtNumber.Text);
            int fromBase = Convert.ToInt32(ddlFrom.SelectedValue);
            int toBase = Convert.ToInt32(ddlTo.SelectedValue);
            string result = "";
            try
            {
                result = BaseConvert.Convert(number,fromBase ,toBase);
                //result = BaseConvert.NToDecimal(number, fromBase).ToString();
                //result = BaseConvert.Convert(number, fromBase, toBase);
            }
            catch (Exception es)
            {
                lblResult.Text = es.Source;
                throw;
            }            
            lblResult.Text = result;
        }
    }
}