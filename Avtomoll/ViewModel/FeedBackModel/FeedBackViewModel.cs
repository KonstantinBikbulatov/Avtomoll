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

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        public FeedBackViewModel()
        {

        }

        public FeedBackViewModel(FeedBack model)
        {
            MessageId= model.MessageId;
            Name= model.Name;
            Email= model.Email;
            Phone= model.Phone;
        }
    }
}
