using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RoleAuthorization.Controllers
{
    [Authorize(Roles = "Admin,PaymentManager")]
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
