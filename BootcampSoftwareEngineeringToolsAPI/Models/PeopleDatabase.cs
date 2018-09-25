using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampSoftwareEngineeringToolsAPI.Models
{
    public static class PeopleDatabase
    {

        public static void StorePerson(Person person)
        {
            PeopleCollection.People.Add(person);
        }

        public static List<Person> GetPeople()
        {
            return PeopleCollection.People;
        }

        public static void DeletePerson(string name)
        {
            PeopleCollection.People.RemoveAll(person => person.Name ==name);
        }

        public static void PurgeAllPeople()
        {
            PeopleCollection.People.RemoveAll(person => true);
        }


        public static Person FindPerson(string name)
        {
            return PeopleCollection.People.Find(person => person.Name == name);
        }
    }
}
