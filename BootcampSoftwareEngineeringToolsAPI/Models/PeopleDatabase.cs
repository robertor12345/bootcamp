using System.Collections.Generic;

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
            PeopleCollection.People.RemoveAll(person => person.FirstName == name);
        }

        public static void PurgeAllPeople()
        {
            PeopleCollection.People.RemoveAll(person => true);
        }


        public static Person FindPerson(string name)
        {
            return PeopleCollection.People.Find(person => person.FirstName == name);
        }
    }
}