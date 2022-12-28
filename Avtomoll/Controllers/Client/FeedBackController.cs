using Avtomoll.Abstract;
using Avtomoll.DataAccessLayer;
using Avtomoll.Domains;
using Avtomoll.ViewModel.FeedBackModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace Avtomoll.Controllers.Manager
{
    public class FeedBackController : Controller
    {
        private readonly IRepository<FeedBack> _repositoryFeedBack;
        private readonly ApplicationDbContext _context;

        public FeedBackController(IRepository<FeedBack> repositoryFeedBack)
        {
            _repositoryFeedBack = repositoryFeedBack;
        }

        [Authorize(Roles = "Administrator,ContentManager,SalesManager")]
        public IActionResult Index(FeedBackViewModel model1)
        {

            var model = _repositoryFeedBack.GetList().Select(s => new FeedBackViewModel(s));

            model1.IsRead= true;


            return View(model);
        }

        public IActionResult Create()
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
                    DateTime = feedBack.DateTime,
                    IsRead = feedBack.IsRead = false,
                };

                _repositoryFeedBack.Create(modelfeedBack);

                return RedirectToAction("Index", "Home");
            }

            return View(feedBack);
        }

      
    }
}