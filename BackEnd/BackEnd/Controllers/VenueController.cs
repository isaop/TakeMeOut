using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    public struct VenueStruct
    {
        public VenueStruct(string name, string address,
            string contactNumber, string description)
        {
            Name = name;
            Address = address;
            Description = description;
            ContactNumber = contactNumber;
        }

        public string Name { get; }
        public string Address { get; }
        public string Description { get; }
        public string ContactNumber { get; }
    }

    public class VenueController : ControllerBase
    {
        private readonly IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        [HttpGet("get-venue-by-id")]
        public async Task<ActionResult<VenueStruct>> GetVenueByID(int id)
        {
            var venues = await _venueService.GetVenueByID(id);
            VenueStruct v = new VenueStruct(venues.Name, venues.Address, venues.Description, venues.ContactNumber);
            return (venues == null) ? NotFound("No venues found") : v;
        }

        [HttpGet("get-all-venues")]
        public async Task<ActionResult<List<VenueStruct>>> GetAllVenues()
        {
            List<VenueStruct> venuesList = new List<VenueStruct>();
            
            var venues = await _venueService.GetAllVenues();
            for (int i = 0; i < venues.Count; i++)
            {
                VenueStruct v = new VenueStruct(venues[i].Name, venues[i].Address, venues[i].Description, venues[i].ContactNumber);
                venuesList.Add(v);
            }
            return (venuesList == null) ? NotFound("No venues found") : venuesList;
        }
    }
}
