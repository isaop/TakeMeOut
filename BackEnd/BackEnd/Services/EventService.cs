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

        public Event GetFirstEventByName(string eventName)
        {
            return  _context.Events.Where(e => e.EventName == eventName).ToList()[0];
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
        public async Task<bool> DeleteEvent(Event e)
        {
            _context.Events.Remove(e);
            await _context.SaveChangesAsync();
            return true;
        }
        public bool CheckIfOrderHasEvent(int idEv)
        {
            bool exists = false;
            foreach (var orderr in _context.Orders)
                if (orderr.IdEvent == idEv)
                    exists = true;

            return exists;
        }
        public bool CheckIfReviewHasEvent(int idEv)
        {
            bool exists = false;
            foreach (var revieww in _context.Reviews)
                if (revieww.IdEvent == idEv)
                    exists = true;

            return exists;
        }
        public bool CheckIfUserActionHasEvent(int idEv)
        {
            bool exists = false;
            foreach (var usactionss in _context.UserActions)
                if (usactionss.IdEvent == idEv)
                    exists = true;

            return exists;
        }

    }
}
