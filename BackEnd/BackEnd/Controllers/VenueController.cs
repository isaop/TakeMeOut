using BackEnd.Dtos;
using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    public class VenueController: ControllerBase
    {
        private readonly IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        [HttpPut("edit-venue")]
        public async Task<ActionResult> EditVenue([FromBody] VenueDto ven)
        {
            Venue v = new Venue();
            v.IdVenue = ven.IdVenue;
            v.Description = ven.Description;
            v.ContactNumber = ven.ContactNumber;
            v.Address = ven.Address;
            v.Name = ven.Name;

          
            if (v == null)
                return BadRequest("Venue is empty");
            else
            {

                var result = await _venueService.EditVenue(v);

                return Ok(result);
            }
        }
    }
}
