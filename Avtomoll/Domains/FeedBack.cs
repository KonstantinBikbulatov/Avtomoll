using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avtomoll.Domains
{
    [Table("FeedBacks")]
    public class FeedBack
    {
        [Key]
        public long? MessageId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;
    }
}
