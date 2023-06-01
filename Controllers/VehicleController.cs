using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RoleAuthorization.Controllers
{
    [Authorize(Roles = "Admin,ServiceManager")]
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
