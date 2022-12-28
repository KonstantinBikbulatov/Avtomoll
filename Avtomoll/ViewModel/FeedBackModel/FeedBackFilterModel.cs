using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;

namespace Avtomoll.ViewModel.FeedBackModel
{
    public class FeedBackFilterModel
    {
        public bool NeedApply { get; set; } = false;

        [Display(Name = "Прочитано")]
        public int MinPrice { get; set; }


        public List<SelectListItem> ListRead { get; set; }

        public FeedBackFilterModel()
        {
            ListRead = new List<SelectListItem>();
        }

   
    }
}
