using Avtomoll.Abstract;
using Avtomoll.Domains;
using Avtomoll.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Avtomoll.Controllers.Manager
{
    public class FeedBackController : Controller
    {
        private readonly IRepository<Message> _repositoryMessage;

        public FeedBackController(IRepository<Message> repositoryMessage)
        {
            _repositoryMessage = repositoryMessage;
        }

        [HttpGet("/feedback")]
        public IActionResult Index(MessageViewModel message)
        {
            return View(message);
        }

        [HttpPost]
        public IActionResult FeedBack(MessageViewModel message)
        {
            Message modelMessage = new Message()
            {
                Name = message.Name,
                Phone = message.Phone,
                Email = message.Email,
            };

            _repositoryMessage.Create(modelMessage);
            return View();
        }
    }
}