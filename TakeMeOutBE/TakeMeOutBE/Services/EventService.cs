using Microsoft.EntityFrameworkCore;
using TakeMeOutBE.Database;
using TakeMeOutBE.Models;

namespace TakeMeOutBE.Services
{
    public class EventService : IEventService
    {
        private readonly TakeMeOutContext _context;
        public EventService(TakeMeOutContext context)
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

        public Task<List<Event>> GetAllEvents(string eventName)
        {
            return _context.Events.Where(e => e.EventName == eventName).ToListAsync();
        }

        public async Task<Event> GetLastEvent()
        {
            var quiz = _context.Events.OrderByDescending(q => q.IdEvent).FirstOrDefaultAsync();
            return await quiz;
        }
    }
}
