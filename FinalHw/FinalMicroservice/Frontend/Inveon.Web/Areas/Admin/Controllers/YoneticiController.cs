using Inveon.Web.Hubs;
using Inveon.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Inveon.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class YoneticiController : Controller
    {
        private readonly IHubContext<ChatHub> _chatHub;
        public YoneticiController(IHubContext<ChatHub> chatHub)
        {
            _chatHub = chatHub;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Git()
        {
            return View();
        }
        public IActionResult AdminLogout()
        {
            return SignOut("Cookies", "oidc");
        }

        [Route("Chat")]
        [HttpPost]
        public IActionResult Chat([FromBody] Message message)
        {
            _chatHub.Clients.All.SendAsync("lastMessage", message);

            return Accepted();
        }
    }
}
