using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain;

namespace Core
{
    public static class DataAccessLayer
    {
        private static readonly List<PersonInfo> Persons = new List<PersonInfo>();

        private static int MaxId
        {
            get { return Persons.Count !=0 ? Persons.Max(x => x.Id)+1 : 1; }
        }

        public static PersonInfo Save(PersonInfo person)
        {
            person.Id = MaxId;
            Persons.Add(person);
            return person;
        }

        public static IEnumerable<PersonInfo> GetAllPersons()
        {
            return Persons;
        }

        public static PersonInfo GetPerson(int id)
        {
            return Persons.FirstOrDefault(x => x.Id == id);
        }

    }
}
