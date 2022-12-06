using Avtomoll.Domains;
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
        public ServiceHistoryViewModel(ServiceHistory rowModel)
        {
            id = rowModel.ServiceHistoryId;
            CarService = rowModel.CarService;
            ClientCar = rowModel.ClientCar;
            Status = rowModel.Status;
            
            if(rowModel.User != null)
            {
                ClientName = rowModel.User.UserName;
                ClientPhone = rowModel.User.PhoneNumber;
            }
            else
            {
                ClientPhone = rowModel.PhoneClient;
                ClientName = rowModel.NameClient;
            }

            CarBrand = rowModel.CarBrand;
            TypeCar = rowModel.TypeCar;
            OrderTime = rowModel.OrderTime;
            VisitTime = rowModel.VisitTime;

            if (rowModel.Service != null)
            {
                Services = JsonConvert.DeserializeObject<List<Service>>(rowModel.Service);
            }
            
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
        public string CarBrand { get; set; }

        [Display(Name = "Тип авто")]
        [Required()]
        public string TypeCar { get; set; }

        [Display(Name = "Общая стоимость услуг")]
        public int PriceService { get; set; }

        [Display(Name = "Заказ был сделан")]
        [Required()]
        public DateTime OrderTime { get; set; }

        [Display(Name = "Сервис назначен на")]
        [Required()]
        public DateTime VisitTime { get; set; }
    }
}
