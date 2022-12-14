using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using BackEnd.Services;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Controllers
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
        public async Task<ActionResult<int>> AddEvent([FromBody]Event newEvent)
        {
            bool result = await _eventService.AddEventToDatabase(newEvent);
            var myEvent = await _eventService.GetLastEvent();
            if (result == true)
            {
                return Ok(myEvent.IdEvent);
            }
            else
            {
                return BadRequest("failed to add");
            }


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

            /*DateTime startingDate = new DateTime(year, month, day, startingHour, 0, 0);
            DateTime endingDate = new DateTime(year, month, day, endingHour, 0, 0);
            TimeSpan timeInterval = endingDate - startingDate;

            Event e = new Event();
            e.EventName = eventName;
            e.IdBusinessAccount = idBA;
           // e.Date = startingDate;
          //  e.Time = timeInterval;
            e.IdCategory = idCategory;
            e.Description = description;
            e.IdVenue = idVenue;*/
            // bool result = await _eventService.AddEventToDatabase(newEvent);
            /* if (result == true)
             {
                 return Ok(newEvent.IdEvent);
             }
             else
             {
                 return BadRequest("failed");
             }*/

            return Ok();



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