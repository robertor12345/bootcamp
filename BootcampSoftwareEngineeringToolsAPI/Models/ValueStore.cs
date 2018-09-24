using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampSoftwareEngineeringToolsAPI.Models
{
    public static class ValueStore
    {

        public static void StorePerson(Person person)
        {
            MyList.PeopleList.Add(person);
        }

        public static List<Person> GetPeople()
        {
            return MyList.PeopleList;
        }

        public static void DeletePerson(string name)
        {
            MyList.PeopleList.RemoveAll(person => person.Name ==name);
        }

        public static void PurgeAllPeople()
        {
            MyList.PeopleList.RemoveAll(person => true);
        }


        public static Person FindPerson(string name)
        {
            return MyList.PeopleList.Find(person => person.Name == name);
        }
    }
}
