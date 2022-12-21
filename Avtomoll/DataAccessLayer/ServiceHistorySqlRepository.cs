using Avtomoll.Abstract;
using Avtomoll.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Avtomoll.DataAccessLayer
{
    public class ServiceHistorySqlRepository : IRepository<ServiceHistory>
    {
        private readonly ApplicationDbContext _context;
        private DbSet<ServiceHistory> entries;

        public ServiceHistorySqlRepository(ApplicationDbContext context)
        {
            _context = context;
            entries = context.ServiceHistory;
        }

        public void Create(ServiceHistory model)
        {
            entries.Add(model);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var lead = Read(id);
            entries.Remove(lead);
            _context.SaveChanges();
        }

        public ServiceHistory FindByName(string name)
        {
            return _context.ServiceHistory.Find();
        }

        public IEnumerable<ServiceHistory> GetList() => _context.ServiceHistory.Include(c => c.CarService);

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
           // entry.Service = model.Service;
            entry.PriceService = model.PriceService;

            _context.SaveChanges();
        }
    }
}
