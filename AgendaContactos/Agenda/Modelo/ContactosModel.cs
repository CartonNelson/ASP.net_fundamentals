using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Entity;


namespace Modelo
{
    public class ContactosModel
    {

        
        public List<Contacto> Crear()
        {
            List<Contacto> result = new List<Contacto>();

            result.Add(new Contacto(1, "Perez Mario", "M", "Argentina"));
            result.Add(new Contacto(2, "Algañaraz Ezequiel", "M", "Argentina"));
            result.Add(new Contacto(3, "Segura Emanuel", "M", "Uruguay"));
            result.Add(new Contacto(4, "Martina Rodriguez", "F", "Chile"));
            result.Add(new Contacto(5, "Agostina Ribaudo", "F", "Argentina"));

            return result;

        }
    }
        
}

