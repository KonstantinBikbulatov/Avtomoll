using Avtomoll.Abstract;
using Avtomoll.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Avtomoll.DataAccessLayer
{
    public class ServiceHistorySqlRepository : IRepository<ServiceHistory>
    {
        private readonly ApplicationDbContext context;
        private DbSet<ServiceHistory> leads;

        public ServiceHistorySqlRepository(ApplicationDbContext context)
        {
            this.context = context;
            leads = context.ServiceHistory;
        }
        public void Create(ServiceHistory model)
        {
            leads.Add(model);
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            var lead = Read(id);
            leads.Remove(lead);
            context.SaveChanges();
        }

        public ServiceHistory FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ServiceHistory> GetList() => context.ServiceHistory;

        public ServiceHistory Read(long id) => leads.Find(id);

        public void Update(ServiceHistory model)
        {
            var serv = Read(model.ServiceHistoryId);

            serv.CarBrand = model.CarBrand;
            serv.NameClient = model.NameClient;
            serv.PhoneClient = model.PhoneClient;
            serv.Status = serv.Status;
            serv.VisitTime = model.VisitTime;
            serv.TypeCar = model.TypeCar;
            serv.Service = model.Service;

            context.SaveChanges();
        }
    }
}
