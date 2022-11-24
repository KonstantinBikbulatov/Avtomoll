using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avtomoll.Domains
{
    [Table("ClientCars")]
    public class ClientCar
    {
        public Guid ClientCarId { get; set; }
        public IdentityUser User { get; set; }
        public string Name { get; set; }
    }
}
