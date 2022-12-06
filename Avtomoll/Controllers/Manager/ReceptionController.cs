using Avtomoll.Abstract;
using Avtomoll.Domains;
using Avtomoll.ViewModel.ReceptionModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Avtomoll.Controllers.Manager
{
    public class ReceptionController : Controller
    {
        private int _receptionQuantityPerPage = 7;

        private int countDate = 7;
        private readonly IRepository<ServiceHistory> _repositoryServiceHistory;
        private readonly IRepository<CarService> _repositoryCarservice;
        public ReceptionController(IRepository<ServiceHistory> repositoryServiceHistory, IRepository<CarService> repositoryCarservice)
        {
            _repositoryServiceHistory = repositoryServiceHistory;
            _repositoryCarservice = repositoryCarservice;
        }
        [HttpGet("manager/reception/{page?}")]
        public IActionResult Index(int page)
        {
            if(page == 0)
            {
                page = 1;
            }

            List<DateTime> dates = new List<DateTime>();
            ListReseptionViewModel model = new ListReseptionViewModel();
            model.ReceptionForPage = new List<ReceptionViewModel>();

            for (int i = 0; i < countDate; i++)
            {
                DateTime dateTime = new DateTime();
                dateTime.AddDays(i);
                dates.Add(dateTime);
            }

            var carService = _repositoryCarservice.Read(5);
            
            var startSt = carService.OpeningTime.Split(":");
            var endSt = carService.ClosingTime.Split(":");

            float result = (Int32.Parse(endSt[0]) - Int32.Parse(startSt[0])) * 2;

            if (Int32.Parse(startSt[1]) == 30)
            {
                result -= 1;
            }
            if (Int32.Parse(endSt[1]) == 30)
            {
                result += 1;
            }
            
            var openTime = new DateTime()
            .AddHours(Int32.Parse(startSt[0]))
            .AddMinutes(Int32.Parse(startSt[1]));

            var date = DateTime.Now;
            
            date = date.AddDays((page == 1 ? 0 : page - 1) * _receptionQuantityPerPage);

            for (int i = 0; i < _receptionQuantityPerPage; i++)
            {
                //day += i;
                var reception = new ReceptionViewModel((int)result);
                var listService = _repositoryServiceHistory.GetList().Where(r => r.VisitTime.Day == date.Day).ToList();
                reception.Date = date;
                date = date.AddDays(1);

                foreach (var item in listService)
                {
                    var hour = (item.VisitTime.Hour - Int32.Parse(startSt[0])) * 2;
                    if (item.VisitTime.Minute == 30)
                    {
                        hour += 1;
                    }
                    reception.TimeReception[hour] = item.ServiceHistoryId;
                }
                reception.TimeOpenCarservice = openTime;
                model.ReceptionForPage.Add(reception);
            }

            model.ActivePage = page == 0 ? 1 : page;
            model.NameModel = "reception";
            model.PagesQuantity = 7;

            return View(model);
        }
    }
}