using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using BackEnd.Services;
using System.ComponentModel;
using BackEnd.Dtos;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;

        public ReviewController(IReviewService reviewService, IUserService userService)
        {
            _reviewService = reviewService;
            _userService = userService;
        }

        [HttpPost("add-review")]
        public async Task<ActionResult<int>> AddReview([FromBody] ReviewDto newReview)
        {

            Review r = new Review();
            r.Comment = newReview.Comment;
            r.IdPayment = newReview.IdPayment;
            r.IdEvent = newReview.IdEvent;
            r.IdUser = newReview.IdUser;

            bool result = await _reviewService.AddReviewToDatabase(r);
            var myReview = await _reviewService.GetLastReview();
            if (result == true)
                return Ok(myReview.IdReview);
            else
                return BadRequest("failed to add");
        }

        [HttpGet("get-review-by-id")]
        public async Task<ActionResult<ReviewDtoGetter>> GetReviewByID(int idReview)
        {
            var reviews = await _reviewService.GetReviewById(idReview);
            var user = await _userService.GetUserByID((int)reviews.IdUser);
            ReviewDtoGetter requestedReview = new ReviewDtoGetter((int)reviews.IdUser, user.Name, user.Surname, reviews.Comment);
            return (requestedReview == null) ? NotFound("No reviews found") : requestedReview;
        }

        [HttpGet("get-all-reviews-by-user")]
        public async Task<ActionResult<List<ReviewDtoGetter>>> GetAllReviewsByUser(int idUser)
        {
            var reviews = await _reviewService.GetAllReviewsByUser(idUser);
            var user = await _userService.GetUserByID(idUser);
            List<ReviewDtoGetter> requestedReviews = new List<ReviewDtoGetter>();

            for (int i = 0; i < reviews.Count; i++)
            {
                ReviewDtoGetter r = new ReviewDtoGetter((int)reviews[i].IdUser, user.Name, user.Surname, reviews[i].Comment);
                requestedReviews.Add(r);
            }
            return (requestedReviews == null) ? NotFound("No reviews found") : requestedReviews;
        }

        [HttpDelete("delete-Review")]
        public async Task<ActionResult> DeleteReview(int id)
        {
            Review result = await _reviewService.CheckIfReviewExists(id);

            if (result != null)
            {
                bool delete = await _reviewService.DeleteReview(result);
                return Ok(delete);
            }
            else
            {
                return BadRequest("failed to delete");
            }

        }
    }
}
