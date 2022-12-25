using Avtomoll.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Avtomoll.ViewModel
{
    public class ServiceViewModel
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
        [Display(Name = "Название услуги")]
        public string Name { get; set; }

        [Required()]
        [Display(Name = "Стоимость для отечественного авто")]
        public string NativeCar { get; set; }

        [Required()]
        [Display(Name = "Стоимость для иномарки")]
        public string ForeignCar { get; set; }

        [Required()]
        [Display(Name = "Время выполнения")]
        public string LeadTime { get; set; }
        public int minuts { get; set; }
        public int hours { get; set; }
    }
}
