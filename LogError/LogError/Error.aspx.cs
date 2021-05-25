using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Text;

namespace LogError
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String LastError = (string)Application["LastException"];
            String pathLog = (string)WebConfigurationManager.AppSettings["FileErrorPath"];
            LogearError(LastError, pathLog);

        }

        protected void LogearError(String ErrorMsj, String path)
        {
            try
            {
                // Create the file, or overwrite if the file exists.
                String DateLog = DateTime.Now.ToString("HH:mm:ss");
                DateLog = DateLog.Replace(':', '.');
                path = path + @"LogError_" + DateLog + ".txt";

                //Creo Archivo
                using (FileStream fs = File.Create(Server.MapPath(@path)))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(ErrorMsj); //Escribo 
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                MsjError.InnerText = string.Concat("Verificar en el siguiente directorio:", path);
            }
                
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
    
    
}