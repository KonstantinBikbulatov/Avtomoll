using Avtomoll.Domains;
using System.Collections.Generic;

namespace Avtomoll.Model
{
    public class ServiceModel
    {
        public string NameGroup { get; set; }
        public List<Service> Service { get; set; }
    }
}