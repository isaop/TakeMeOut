using BackEnd.Dtos;
using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VenueController: ControllerBase
    {
        private readonly IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        [HttpGet("get-venue-by-id")]
        public async Task<ActionResult<VenueDto>> GetVenueByID(int id)
        {
            var venues = await _venueService.GetVenueByID(id);
            VenueDto requestedVenue = new VenueDto(venues.Name, venues.Address, venues.ContactNumber, venues.Description);
            return (venues == null) ? NotFound("No venues found") : requestedVenue;
        }

        [HttpGet("get-all-venues")]
        public async Task<ActionResult<List<VenueDto>>> GetAllVenues()
        {
            var venues = await _venueService.GetAllVenues();
            List<VenueDto> venuesList = new List<VenueDto>();
        
            for (int i = 0; i < venues.Count; i++)
            {
                VenueDto v = new VenueDto(venues[i].Name, venues[i].Address, venues[i].Description, venues[i].ContactNumber);
                venuesList.Add(v);
            }
            return (venuesList == null) ? NotFound("No venues found") : venuesList;
        }

        [HttpPut("edit-venue")]
        public async Task<ActionResult> EditEvent([FromBody] VenueDto venue)
        {
            Venue v = new Venue();
            v.Name = venue.Name;
            v.Description = venue.Description;
            v.Address = venue.Address;
            v.ContactNumber = venue.ContactNumber;

            if (venue == null)
                return BadRequest("Venue is empty");
            else
            {
                var result = await _venueService.EditVenue(v);
                return Ok(result);
            }
        }
    }
}
