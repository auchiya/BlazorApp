using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using PeopleAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeopleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleData db;

        public PeopleController(IPeopleData _db)
        {
            db = _db;
        }

        // GET: api/<PeopleController>
        [HttpGet]
        public async Task<IEnumerable<PersonModel>> Get()
        {
            var people = await db.GetPeople();
            return people;
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PeopleController>
        [HttpPost]
        public void Post([FromBody] DisplayPersonModel newPerson)
        {
            if (ModelState.IsValid)
            {
                PersonModel p = new PersonModel()
                {
                    FirstName = newPerson.FirstName,
                    LastName = newPerson.LastName,
                    EmailAddress = newPerson.EmailAddress
                };

                db.InsertPerson(p);
            }
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.DeletePerson(id);
        }
    }
}
