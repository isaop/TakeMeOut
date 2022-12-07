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

        public Task<List<Event>> GetAllEvents()
        {
            return _context.Events.ToListAsync();
        }

        public Task<List<Event>> GetAllEventsByName(string eventName)
        {
            return _context.Events.Where(e => e.EventName == eventName).ToListAsync();
        }

        public Task<Event> GetEventById(int id)
        {
            return _context.Events.Where(e => e.IdEvent == id).FirstOrDefaultAsync();
        }

        public async Task<Event> GetLastEvent()
        {
            var eventt = _context.Events.OrderByDescending(q => q.IdEvent).FirstOrDefaultAsync();
            return await eventt;
        }
    }
}
