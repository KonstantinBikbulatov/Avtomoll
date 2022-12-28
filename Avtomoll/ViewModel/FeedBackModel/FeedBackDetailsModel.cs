using Avtomoll.Domains;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Avtomoll.ViewModel.FeedBackModel
{
    public class FeedBackDetailsModel
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
        [Display(Name = "Сообщение")]
        public string Description { get; set; }

        public FeedBackDetailsModel()
        {

        }

        public FeedBackDetailsModel(FeedBack model)
        {
            MessageId = model.MessageId;
            Name = model.Name;
            Email = model.Email;
            Description = model.Description;
        }
    }
}
