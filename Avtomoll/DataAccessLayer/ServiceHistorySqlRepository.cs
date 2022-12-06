using Avtomoll.Abstract;
using Avtomoll.Domains;
using System.Collections.Generic;

namespace Avtomoll.DataAccessLayer
{
    public class ServiceHistorySqlRepository : IRepository<ServiceHistory>
    {
        public ServiceHistorySqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly ApplicationDbContext _context;

        public void Create(ServiceHistory model)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public ServiceHistory FindByName(string name)
        {
            return _context.ServiceHistory.Find();
        }

        public IEnumerable<ServiceHistory> GetList()
        {
            return _context.ServiceHistory;
        }

        public ServiceHistory Read(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ServiceHistory model)
        {
            throw new System.NotImplementedException();
        }
    }
}
