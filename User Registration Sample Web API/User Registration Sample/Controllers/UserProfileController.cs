using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Registration_Sample.Models;

namespace User_Registration_Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserProfile()
        {
            string UserId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(UserId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("forAdmin")]
        public string GetForAdmin()
        {
            return "web method for Admin";
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        [Route("forCustomer")]
        public string GetForCustomer()
        {
            return "web method for Customer";
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Customer")]
        [Route("forCustomerAndAdmin")]
        public string GetForCustomerAndAdmin()
        {
            return "web method for Admin and Customer";
        }
    }
}
