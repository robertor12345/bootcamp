using System;
using System.Collections.Generic;

namespace BootcampSoftwareEngineeringToolsAPI.Models
{
    public static class PeoplePrinter
    {
        public static string PrintPeople(List<Person> people)
        {
            var peopleDescription = "Welcome to ASOS: " +
                                    Environment.NewLine;

            foreach (var person in people)
                peopleDescription += $"Name {person.FirstName} {person.LastName} '{person.RandomFact}'" +
                                     Environment.NewLine;

            return peopleDescription;
        }

        public static string PrintPerson(Person person)
        {
            var peopleDescription = "Welcome to ASOS: ";

            peopleDescription += $"Name {person.FirstName} {person.LastName} '{person.RandomFact}'";

            return peopleDescription;
        }
    }
}