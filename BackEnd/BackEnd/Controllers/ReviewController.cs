using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using BackEnd.Services;
using System.ComponentModel;
using BackEnd.Dtos;

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
        public async Task<ActionResult<int>> AddReview([FromBody]ReviewDto newReview)
        {

            Review r = new Review();
            r.Comment = newReview.Comment;
            r.IdPayment = newReview.IdPayment;
            r.IdEvent = newReview.IdEvent;
            r.IdUser = newReview.IdUser;

            bool result = await _reviewService.AddReviewToDatabase(r);
            var newEvent = await _reviewService.GetLastReview();
            if (result == true)
            {
                return Ok(newEvent.IdReview);
            }
            else
            {
                return BadRequest("failed to add");
            }
        }
    }
}
