using Avtomoll.Domains;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Avtomoll.Models
{
    public class ServiceViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public long ServiceId { get; set; }

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

        public ServiceViewModel(Service service)
        {
            ServiceId = service.ServiceId;
            Name = service.Name;
            NativeCar = service.NativeCar;
            ForeignCar = service.ForeignCar;
            LeadTime = service.LeadTime;

        }
    }
}
