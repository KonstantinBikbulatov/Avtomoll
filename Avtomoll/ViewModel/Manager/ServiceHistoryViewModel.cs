using Avtomoll.Domains;
using Avtomoll.Heplers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Xml.Linq;

namespace Avtomoll.ViewModel.Manager
{
    public class ServiceHistoryViewModel
    {
        public ServiceHistoryViewModel()
        {

        }
        public ServiceHistoryViewModel(ServiceHistory entry)
        {
            id = entry.ServiceHistoryId;
            CarService = entry.CarService;
            ClientCar = entry.ClientCar;
            Status = entry.Status;
            
            if(entry.User != null)
            {
                ClientName = entry.User.UserName;
                ClientPhone = entry.User.PhoneNumber;
            }
            else
            {
                ClientPhone = entry.PhoneClient;
                ClientName = entry.NameClient;
            }

            CarBrand = entry.CarBrand;
            TypeCar = entry.TypeCar;
            OrderTime = entry.OrderTime;
            VisitTime = entry.VisitTime;
            PriceService = entry.PriceService;
            
        }

        public long id { get; set; }

        public List<Service> Services { get; set; }
        public CarService CarService { get; set; }
        public ClientCar ClientCar { get; set; }

        [Display(Name = "Статус")]
        [Required()]
        public string Status { get; set; }

        [Display(Name = "ФИО")]
        [Required()]
        public string ClientName { get; set; }

        [Display(Name = "Телефон")]
        [Required()]
        public string ClientPhone { get; set; }

        [Display(Name = "Марка автомобиля")]
        [Required()]
        public string CarBrand { get; set; }

        [Display(Name = "Тип авто")]
        [Required()]
        public string TypeCar { get; set; }

        [Display(Name = "Общая стоимость услуг")]
        public int PriceService { get; set; }

        [Display(Name = "Примерная стоимость услуг")]
        public int ApproximatePriceService
        {
            get 
            {
                if(Services != null)
                {
                    if (TypeCar == HelperLeadStatus.CarTypeForeign)
                    {
                        return Services.Select(s => Convert.ToInt32(s.ForeignCar)).Sum();
                    }
                    else if (TypeCar == HelperLeadStatus.CarTypeNative)
                    {
                        return Services.Select(s => Convert.ToInt32(s.NativeCar)).Sum();
                    }

                    
                }
                return PriceService;

            }
        }


        [Display(Name = "Заказ был сделан")]
        [Required()]
        public DateTime OrderTime { get; set; }

        [Display(Name = "Сервис назначен на")]
        [Required()]
        public DateTime VisitTime { get; set; }
    }
}
