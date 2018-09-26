using System.Collections.Generic;

namespace BootcampSoftwareEngineeringToolsAPI.Models
{
    public static class PeopleCollection
    {
        static PeopleCollection()
        {
            People = new List<Person>();
        }

        public static List<Person> People { get; set; }
    }
}