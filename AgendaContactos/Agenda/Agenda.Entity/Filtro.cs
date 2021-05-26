using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Entity
{
    public class Filtro : AAgendaEntitys
    {
        public String Genero { get; set; }
        public String Direccion { get; set; }
        public String Telefono_fijo { get; set; }
        public String Celular { get; set; }
        public String Email { get; set; }
        public String Skype { get; set; }

    }
}
