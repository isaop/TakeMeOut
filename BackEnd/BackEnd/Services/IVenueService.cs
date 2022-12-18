using BackEnd.Models;

namespace BackEnd.Services
{
    public interface IVenueService
    {
        public Task<Venue> GetVenueByID(int id);
        public Task<List<Venue>> GetAllVenues();
        public Task<Venue> EditVenue(Venue venue);
    }
}
