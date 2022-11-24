using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avtomoll.Domains
{
    [Table("CarServices")]
    public class CarService
    {
        public Guid CarServiceId { get; set; }
        public string Address { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
    }
}
