using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampSoftwareEngineeringToolsAPI.Models
{
    public static class PeopleCollection
    {
        public static List<Person> People { get; set; }

        static PeopleCollection()
        {
            People = new List<Person>();
        }
    }
}
