using TakeMeOutBE.Models;

namespace TakeMeOutBE.Services
{
    public interface IEventService
    {
        public Task<bool> AddEventToDatabase(Event myEvent);
        public Task<Event> GetLastEvent();
        public Task<List<Event>> GetAllEventsByName(string eventName);

        public Task<Event> GetEventById(int id);

        public Task<List<Event>> GetAllEvents();
    }
}
