using Avtomoll.Abstract;
using Avtomoll.Domains;
using Avtomoll.ViewModel.FeedBackModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace Avtomoll.Controllers.Manager
{
    public class FeedBackController : Controller
    {
        private readonly IRepository<FeedBack> _repositoryFeedBack;

        public FeedBackController(IRepository<FeedBack> repositoryFeedBack)
        {
            _repositoryFeedBack = repositoryFeedBack;
        }

        [Authorize(Roles = "Administrator,ContentManager,SalesManager")]
        public IActionResult Index()
        {

            var model = _repositoryFeedBack.GetList().Select(s => new FeedBackViewModel(s));

            return View(model);
        }

        public IActionResult Create(long id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FeedBackViewModel feedBack)
        {

            if (ModelState.IsValid)
            {
                FeedBack modelfeedBack = new FeedBack()
                {
                    Name = feedBack.Name,
                    Phone = feedBack.Phone,
                    Email = feedBack.Email,
                };

                _repositoryFeedBack.Create(modelfeedBack);

                return RedirectToAction("Index", "Home");
            }

            return View(feedBack);
        }
    }
}