using Avtomoll.Abstract;
using Avtomoll.Domains;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Avtomoll.Components
{
    public class LeadsCarServicesFilterViewComponent : ViewComponent
    {
        private IRepository<CarService> services;

        public LeadsCarServicesFilterViewComponent(IRepository<CarService> services)
        {
            this.services = services;
        }

        public IViewComponentResult Invoke()
        {
            return View(services.GetList().Select(s => s.Address));
        }
    }
}
