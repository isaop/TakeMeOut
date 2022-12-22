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
        public async Task<ActionResult<List<EventDto>>> GetAllEventsByName(string name)
        {
            var events = await _eventService.GetAllEventsByName(name);
            List<EventDto> requestedEvents = new List<EventDto>();
            
            for (int i = 0; i < events.Count; i++)
            {
                EventDto e = new EventDto();
                e.IdEvent = events[i].IdEvent;
                e.EventName = events[i].EventName;
                e.Description = events[i].Description;
                e.endHour = events[i].endHour;
                e.startHour = events[i].startHour;
                e.IdVenue = events[i].IdVenue;
                e.endDate = events[i].endDate;
                e.startDate = events[i].startDate;
                e.IdVenue = events[i].IdVenue;

                requestedEvents.Add(e);
            }
            return (requestedEvents == null) ? NotFound("No events found") : requestedEvents;
        }

        [HttpGet("get-all-events")]
        public async Task<ActionResult<List<EventDto>>> GetAllEvents()
        {
            var events = await _eventService.GetAllEvents();
            List<EventDto> requestedEvents = new List<EventDto>();

            for (int i = 0; i < events.Count; i++)
            {
                EventDto e = new EventDto();
                e.IdEvent = events[i].IdEvent;
                e.EventName = events[i].EventName;
                e.Description = events[i].Description;
                e.endHour = events[i].endHour;
                e.startHour = events[i].startHour;
                e.IdVenue = events[i].IdVenue;
                e.endDate = events[i].endDate;
                e.startDate = events[i].startDate;
                e.IdVenue = events[i].IdVenue;
                e.IdBusinessAccount = events[i].IdBusinessAccount;
                requestedEvents.Add(e);
            }
            return (requestedEvents == null) ? NotFound("No events found") : requestedEvents;
        }

        [HttpGet("get-event-by-id")]
        public async Task<ActionResult<EventDto>> GetEventById(int id)
        {
            var eventt = await _eventService.GetEventById(id);
            EventDto requestedEvent = new EventDto();
            requestedEvent.IdEvent = eventt.IdEvent;
            requestedEvent.EventName = eventt.EventName;
            requestedEvent.Description = eventt.Description;
            requestedEvent.endHour = eventt.endHour;
            requestedEvent.startHour = eventt.startHour;
            requestedEvent.IdVenue = eventt.IdVenue;
            requestedEvent.endDate = eventt.endDate;
            requestedEvent.startDate = eventt.startDate;
            requestedEvent.IdVenue = eventt.IdVenue;
            requestedEvent.IdBusinessAccount = eventt.IdBusinessAccount;

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

            var exists = _eventService.CheckIfOrderHasEvent(id);
            if (exists == true)
                return BadRequest("Delete the Orders of this Event first!");
            else
            {
                return BadRequest("failed to delete");
            }

            if (result != null)
            {
                bool delete = await _eventService.DeleteEvent(result);
                return Ok(delete);
            }

            var exists2 = _eventService.CheckIfReviewHasEvent(id);
            if (exists2 == true)
                return BadRequest("Delete the Reviews of this Event first!");
            else
            {
                return BadRequest("failed to delete");
            }

            if (result != null)
            {
                bool delete = await _eventService.DeleteEvent(result);
                return Ok(delete);
            }

            var exists3 = _eventService.CheckIfUserActionHasEvent(id);
            if (exists3 == true)
                return BadRequest("Delete the UserActions of this Event first!");
            else
            {
                return BadRequest("failed to delete");
            }

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