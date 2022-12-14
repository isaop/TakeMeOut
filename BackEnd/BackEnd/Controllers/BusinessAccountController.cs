using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    public struct BusinessAccountStruct
    {
        public BusinessAccountStruct(string name, string description, int idVenue, 
            string email, string contactNumber) //string venueName, string venueDescription)
        {
            Name = name;
            Description = description;
            IDVenue = idVenue;
            Email = email;
            ContactNumber = contactNumber;
            //VenueName = venueName;
            //VenueDescription = venueDescription;
        }

        public string? Name { get; }
        public string? Description { get; }
        public int IDVenue { get; }
        public string Email { get; }
        public string ContactNumber { get; }
        //public string VenueName { get; }
        //public string VenueDescription { get; }
    }
    public class BusinessAccountController : ControllerBase
    {
        private readonly IBusinessAccountService _baService;

        public BusinessAccountController(IBusinessAccountService baService)
        {
            _baService = baService;
        }

        [HttpGet("get-business-account-by-id")]
        public async Task<ActionResult<BusinessAccountStruct>> GetBusinessAccountByID(int id)
        {
            List<BusinessAccountStruct> baList = new List<BusinessAccountStruct>();

            var accounts = await _baService.GetBusinessAccountByID(id);

            BusinessAccountStruct ba = new BusinessAccountStruct(accounts.Name, accounts.Description,
            (int)accounts.IdVenue, accounts.Email, accounts.ContactNumber);
            
            return (accounts == null) ? NotFound("No business accounts found") : ba;
        }

        [HttpGet("get-all-business-accounts")]
        public async Task<ActionResult<List<BusinessAccountStruct>>> GetAllBusinessAccounts()
        {
            List<BusinessAccountStruct> baList = new List<BusinessAccountStruct>();

            var accounts = await _baService.GetAllBusinessAccounts();
            for (int i = 0; i < accounts.Count; i++)
            {
                BusinessAccountStruct ba = new BusinessAccountStruct(accounts[i].Name, accounts[i].Description,
                    (int)accounts[i].IdVenue, accounts[i].Email, accounts[i].ContactNumber);
                baList.Add(ba);
            }
            return (baList == null) ? NotFound("No business accounts found") : baList;
        }
    }
}
