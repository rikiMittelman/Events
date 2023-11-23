using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IDataContext _context;

        public EventsController(IDataContext context)
        {
            _context = context;
        }

        static DataContext Context=new DataContext();
        //private static List<Event> Events = new List<Event>() { new Event(new DateTime(2023,11,05)),
        //    new Event(new DateTime(2023,11,04)),new Event(new DateTime(2023,11,02))};
        private static int count = 0;

        // GET: api/<EventsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Context.EventList);
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
           var res= Context.EventList.Find(e => e.Id == id);
            if(res is null)
                return NotFound();
            return Ok(res);
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event eve)
        {
            Context.EventList.Add(new Event { Id = count++, Title = eve.Title,Start=eve.Start });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event newEve)
        {
            var eve = Context.EventList.Find(e => e.Id == id);
            eve.Title=newEve.Title;
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = Context.EventList.Find(e => e.Id == id);
            Context.EventList.Remove(eve);
        }
    }
}
