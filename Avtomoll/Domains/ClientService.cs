using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avtomoll.Domains
{
    [Table("ClientServices")]
    public class ClientService
    {
        [Key]
        public long ClientServiceId { get; set; }
        public Service Service { get; set; }
        public ServiceHistory ServiceHistory { get; set; }
    }
}