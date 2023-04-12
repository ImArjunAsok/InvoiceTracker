using InvoiceTracker.Application.Services;
using InvoiceTracker.Core.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceTracker.API.Areas.User.Controllers
{
    public class RegistrationController : UserBaseController
    {
        private readonly ApplicationUserService _applicationUserService;

        public RegistrationController(ApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterDto dto)
        {
            var res = await _applicationUserService.RegisterUserAsync(dto);
            return Ok(res);
        }
    }
}
