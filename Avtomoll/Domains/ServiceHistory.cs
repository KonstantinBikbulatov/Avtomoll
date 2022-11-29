﻿using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}