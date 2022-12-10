using Avtomoll.Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Avtomoll.ViewModel
{
    public class CarserviceViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public long CarServiceId { get; set; }
        [Required]
        [Display(Name = "Адресс")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Время открытия")]
        public string OpeningTine { get; set; }
        [Required]
        [Display(Name = "Время открытия")]
        public string ClosingTime { get; set; }
        [Required]
        [Display(Name = "Колличество машин, которое может принять автосервис одновременно")]
        public int CarsCapacity { get; set; }
        public CarserviceViewModel()
        {}
        public CarserviceViewModel(CarService model)
        {
            CarServiceId = model.CarServiceId;
            Address = model.Address;
            ClosingTime = model.ClosingTime;
            OpeningTine = model.OpeningTime;
            CarsCapacity = model.CarsCapacity;

        }
    }
}
