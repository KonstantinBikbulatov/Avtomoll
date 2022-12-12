using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avtomoll.Domains
{
    [Table("ClientCars")]
    public class ClientCar
    {
        [Key]
        public long ClientCarId { get; set; }
        public IdentityUser User { get; set; }
        public string Name { get; set; }
    }
}
