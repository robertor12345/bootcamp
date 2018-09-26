using System;
using System.Collections.Generic;
using BootcampSoftwareEngineeringToolsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BootcampSoftwareEngineeringToolsAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            var people = PeopleDatabase.GetPeople();

            if (people.Count == 0) return "No people yet!";
            var peopleDescription = PrintPeople(people);

            return peopleDescription;
        }


        // GET api/values/name

        [HttpGet("{name}")]
        public string Get(string name)
        {
            try
            {
                var value = PeopleDatabase.FindPerson(name);

                return value.Name;
            }
            catch (Exception)
            {
                return "person not found";
            }
        }


        // POST api/values

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            PeopleDatabase.StorePerson(person);

            return Ok();
        }


        // DELETE api/values/name

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            PeopleDatabase.DeletePerson(name);

            return Ok();
        }


        // DELETE api/values/deleteall

        [HttpDelete("{deleteall}")]
        public IActionResult Purge()
        {
            PeopleDatabase.PurgeAllPeople();

            return Ok();
        }


        private static string PrintPeople(List<Person> people)
        {
            var peopleDescription = "Welcome to ASOS: ";

            foreach (var person in people) peopleDescription += person.Name + " ";

            return peopleDescription;
        }
    }
}