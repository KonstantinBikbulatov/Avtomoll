using Avtomoll.Abstract;
using Avtomoll.DataAccessLayer;
using Avtomoll.Domains;
using Avtomoll.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Avtomoll.Controllers
{
    public class CarserviceController : Controller
    {
        private readonly IRepository<CarService> _repository;

        // 3) Инъекция зависимостей
        public CarserviceController(IRepository<CarService> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            IEnumerable<CarserviceViewModel> carservices = _repository.GetList().Select(s => new CarserviceViewModel(s));
            return View(carservices);
        }

        public IActionResult EditCarservice(int id)
        {
            var carservice = _repository.Read(id);
            CarserviceViewModel newCarservice = new CarserviceViewModel(carservice);
            return View(newCarservice);
        }


        public IActionResult CreateCarservice()
        {
            CarserviceViewModel newCarservice = new CarserviceViewModel();
            return View(newCarservice);
        }

        [HttpPost]
        public IActionResult Create(CarserviceViewModel model)
        {
            CarService carservice = new CarService()
            {
                OpeningTime = model.OpeningTine,
                ClosingTime = model.ClosingTime,
                CarsCapacity = model.CarsCapacity,
                Address = model.Address,
            };

            _repository.Update(carservice);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(CarserviceViewModel model)
        {
            CarService carservice = new CarService()
            {
                CarServiceId = model.CarServiceId,
                OpeningTime = model.OpeningTine,
                ClosingTime = model.ClosingTime,
                CarsCapacity = model.CarsCapacity,
                Address = model.Address,
            };

            _repository.Update(carservice);

            return RedirectToAction("Index");
        }
    }
}
