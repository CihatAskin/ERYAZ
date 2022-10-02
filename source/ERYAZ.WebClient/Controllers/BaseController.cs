using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERYAZ.WebClient.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
