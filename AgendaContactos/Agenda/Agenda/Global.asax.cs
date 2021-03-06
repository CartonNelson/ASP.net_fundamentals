using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Modelo;
using Agenda.Entity;

namespace Agenda
{
    public class Global : HttpApplication
    {
       
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Application["ID_Contacts"] = 0;

            Application["MsjError"] ="";
            
            Application["FiltroExiste"] = false;

            Application["FiltroBusqueda"] = new Filtro();

            Application["Modo"] = "";

            //obtengo areas
            appservicesareas.Areas areasService = new appservicesareas.Areas();
            String[] AreasListSrv = areasService.getAreas();
            Application["Areas"] = AreasListSrv;

        }
    }
}