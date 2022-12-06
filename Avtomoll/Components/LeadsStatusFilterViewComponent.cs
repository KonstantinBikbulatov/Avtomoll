using Avtomoll.Abstract;
using Avtomoll.Domains;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Avtomoll.Components
{
    public class LeadsStatusFilterViewComponent : ViewComponent
    {
        
        private List<string> statuses;
        public LeadsStatusFilterViewComponent(IRepository<CarService> services)
        {
            statuses = new List<string>()
            {
                "В ожидании",
                "Одобренные",
                "Выполненные",
                "Отмененные"
            };
        }

        public IViewComponentResult Invoke()
        {
            return View(statuses);
        }
    }
}
