using Avtomoll.Abstract;
using Avtomoll.Domains;
using Avtomoll.Heplers;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomoll.Components
{
    public class LeadsStatusFilterViewComponent : ViewComponent
    {
        
        private Dictionary<string, int> statuses;

        public LeadsStatusFilterViewComponent(IRepository<CarService> services)
        {
            
        }

        public IViewComponentResult Invoke(int awaiting, int approved, 
            int completed, int canceled)
        {
            statuses = new Dictionary<string, int>()
            {
                [HelperLeadStatus.Awaiting] = awaiting,
                [HelperLeadStatus.Approved] = approved,
                [HelperLeadStatus.Completed] = completed,
                [HelperLeadStatus.Canceled] = canceled,
            };

            return View(statuses);
        }
    }
}
