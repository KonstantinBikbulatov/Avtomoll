using Avtomoll.Abstract;
using Avtomoll.Domains;
using System.Collections.Generic;

namespace Avtomoll.DataAccessLayer
{
    public class MessageSqlRepository : IRepository<Message>
    {
        private readonly ApplicationDbContext _context;
        public MessageSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Message model)
        {
            _context.Message.Add(model);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Message FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Message> GetList()
        {
            return _context.Message;
        }

        public Message Read(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Message model)
        {
            throw new System.NotImplementedException();
        }
    }
}
