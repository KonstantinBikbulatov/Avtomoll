using Avtomoll.ViewModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Avtomoll.Domains
{
    [Table("Services")]
    public class Service
    {
        [Key]
        public long ServiceId { get; set; }
        public string Name { get; set; }
        public string NativeCar { get; set; }
        public string ForeignCar { get; set; }
        public string LeadTime { get; set; }
        public GroupService GroupService { get; set; }
        public Service()
        {}
        public Service(ServiceViewModel model)
        {
            ServiceId = model.ServiceId;
            Name = model.Name;
            NativeCar = model.NativeCar;
            ForeignCar = model.ForeignCar;
            LeadTime = model.LeadTime;
            GroupService = model.GroupService;
        }
    }
}