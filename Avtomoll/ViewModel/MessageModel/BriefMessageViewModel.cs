using Avtomoll.Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Avtomoll.ViewModel
{
    public class BriefMessageViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid MessageId { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        //public IdentityUser? User { get; set; }
        public BriefMessageViewModel(Message message)
        {
            MessageId = message.MessageId;
            Name = message.Name;
            Phone = message.Phone;
            Email = message.Email;
        }
    }
}
