using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using programmersGuide.Models.DTOs;
using programmersGuide.Services.Interfaces;

namespace programmersGuide.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly IUserService userService;

        public HomeController(IReviewService reviewService, IUserService userService)
        {
            this.reviewService = reviewService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var model = reviewService.RandomReviews();
            return View(model);
        }

        [Authorize]
        public IActionResult UserContent()
        {
            return View();
        }

        [Authorize]
        [HttpPost("Review")]
        public async Task<IActionResult> SaveReview(ReviewDTO reviewDTO)
        {
            await reviewService.SaveReview(reviewDTO);
            return Redirect("Index");
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost("ChangeUserContent")]
        public async Task<IActionResult> ChangeUserContent(UserDTO userDto)
        {
            if (string.IsNullOrEmpty(userDto.Avatar) && string.IsNullOrEmpty(userDto.Email))
            {
                return BadRequest(new ResponseDTO { Status = "Error", Message = "Nothing to change" });
            }
            else
            {
                if (!string.IsNullOrEmpty(userDto.Avatar))
                {
                    bool result = await userService.ChangeAvatar(userDto.Avatar);
                    if (!result)
                    {
                        return StatusCode(500, new ResponseDTO { Status = "Error", Message = "Server didnt change avatar" });
                    }
                }
                if (!string.IsNullOrEmpty(userDto.Email))
                {
                    bool result = await userService.ChangeEmail(userDto.Email);
                    if (!result)
                    {
                        return StatusCode(500, new ResponseDTO { Status = "Error", Message = "Server didnt change email" });
                    }
                }
                return Ok(new ResponseDTO { Status = "Ok", Message = "Changes applied" });
            }
        }

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(UserDTO userDto)
        {
            if (string.IsNullOrEmpty(userDto.Password) || string.IsNullOrEmpty(userDto.NewPassword))
            {
                return BadRequest(new ResponseDTO { Status = "Error", Message = "Write your old and new password" });
            }
            else
            {
                bool result = await userService.ChangePassword(userDto);
                if (!result)
                {
                    return BadRequest(new ResponseDTO { Status = "Error", Message = "Wrong old password" });
                }
            }
            return Ok(new ResponseDTO { Status = "Ok", Message = "Password Changed" });
        }
    }
}
