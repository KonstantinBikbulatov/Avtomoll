using Avtomoll.Abstract;
using Avtomoll.Domains;
using Avtomoll.ViewModel.Manager;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Avtomoll.Controllers.ServiceManager
{
    public class ServiceManagerController : Controller
    {
        public ServiceManagerController(IRepository<ServiceHistory> repository)
        {
            Repository = repository;
            model = Repository.GetList().Select(s => new ServiceHistoryViewModel(s));
        }

        private IEnumerable<ServiceHistoryViewModel> model;

        private IRepository<ServiceHistory> Repository { get; set; }

        public IActionResult Index()
        {
            return View(model);
        }
    }
}
