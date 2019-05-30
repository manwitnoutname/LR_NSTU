using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lr1WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lr1WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PersonController : ControllerBase
    {
        private static List<PersonModel> persons = new List<PersonModel>();

        [HttpGet]
        public ActionResult<IEnumerable<PersonModel>> Get()
        {
            return Ok(persons) ;
        }

        [HttpGet("{id}")]
        public ActionResult<PersonModel> Get(int id)
        {
            if (persons.Count <= id) return NotFound("Человека с таким номером анкеты нет!");
        
            return Ok(persons[id]);
        }


        [HttpPost]
        public IActionResult Post([FromBody] PersonModel value)
        {
            var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
            
                persons.Add(value);

                return Ok($"{value.ToString() } Has been added");
        
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PersonModel value)
        {
            if (persons.Count <= id) return NotFound("Человека с таким номером анкеты нет!");
            
            var validationResult =value.Validate();
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
            var previousValue= persons[id]; 
            persons[id] = value;

            return Ok($"{previousValue.ToString()} has been updated to {value.ToString()}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (persons.Count <= id) return NotFound("Человека с таким номером анкеты нет!");
            var valueToRemove = persons[id];
            persons.RemoveAt(id);
            return Ok($"{valueToRemove.ToString()} has been removed");
        }
    }
}