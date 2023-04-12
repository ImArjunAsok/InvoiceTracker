using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceTracker.API.Areas.User.Controllers
{
    [Area("User")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class UserBaseController : ControllerBase
    {
    }
}
