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
