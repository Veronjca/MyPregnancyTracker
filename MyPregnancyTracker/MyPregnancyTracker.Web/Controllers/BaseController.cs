using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPregnancyTracker.Web.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}
