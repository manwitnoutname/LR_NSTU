using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lr1WebApi.Models;
using ISWebApp.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Lr1WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PersonController : ControllerBase
    {
        private static IStorage<PersonModel> _memCache = new MemCache();

        [HttpGet]
        public ActionResult<IEnumerable<PersonModel>> Get()
        {
            return Ok(_memCache.All) ;
        }

        [HttpGet("{id}")]
        public ActionResult<PersonModel> Get(Guid id)
        {
            if (!_memCache.Has(id)) 
            return NotFound("Человека с таким номером анкеты нет!");
        
            return Ok(_memCache[id]);
        }


        [HttpPost]
        public IActionResult Post([FromBody] PersonModel value)
        {
            var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
            
                _memCache.Add(value);

                return Ok($"{value.ToString() } Has been added");
        
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] PersonModel value)
        {
            if (!_memCache.Has(id)) return NotFound("Человека с таким номером анкеты нет!");
            
            var validationResult =value.Validate();
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
            var previousValue= _memCache[id]; 
            _memCache[id] = value;

            return Ok($"{previousValue.ToString()} has been updated to {value.ToString()}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_memCache.Has(id)) return NotFound("Человека с таким номером анкеты нет!");
            var valueToRemove = _memCache[id];
            _memCache.RemoveAt(id);
            return Ok($"{valueToRemove.ToString()} has been removed");
        }
    }
}