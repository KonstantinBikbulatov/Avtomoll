using Avtomoll.Abstract;
using Avtomoll.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avtomoll.DataAccessLayer
{
    public class FeedBackSqlRepository : IRepository<FeedBack>
    {
        private readonly ApplicationDbContext _context;
        private DbSet<FeedBack> entries;

        public FeedBackSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(FeedBack model)
        {
            _context.FeedBack.Add(model);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var lead = Read(id);
            entries.Remove(lead);
            _context.SaveChanges();
        }

        public FeedBack FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<FeedBack> GetList()
        {
            return _context.FeedBack;
        }

        public FeedBack Read(long id)
        {
            var entry = _context
             .FeedBack
             .Include(p => p.Name)
             .FirstOrDefault(p => p.MessageId == id);
            return entry;
        }

        public void Update(FeedBack model)
        {
            throw new System.NotImplementedException();
        }
    }
}
