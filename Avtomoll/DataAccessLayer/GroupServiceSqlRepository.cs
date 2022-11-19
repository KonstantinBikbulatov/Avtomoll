using Avtomoll.Abstract;
using Avtomoll.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Avtomoll.DataAccessLayer
{
    public class GroupServiceSqlRepository : IRepository<GroupService>
    {
        private readonly ApplicationDbContext _context;

        public GroupServiceSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(GroupService model)
        {
            _context.GroupService.Add(model);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public GroupService FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<GroupService> GetList()
        {
            return _context.GroupService.Include(g => g.ServiceOfGroupService);
        }

        public GroupService Read(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(GroupService model)
        {
            throw new System.NotImplementedException();
        }
    }
}
