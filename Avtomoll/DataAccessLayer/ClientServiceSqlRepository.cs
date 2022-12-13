using Avtomoll.Abstract;
using Avtomoll.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Avtomoll.DataAccessLayer
{
    public class ClientServiceSqlRepository : IRepository<ClientService>
    {
        private readonly ApplicationDbContext _context;

        public ClientServiceSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(ClientService model)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public ClientService FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ClientService> GetList()
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<ClientService> GetListGroup()
        {
            throw new System.NotImplementedException();
        }

        public ClientService Read(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ClientService model)
        {
            throw new System.NotImplementedException();
        }
    }
}
