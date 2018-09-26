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
                peopleDescription += $"Name {person.FirstName} {person.LastName} RandomFact: {person.RandomFact}" +
                                     Environment.NewLine;

            return peopleDescription;
        }
    }
}