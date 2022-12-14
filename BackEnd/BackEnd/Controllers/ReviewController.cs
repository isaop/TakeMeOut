using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using BackEnd.Services;
using System.ComponentModel;

namespace BackEnd.Controllers
{
    public struct ReviewStruct
    {
        public ReviewStruct(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }

        public override string ToString() => $"({Name}, {Description})";
    }
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("add-review")]
        public async Task<ActionResult<int>> AddReview(int idReview,
         int idEvent, int idUser, int idPayment, string comment)
        {
            /*Console.WriteLine(my_event);
            bool result = await _eventService.AddEventToDatabase(my_event);
            var newEvent = await _eventService.GetLastEvent();
            if (result == true)
            {
                return Ok(newEvent.IdEvent);
            }
            else
            {
                return BadRequest("failed to add");
            }*/


            /*
            bool result = await _eventService.AddEventToDatabase(myEvent);
            var newEvent = await _eventService.GetLastEvent();
            if (result == true)
            {
                return Ok(newEvent.IdEvent);
            }
            else
            {
                return BadRequest("failed");
            }*/



            Review r = new Review();
            r.IdReview = idReview;
            r.IdEvent = idEvent;
            r.IdUser = idUser;
            r.IdPayment = idPayment;
            r.Comment = comment;
            bool result = await _reviewService.AddReviewToDatabase(r);
            if (result == true)
            {
                return Ok(r.IdReview);
            }
            else
            {
                return BadRequest("failed");
            }



        }
    }
}
