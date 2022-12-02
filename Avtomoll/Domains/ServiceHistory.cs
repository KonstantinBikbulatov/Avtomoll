using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Avtomoll.Domains
{
    [Table("ServicesHistory")]
    public class ServiceHistory
    {
        public Guid ServiceHistoryId { get; set; }
        public string Services { get; set; }
        public CarService CarService { get; set; }
        public ClientCar ClientCar { get; set; }
        public string Status { get; set; }
        public IdentityUser User { get; set; }
        public string TypeCar { get; set; }
        public string NameClient { get; set; }
        public string PhoneClient { get; set; }
        public string CarBrand { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime VisitTime { get; set; }
        public int PriceService { get; set; }
        public long OrderNumber { get; set; }

        public void DeleteService(long serviceId)
        {
            List<Service> services = JsonConvert.DeserializeObject<List<Service>>(Services);

            services.Remove(services.First(s => s.ServiceId == serviceId));

            Services = JsonConvert.SerializeObject(services);
        }

        public void AddService(Service newService)
        {
            List<Service> services = JsonConvert.DeserializeObject<List<Service>>(Services);

            services.Add(newService);

            Services = JsonConvert.SerializeObject(services);
        }
    }
}