using System;
using BootcampSoftwareEngineeringToolsAPI.Models;
using Microsoft.ApplicationInsights.DataContracts;
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

            Telemetry.WriteTraceToAppInsights("Returned all records to client", SeverityLevel.Information);

            var peopleDescription = PeoplePrinter.PrintPeople(people);

            return peopleDescription;
        }


        // GET api/values/name

        [HttpGet("{name}")]
        public string Get(string name)
        {
            try
            {
                var person = PeopleDatabase.FindPerson(name);

                Telemetry.WriteTraceToAppInsights($"Found {person.FirstName} in database", SeverityLevel.Information);

                return PeoplePrinter.PrintPerson(person);
            }
            catch (Exception)
            {
                Telemetry.WriteTraceToAppInsights($"{name} not found in database", SeverityLevel.Information);

                return "person not found";
            }
        }


        // POST api/values

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            try
            {
                PeopleDatabase.StorePerson(person);
                Telemetry.WriteTraceToAppInsights($"Stored {person.FirstName} to database", SeverityLevel.Information);
            }
            catch (NullReferenceException)
            {
                Telemetry.WriteTraceToAppInsights("Badly formed JSON in request to BootCampAPI", SeverityLevel.Error);
                return BadRequest();
            }

            return Ok();
        }


        // DELETE api/values/name

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            Telemetry.WriteTraceToAppInsights($"Deleted {name} from database", SeverityLevel.Information);

            PeopleDatabase.DeletePerson(name);

            return Ok();
        }


        // DELETE api/values/deleteall

        [HttpDelete("{deleteall}")]
        public IActionResult Purge()
        {
            PeopleDatabase.PurgeAllPeople();

            Telemetry.WriteTraceToAppInsights("Deleted all records", SeverityLevel.Information);

            return Ok();
        }
    }
}