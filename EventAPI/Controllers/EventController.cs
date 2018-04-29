using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    public class EventController : Controller
    {

        private readonly EventContext _context;
        public EventController(EventContext context)
        {
            _context = context;

            if (_context.Events.Count() == 0)
            {
                _context.Events.Add(new Event { Name = "Item1" });
                _context.SaveChanges();
            }
        }
        //Method to return all items
        [HttpGet]
        public IEnumerable<Event> GetAll()
        {
            return _context.Events.ToList();
        }

        //Get method to return item by Id specified
        [HttpGet("{id}", Name = "GetEvent")]
        public IActionResult GetById(long id)
        {
            var item = _context.Events.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Event item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Events.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetEvent", new { id = item.Id }, item);
        }
  
    }
}
