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
    }
}
