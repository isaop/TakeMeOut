using BackEnd.Database;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services
{
    public class EventService : IEventService
    {
        private readonly TakeMeOutDbContext _context;

        public EventService(TakeMeOutDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddEventToDatabase(Event myEvent)
        {
            myEvent.IdEvent = null;
            _context.Events.Add(myEvent);
            await(_context.SaveChangesAsync());
            return true;
        }
       
        public async Task<Event> CheckIfEventExists(int? id)
        {
            var @event = await _context.Events.FirstOrDefaultAsync(e => e.IdEvent == id);
            if (@event == null)
                return null;
            else
                return @event;
        }

        public async Task<List<Event>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<List<Event>> GetAllEventsByName(string eventName)
        {
            return await _context.Events.Where(e => e.EventName == eventName).ToListAsync();
        }

        public async Task<Event> GetEventById(int id)
        {
            return await _context.Events.Where(e => e.IdEvent == id).FirstOrDefaultAsync();
        }

        public async Task<Event> GetLastEvent()
        {
            var eventt = _context.Events.OrderByDescending(q => q.IdEvent).FirstOrDefaultAsync();
            return await eventt;
        }

        public async Task<Event> EditEvent(Event e)
        {
            var result = await CheckIfEventExists(e.IdEvent);
            result.endHour = e.endHour;
            result.startHour = e.startHour;
            result.startDate = e.startDate;
            result.endDate = e.endDate;
            result.Description = e.Description;
            result.EventName = e.EventName;
            result.IdCategory = e.IdCategory;
            result.IdBusinessAccount = e.IdBusinessAccount;
            result.IdVenue = e.IdVenue;

            _context.Events.Update(result);
            await(_context.SaveChangesAsync());
            return result;
        }
    }
}
