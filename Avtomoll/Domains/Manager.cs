﻿using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Avtomoll.Models;

namespace Avtomoll.Domains
{
    [Table("Managers")]
    public class Manager
    {
        [Key]
        public long ManagerId { get; set; }
        public string RoleManager { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
  
        public Manager(ManagerViewModel model)
        {
            ManagerId = model.ManagerId;
            RoleManager = model.RoleManager;
            Name = model.Name;
            Email = model.Email;
            Password = model.Password;
            PasswordConfirmation = model.PasswordConfirmation;
        }
    }
}