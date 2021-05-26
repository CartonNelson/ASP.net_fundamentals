using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Entity;

namespace Agenda.BBL
{
    public interface IAgendaBussines
    {
        Contacto GetContactByID(int P_cont);
        List<Contacto> GetListContactFilter(Filtro P_Filtro);
        Contacto Insert(Contacto P_cont);
        void Update(Contacto P_cont);
        void Delete(int P_cont);
        void DeleteL(int P_cont);
        List<Contacto> GetAllContacts();
    }
}
