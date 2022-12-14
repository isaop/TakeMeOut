using BackEnd.Models;

namespace BackEnd.Services
{
    public interface IEventService
    {
        public Task<bool> AddEventToDatabase(Event myEvent);
        public Task<Event> GetLastEvent();
        public Task<List<Event>> GetAllEventsByName(string eventName);

        public Task<Event> GetEventById(int id);

        public Task<List<Event>> GetAllEvents();
        public Task<Event> EditEvent(Event @event);
        public Task<bool> DeleteEvent(Event e);
        public Task<Event> CheckIfEventExists(int? id);
        public bool CheckIfOrderHasEvent(int idEv);

        public bool CheckIfReviewHasEvent(int idEv);

        public bool CheckIfUserActionHasEvent(int idEv);
    }
}
