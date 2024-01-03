using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Model;
using System;

namespace MyFirstWebAPI.Controllers
{
    [Route("api/")]
    public class PersonController : Controller
    {                
            private readonly IPersonServices _personservices;
            public PersonController(IPersonServices personService)
            {
            _personservices = personService;
            }
            [HttpGet()]
            public async Task<IActionResult> GetAllPersons()
            {
                var persons = await _personservices.GetAllPersons();
                if (persons.Count == 0)
                {
                    return NotFound("Persons not exist");
                }
                return this.Ok(persons);
            }

            [HttpGet("Person/{id}")]
            public async Task<IActionResult> GetPersonById(int id)
            {
                var person = await _personservices.GetPersonById(id);
                if (person == null)
                {
                    return NotFound($"PersonId {id} not exist");
                }


                return this.Ok(person);
            }

            [HttpPost("Person")]
            public async Task<IActionResult> CreatePerson([FromBody] Person person)
            {
                try
            {
                    int result = await _personservices.CreatePerson(person);
                    if (result > 0)
                        return this.Ok("true");
                    else
                        return this.BadRequest("false");
                }
                catch (Exception e)
                {
                    return this.BadRequest(e.Message);
              }
            }

            [HttpPut("Person/{id}")]
            public async Task<IActionResult> UpdatePerson (int id, [FromBody] Person person)
            {
                try
                {
                    var dbPerson = await _personservices.GetPersonById(id);
                    if (dbPerson == null)
                    {
                        return this.NotFound($"PersonId {id} not found..");
                    }
                    person.Id = id;
                    int result = await _personservices.UpdatePerson(person);
                    if (result > 0)
                        return this.Ok("true");
                    else
                        return this.BadRequest("false");
                }
                catch (Exception e)
                {
                    return this.BadRequest(e.Message);
                }

            }
            [HttpDelete("Person/{id}")]
            public async Task<IActionResult> DeletePerson (int id)
            {
                try
                {
                    var dbPerson = await _personservices.GetPersonById(id);
                    if (dbPerson == null)
                    {
                        return this.NotFound($"PersonId {id} not found..");
                    }
                    int result = await _personservices.DeletePerson(id);
                    if (result > 0)
                        return this.Ok("true");
                    else
                        return this.BadRequest("false");

                }
                catch (Exception e)
                {
                    return this.BadRequest(e.Message);
                }

            }
        }
}
