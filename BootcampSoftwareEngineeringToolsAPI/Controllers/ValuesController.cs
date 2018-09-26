using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using BootcampSoftwareEngineeringToolsAPI.Models;
using Microsoft.ApplicationInsights;
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

            WriteTraceToAppInsights($"returned all records to client", SeverityLevel.Information);
            var peopleDescription = PrintPeople(people);

            return peopleDescription;
        }


        // GET api/values/name

        [HttpGet("{name}")]
        public string Get(string name)
        {
            try
            {
                var person = PeopleDatabase.FindPerson(name);
                WriteTraceToAppInsights($"Found {name} in database", SeverityLevel.Information);

                return person.FirstName;
            }
            catch (Exception)
            {
                WriteTraceToAppInsights($"{name} not found in database", SeverityLevel.Information);
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
                WriteTraceToAppInsights($"Stored {person.FirstName} to database", SeverityLevel.Information);
            }
            catch (NullReferenceException exception)
            {
                WriteTraceToAppInsights("Badly formed JSON in request to BootCampAPI", SeverityLevel.Error);
                return BadRequest();
            }

            return Ok();
        }


        // DELETE api/values/name

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {

            WriteTraceToAppInsights($"Deleted {name} from database", SeverityLevel.Information);

            PeopleDatabase.DeletePerson(name);

            return Ok();
        }


        // DELETE api/values/deleteall

        [HttpDelete("{deleteall}")]
        public IActionResult Purge()
        {
            PeopleDatabase.PurgeAllPeople();

            WriteTraceToAppInsights("Deleted all records", SeverityLevel.Information);

            return Ok();
        }

        private void WriteTraceToAppInsights(string message, SeverityLevel severityLevel)
        {
            var telemetry = new Microsoft.ApplicationInsights.TelemetryClient();
            telemetry.TrackTrace(message, severityLevel);
        }


        private static string PrintPeople(List<Person> people)
        {
            var peopleDescription = "Welcome to ASOS: ";

            foreach (var person in people) peopleDescription += $"Name {person.FirstName} {person.LastName} RandomFact: {person.RandomFact}" + System.Environment.NewLine;

            return peopleDescription;
        }
    }
}