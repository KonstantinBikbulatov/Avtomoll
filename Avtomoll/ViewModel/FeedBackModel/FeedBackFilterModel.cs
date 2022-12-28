using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;

namespace Avtomoll.ViewModel.FeedBackModel
{
    public class FeedBackFilterModel
    {

        [Display(Name = "Прочитано")]
        public int read { get; set; }


        public List<SelectListItem> ListRead { get; set; }

        public FeedBackFilterModel()
        {
            ListRead = new List<SelectListItem>();
        }

   
    }
}
