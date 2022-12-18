using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Dtos;

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
        public async Task<ActionResult<int>> AddEvent([FromBody] EventDto newEvent)
        {
            Event e = new Event();
            e.EventName = newEvent.EventName;
            e.endDate = newEvent.endDate;
            e.startDate = newEvent.startDate;
            e.endHour =  newEvent.endHour;
            e.startHour = newEvent.startHour;
            e.IdCategory = newEvent.IdCategory;
            e.IdBusinessAccount = newEvent.IdBusinessAccount;
            e.IdVenue = newEvent.IdVenue;

            bool result = await _eventService.AddEventToDatabase(e);
            var myEvent = await _eventService.GetLastEvent();
            if (result == true)
            {
                return Ok(myEvent.IdEvent);
            }
            else
            {
                return BadRequest("failed to add");
            }
        }

        [HttpGet("get-list-events-by-name")]
        public async Task<ActionResult<List<EventDtoGetter>>> GetAllEventsByName(string name)
        {
            var events = await _eventService.GetAllEventsByName(name);
            List<EventDtoGetter> requestedEvents = new List<EventDtoGetter>();
            
            for (int i = 0; i <  events.Count; i++)
            {
                EventDtoGetter e = new EventDtoGetter(events[i].EventName, events[i].Description);
                requestedEvents.Add(e);
            }
            return (requestedEvents == null) ? NotFound("No quizzes available") : requestedEvents;
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

        [HttpPut("edit-event")]
        public async Task<ActionResult> EditEvent([FromBody] EventDto @event)
        {
            Event e = new Event();
            e.IdEvent = @event.IdEvent;
            e.endHour = @event.endHour;
            e.startHour = @event.startHour;
            e.startDate = @event.startDate;
            e.endDate = @event.endDate;
            e.Description = @event.Description;
            e.EventName = @event.EventName;
            e.IdCategory = @event.IdCategory;
            e.IdBusinessAccount = @event.IdBusinessAccount;
            e.IdVenue = @event.IdVenue;

            if (@event == null)
                return BadRequest("Event is empty");
            else
            {
                var result = await _eventService.EditEvent(e);
                return Ok(result);
            }
        }


    }
}