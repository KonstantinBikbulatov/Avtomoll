using Avtomoll.Domains;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Avtomoll.ViewModel.Manager;

namespace Avtomoll.ViewModel
{
    public class ServiceOrderViewModel
    {
        public ServiceHistoryViewModel ServiceHistory { get; set; }
        public string CarTypeNative { get; set; }
        public string CarTypeForeign { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }
}
