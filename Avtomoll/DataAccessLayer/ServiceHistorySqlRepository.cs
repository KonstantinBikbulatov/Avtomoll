using Avtomoll.Abstract;
using Avtomoll.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Avtomoll.DataAccessLayer
{
    public class ServiceHistorySqlRepository : IRepository<ServiceHistory>
    {
        private readonly ApplicationDbContext context;
        private DbSet<ServiceHistory> entries;

        public ServiceHistorySqlRepository(ApplicationDbContext context)
        {
            this.context = context;
            entries = context.ServiceHistory;
        }
        public void Create(ServiceHistory model)
        {
            entries.Add(model);
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            var lead = Read(id);
            entries.Remove(lead);
            context.SaveChanges();
        }

        public ServiceHistory FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ServiceHistory> GetList() => context.ServiceHistory;

        public ServiceHistory Read(long id) => entries.Find(id);

        public void Update(ServiceHistory model)
        {
            var entry = Read(model.ServiceHistoryId);

            entry.CarBrand = model.CarBrand;
            entry.NameClient = model.NameClient;
            entry.PhoneClient = model.PhoneClient;
            entry.Status = model.Status;
            entry.VisitTime = model.VisitTime;
            entry.TypeCar = model.TypeCar;
            entry.Service = model.Service;
            entry.PriceService = model.PriceService;

            context.SaveChanges();
        }
    }
}
