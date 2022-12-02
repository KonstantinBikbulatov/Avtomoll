using Avtomoll.Abstract;
using Avtomoll.Domains;
using Avtomoll.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Avtomoll.Controllers.Manager
{
    public class MessageController : Controller
    {
        private int _productQuantityPerPage = 3;
        private readonly IRepository<Message> _repositoryMessage;
        public MessageController(IRepository<Message> repositoryMessage)
        {
            _repositoryMessage = repositoryMessage;
        }
        [HttpGet("manager/message/{page?}")]
        public IActionResult Index(int page)
        {
            var query = _repositoryMessage
                .GetList();

            var messages = query
                .OrderBy(p => p.MessageId)
                .Skip((page - 1) * _productQuantityPerPage)
                .Take(_productQuantityPerPage)
                .Select(m => new BriefMessageViewModel(m));

            int totalProductsQuatity = query.Count();

            int pagesQuantity = (int)
                Math.Ceiling(
                totalProductsQuatity /
                (double)_productQuantityPerPage
                );

            var model = new ListMassageViewModel
            {
                NameModel = "Message",
                MessagesForPage = messages,
                ActivePage = page,
                PagesQuantity = pagesQuantity
            };

            return View(model);
        }
    }
}