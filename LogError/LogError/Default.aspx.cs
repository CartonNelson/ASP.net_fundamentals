using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogError
{
    public partial class _Default : Page
    {
        //protected void Page_Load(object sender, EventArgs e){  }

        public void DispararError(object sender, EventArgs e)
        {
            throw new Exception("Error Forzado");
        }

       

    }
}