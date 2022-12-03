using Microsoft.AspNetCore.Mvc;
using TakeMeOutBE.Models;
using TakeMeOutBE.Services;

namespace TakeMeOutBE.Controllers
{
    public struct EventStruct
    {
        public EventStruct(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }

        public override string ToString() => $"({Name}, {Description})";
    }
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost("add-event")]
        public async Task<ActionResult<int>> AddEvent(string name, int eventStatus, int idBA, int idUser, int idCategory, string description, int idVenue)
        {
            /*Console.WriteLine(my_event);
            bool result = await _eventService.AddEventToDatabase(my_event);
            var newEvent = await _eventService.GetLastEvent();
            if (result == true)
            {
                return Ok(newEvent.IdEvent);
            }
            else
            {
                return BadRequest("failed to add");
            }*/


            /*
            bool result = await _eventService.AddEventToDatabase(myEvent);
            var newEvent = await _eventService.GetLastEvent();
            if (result == true)
            {
                return Ok(newEvent.IdEvent);
            }
            else
            {
                return BadRequest("failed");
            }*/
            DateTime date1 = new DateTime(2010, 1, 1, 8, 0, 15);
            DateTime date2 = new DateTime(2010, 1, 1, 8, 1, 20);
            TimeSpan interval = date2 - date1;
            Event e = new Event();
            e.IdEvent = null;
            e.EventName = name;
            e.IdEventStatus = eventStatus;
            e.IdBa = idBA;
            e.IdUser = idUser;
            e.Date = date1;
            e.Time = interval;
            e.IdCategory = idCategory;
            e.Description = description;
            e.IdVenue = idVenue;
            bool result = await _eventService.AddEventToDatabase(e);
            if (result == true)
            {
                return Ok(e.IdEvent);
            }
            else
            {
                return BadRequest("failed");
            }



        }

        [HttpGet("get-list-events-by-name")]
        public async Task<ActionResult<List<Event>>> GetAllEventsByName(string name)
        {
            var events = await _eventService.GetAllEventsByName(name);

            return (events == null) ? NotFound("No quizzes available") : events;

        }

        [HttpGet("get-all-events")]
        
        public async Task<ActionResult<List<EventStruct>>> GetAllEvents()
        {
            List<string> names = new List<string>();
            List<string> descriptions = new List<string>();
            List<EventStruct> eventStruct = new List<EventStruct>();

            var events = await _eventService.GetAllEvents();
            for (int i = 0; i < events.Count; i++)
            {

                EventStruct e = new EventStruct(events[i].EventName, events[i].Description);
                eventStruct.Add(e);

            }


            return (eventStruct == null) ? NotFound("No events found") : eventStruct;
        }

        [HttpGet("get-event-by-id")]

        public async Task<ActionResult<Event>> GetEventById(int id)
        {
            var events = await _eventService.GetEventById(id);
            return (events == null) ? NotFound("No events found") : events;
        }

    }
}
