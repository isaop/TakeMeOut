using BackEnd.Models;

namespace BackEnd.Services
{
    public interface IVenueService
    {
        public Task<Venue> EditVenue(Venue venue);

    }
}
