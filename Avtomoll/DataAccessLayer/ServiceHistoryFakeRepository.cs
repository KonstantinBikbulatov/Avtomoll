using Avtomoll.Abstract;
using Avtomoll.Domains;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avtomoll.DataAccessLayer
{
    public class ServiceHistoryFakeRepository : IRepository<ServiceHistory>
    {
        private string CreateFakeServiceJson()
        {
            var services = new List<Service>()
            {
                new Service()
                {
                    GroupService = new GroupService()
                    {
                        GroupServiceId = 1,
                        Name = "Lbfuyjcnbrf",
                        ServiceOfGroupService = null,
                    },

                    ForeignCar = "1222",
                    NativeCar = "1222",
                    Name = "Service 1 Name",
                    LeadTime = "15 minut",
                    ServiceId = 1
                },

                new Service()
                {
                    GroupService = new GroupService()
                    {
                        GroupServiceId = 1,
                        Name = "Lbfuyjcnbrf",
                        ServiceOfGroupService = null,
                    },

                    ForeignCar = "1500",
                    NativeCar = "1600",
                    Name = "Service 2 Name",
                    LeadTime = "25 minut",
                    ServiceId = 2
                },
            };


            return JsonConvert.SerializeObject(services);
        }
        public ServiceHistoryFakeRepository()
        {
            services = new List<ServiceHistory>{
                new ServiceHistory()
                {
                    User = null,
                    CarService = new CarService()
                    {
                        Address = "Address 1", CarServiceId = Guid.Empty, ClosingTime = "21:00", OpeningTime = "8:00"
                    },
                    CarBrand = "BMW",
                    ClientCar = null,
                    NameClient = "Dima",
                    OrderNumber = 0,
                    OrderTime = new DateTime(2022, 12, 01),
                    PhoneClient = "8922323239",
                    ServiceHistoryId = Guid.Empty,
                    PriceService = 0,
                    Services = CreateFakeServiceJson(),
                    Status = "Ожидание",
                    TypeCar = "Иномарка",
                    VisitTime = new DateTime(2022, 12, 01, 10, 0, 0)
                },
                new ServiceHistory()
                {
                    User = new Microsoft.AspNetCore.Identity.IdentityUser()
                    {
                        PhoneNumber = "8922323239",
                        UserName = "Nikolay",
                    },
                    CarService = new CarService()
                    {
                        Address = "Address 1", CarServiceId = Guid.Empty, ClosingTime = "21:00", OpeningTime = "8:00"
                    },
                    CarBrand = "Reno",
                    ClientCar = new ClientCar()
                    {
                        ClientCarId = Guid.Empty, Name = "Reno Megan 2",
                    },
                    NameClient = "Dima",
                    OrderNumber = 1,
                    OrderTime = new DateTime(2022, 11, 12),
                    PhoneClient = "8922323239",
                    ServiceHistoryId = Guid.Empty,
                    PriceService = 0,
                    Services = CreateFakeServiceJson(),
                    Status = "Ожидание",
                    TypeCar = "Иномарка",
                    VisitTime = new DateTime(2022, 11, 28, 19, 0, 0)
                },
                new ServiceHistory()
                {
                    User = null,
                    CarService = new CarService()
                    {
                        Address = "Address 1", CarServiceId = Guid.Empty, ClosingTime = "21:00", OpeningTime = "8:00"
                    },
                    CarBrand = "Lada",
                    ClientCar = null,
                    NameClient = "Олег",
                    OrderNumber = 2,
                    OrderTime = new DateTime(2022, 10, 30),
                    PhoneClient = "8922323239",
                    ServiceHistoryId = Guid.Empty,
                    PriceService = 0,
                    Services = CreateFakeServiceJson(),
                    Status = "Ожидание",
                    TypeCar = "Отечественная",
                    VisitTime = new DateTime(2022, 12, 12, 10, 0, 0)
                }

            };
        }

        private IEnumerable<ServiceHistory> services;

        public void Create(ServiceHistory model)
        {
            services.Append(model);
        }

        public void Delete(long id)
        {
            services = services.Where(serv => serv.OrderNumber != id);
        }

        public ServiceHistory FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ServiceHistory> GetList() => services;

        public ServiceHistory Read(long id)
        {
            return services.First(s => s.OrderNumber == id);
        }

        public void Update(ServiceHistory model)
        {
            var serv = Read(model.OrderNumber);

            serv.CarBrand = model.CarBrand;
            serv.NameClient = model.NameClient;
            serv.PhoneClient = model.PhoneClient;
            serv.Status = serv.Status;
            serv.VisitTime = model.VisitTime;
            serv.TypeCar = model.TypeCar;

        }
    }
}
