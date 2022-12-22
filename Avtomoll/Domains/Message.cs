using Microsoft.AspNetCore.Identity;
using System;

namespace Avtomoll.Domains
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IdentityUser User { get; set; }
        public string Text { get; set; }
        public string Status { get; set; }
    }
}