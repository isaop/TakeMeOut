using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Dtos;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            e.endHour = newEvent.endHour;
            e.startHour = newEvent.startHour;
            e.IdCategory = newEvent.IdCategory;
            e.Description = newEvent.Description;
            e.IdBusinessAccount = newEvent.IdBusinessAccount;
            e.IdVenue = newEvent.IdVenue;

            bool result = await _eventService.AddEventToDatabase(e);
            var myEvent = await _eventService.GetLastEvent();
            if (result == true)
                return Ok(myEvent.IdEvent);
            else
                return BadRequest("failed to add");
        }

        [HttpGet("get-list-events-by-name")]
        public async Task<ActionResult<List<EventDtoGetter>>> GetAllEventsByName(string name)
        {
            var events = await _eventService.GetAllEventsByName(name);
            List<EventDtoGetter> requestedEvents = new List<EventDtoGetter>();
            
            for (int i = 0; i < events.Count; i++)
            {
                EventDtoGetter e = new EventDtoGetter(events[i].EventName, events[i].Description);
                requestedEvents.Add(e);
            }
            return (requestedEvents == null) ? NotFound("No events found") : requestedEvents;
        }

        [HttpGet("get-all-events")]
        public async Task<ActionResult<List<EventDtoGetter>>> GetAllEvents()
        {
            var events = await _eventService.GetAllEvents();
            List<EventDtoGetter> requestedEvents = new List<EventDtoGetter>();

            for (int i = 0; i < events.Count; i++)
            {
                EventDtoGetter e = new EventDtoGetter(events[i].EventName, events[i].Description);
                requestedEvents.Add(e);
            }
            return (requestedEvents == null) ? NotFound("No events found") : requestedEvents;
        }

        [HttpGet("get-event-by-id")]
        public async Task<ActionResult<EventDtoGetter>> GetEventById(int id)
        {
            var events = await _eventService.GetEventById(id);
            EventDtoGetter requestedEvent = new EventDtoGetter(events.EventName, events.Description);
            return (requestedEvent == null) ? NotFound("No events found") : requestedEvent;
        }

        [HttpPut("edit-event")]
        public async Task<bool> EditEvent([FromBody] EventDto @event)
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
                return false;
            else
            {
                var result = await _eventService.EditEvent(e);
                return true;
            }
        }
        [HttpDelete("delete-Event")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            Event result = await _eventService.CheckIfEventExists(id);

            if (result != null)
            {
                bool delete = await _eventService.DeleteEvent(result);
                return Ok(delete);
            }
            else
            {
                return BadRequest("failed to delete");
            }

        }
    }
}