using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessAccountController : ControllerBase
    {
        private readonly IBusinessAccountService _baService;
        private readonly IVenueService _venueService;

        public BusinessAccountController(IBusinessAccountService baService, IVenueService venueService)
        {
            _baService = baService;
            _venueService = venueService;
        }

        [HttpGet("get-business-account-by-id")]
        public async Task<ActionResult<BusinessAccountDtoGetter>> GetBusinessAccountByID(int id)
        {
            var accounts = await _baService.GetBusinessAccountByID(id);
            var venue = await _venueService.GetVenueByID((int)accounts.IdVenue);
            BusinessAccountDtoGetter requestedBA = new BusinessAccountDtoGetter(accounts.Name, accounts.Description,
            (int)accounts.IdVenue, accounts.Email, accounts.ContactNumber, venue.Name, venue.Description);
            return (accounts == null) ? NotFound("No business accounts found") : requestedBA;
        }

        [HttpGet("get-all-business-accounts")]
        public async Task<ActionResult<List<BusinessAccountDtoGetter>>> GetAllBusinessAccounts()
        {
            var accounts = await _baService.GetAllBusinessAccounts();
            List<BusinessAccountDtoGetter> requestedBAs = new List<BusinessAccountDtoGetter>();

            for (int i = 0; i < accounts.Count; i++)
            {
                var venue = await _venueService.GetVenueByID((int)accounts[i].IdVenue);
                BusinessAccountDtoGetter ba = new BusinessAccountDtoGetter(accounts[i].Name, accounts[i].Description,
                    (int)accounts[i].IdVenue, accounts[i].Email, accounts[i].ContactNumber, venue.Name, venue.Description);
                requestedBAs.Add(ba);
            }
            return (requestedBAs == null) ? NotFound("No business accounts found") : requestedBAs;
        }

        [HttpPut("edit-business-account")]
        public async Task<bool> EditBusinessAccount([FromBody] BusinessAccountEditRequest baDto)
        {
            BusinessAccount ba = new BusinessAccount();
            ba.IdBusinessAccount = baDto.IdBusinessAccount;
            ba.IdVenue = baDto.IdVenue;
            ba.Name = baDto.Name;
            ba.ContactNumber = baDto.ContactNumber;
            ba.Email = baDto.Email;
            ba.Description = baDto.Description;

            if (ba == null)
                return false;
            else
            {
                var result = await _baService.EditBusinessAccount(ba);
                return true;
            }
        }

        [HttpPut("change-password-ba")]
        public async Task<bool> ChangeBAPassword([FromBody] ChangePasswordRequest req)
        {

            int id = req.Id;
            string oldPassword = req.OldPassword;
            string newPassword = req.NewPassword;

            var result = await _baService.ChangeBAPassword(id, oldPassword, newPassword);
            if (result == true)
                return true;
            else
                return false;

        }


        [HttpDelete("delete-BA")]
        public async Task<ActionResult> DeleteBusinessAccount(int id)
        {
            BusinessAccount result = await _baService.CheckIfBusinessAccountExists(id);

            if (result != null)
            {
                bool delete = await _baService.DeleteBusinessAccount(result);
                return Ok(delete);
            }
            else
            {
                return BadRequest("failed to delete");
            }

        }
    }
}
