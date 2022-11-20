using Avtomoll.Abstract;
using Avtomoll.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Avtomoll.DataAccessLayer
{
    public class ServiceSqlRepository : IRepository<Service>
    {
        public ServiceSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly ApplicationDbContext _context;
        public void Create(Service model)
        {
            _context.Service.Add(model);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Service FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Service> GetList()
        {
            return _context
                .Service
                .Include(g => g.GroupService);
        }

        public Service Read(long id)
        {
            return _context.Service.FirstOrDefault(s => s.ServiceId == id);
        }

        public void Update(Service model)
        {
            throw new System.NotImplementedException();
        }
    }
}
