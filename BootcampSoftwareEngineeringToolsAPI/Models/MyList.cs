using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampSoftwareEngineeringToolsAPI.Models
{
    public static class MyList
    {
        public static List<Person> PeopleList { get; set; }

        static MyList()
        {
            PeopleList = new List<Person>();
        }
    }
}
