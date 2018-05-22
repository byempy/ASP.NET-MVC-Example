
using ConsultaDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaDB.Interfaces
{
    public interface IDataHelper
    {
        List<Person> GetListaPersonas(Person persona);
        Person GetPersonaDetallada(int id);
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DelPerson(int id);
        void Dispose();
    }
}
