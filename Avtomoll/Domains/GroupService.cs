using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avtomoll.Domains
{
    [Table("GroupServices")]
    public class GroupService
    {
        [Key]
        public long GroupServiceId { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Service> ServiceOfGroupService { get; set; }
    }
}