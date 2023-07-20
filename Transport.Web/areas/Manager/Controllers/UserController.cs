using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Web.ApiHandler;
using SocialMedia.Web.Filters;
using SocialMedia.Web.Helpers;
using SocialMedia.Web.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [AllowAnonymous]
    [LoginFilter]
    public class UserController : Controller
    {
        private readonly RestApiHandler _restApiHandler;

        public UserController(RestApiHandler restApiHandler)
        {
            _restApiHandler = restApiHandler;
        }

        public async Task<IActionResult> List()
        {
            var Token = CookieHelper.GetCookieValue(HttpContext, "Token");
            var result = await _restApiHandler.GetAsync<CustomResponseDto<List<UserAppDto>>>("ManagerUser/GetAll",Token);
            return View(result.Data);
        }
    }
}
