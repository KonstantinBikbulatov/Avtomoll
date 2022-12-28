using Avtomoll.Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Avtomoll.ViewModel.FeedBackModel
{
    public class FeedBackViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public long? MessageId { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Время")]
        public DateTime DateTime { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;

        public FeedBackViewModel()
        {

        }

        public FeedBackViewModel(FeedBack model)
        {
            MessageId= model.MessageId;
            Name= model.Name;
            Email= model.Email;
            Phone= model.Phone;
            DateTime = model.DateTime;
            IsRead= model.IsRead;
        }
    }
}
