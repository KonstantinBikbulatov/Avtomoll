using Avtomoll.Abstract;
using Avtomoll.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Avtomoll.ViewModel
{
    public class MessageViewModel : IPagination
    {
        [HiddenInput(DisplayValue = false)]
        public Guid MessageId { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        public int PagesQuantity { get; set; }
        public int ActivePage { get; set; }
        public string NameModel { get; set; }
        //public IdentityUser? User { get; set; }

        public MessageViewModel(Message message)
        {
            MessageId = message.MessageId;
            Name = message.Name;
            Phone = message.Phone;
            Email = message.Email;
        }
    }
}
