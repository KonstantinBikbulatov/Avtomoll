using Avtomoll.Domains;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Avtomoll.ViewModel
{
    public class ServiceOrderViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public long ServiceId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public List<SelectListItem> ListGroups { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int GroupServiceId { get; set; }
        public GroupService GroupService { get; set; }
        public string GroupName { get; set; }

        [Required()]
        [Display(Name = "Выбор услуги")]
        public string Name { get; set; }

        [Required()]
        [Display(Name = "Выбор времени")]
        public string Time { get; set; }
    }
}
