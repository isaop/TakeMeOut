﻿using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using BackEnd.Services;
using System.ComponentModel;
using BackEnd.Dtos;

namespace BackEnd.Controllers
{
    public struct ReviewStruct
    {
        public ReviewStruct(int idUser, string userName, string userSurname, string comment)
        {
            IDUser = idUser;
            UserName = userName;
            UserSurname = userSurname;
            Comment = comment;
        }

        public int IDUser { get; }
        public string UserName { get; }
        public string UserSurname { get; }
        public string Comment { get; } 
    }
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

        [HttpGet("get-review-by-id")]
        public async Task<ActionResult<ReviewStruct>> GetReviewByID(int idReview)
        {
            var reviews = await _reviewService.GetReviewById(idReview);
            var user = await _userService.GetUserByID((int)reviews.IdUser);
            ReviewStruct r = new ReviewStruct((int)reviews.IdUser, user.Name, user.Surname, reviews.Comment);
            return (reviews == null) ? NotFound("No reviews found") : r;
        }

        [HttpGet("get-all-reviews-by-user")]
        public async Task<ActionResult<List<ReviewStruct>>> GetAllReviewsByUser(int idUser)
        {
            List<ReviewStruct> reviewList = new List<ReviewStruct>();
            var reviews = await _reviewService.GetAllReviewsByUser(idUser);
            var user = await _userService.GetUserByID(idUser);

            for (int i = 0; i < reviews.Count; i++)
            {
                ReviewStruct r = new ReviewStruct((int)reviews[i].IdUser, user.Name, user.Surname, reviews[i].Comment);
                reviewList.Add(r);
            }
            return (reviewList == null) ? NotFound("No reviews found") : reviewList;
        }
    }
}
