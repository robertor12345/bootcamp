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
        public List<Person> Get()
        {
            return ValueStore.GetPeople();
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public string Get(string name)
        {
            try
            {
                var value = ValueStore.FindPerson(name);

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
            ValueStore.StorePerson(person);

            return Ok();
        }


        // DELETE api/values/5

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            ValueStore.DeletePerson(name);

            return Ok();
        }

        [HttpDelete("{deleteall}")]
        public IActionResult Purge()
        {
            ValueStore.PurgeAllPeople();

            return Ok();
        }
    }
}