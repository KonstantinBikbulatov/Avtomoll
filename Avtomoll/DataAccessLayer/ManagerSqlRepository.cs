using Avtomoll.Abstract;
using Avtomoll.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System.Collections.Generic;
using System.Linq;

namespace Avtomoll.DataAccessLayer
{
    public class ManagerSqlRepository : IRepository<Manager>
    {
        private readonly ApplicationDbContext _context;

        public ManagerSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Manager model)
        {
            _context.Manager.Add(model);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entry = _context.Manager.Find(id);
            _context.Manager.Remove(entry);
            _context.SaveChanges();
        }

        public Manager FindByName(string name) =>
            _context.Manager
                .FirstOrDefault(x => x.Name == name);


        public IEnumerable<Manager> GetList()
        {
            return _context.Manager;
        }

        public Manager Read(long id)
        {
            var entry = _context.Manager.Find(id);
            return entry;
        }

        public void Update(Manager model)
        {
            var entry = _context.Manager.FirstOrDefault(s => s.ManagerId == model.ManagerId);
            entry.RoleManager = model.RoleManager;
            entry.Name = model.Name;
            entry.Email = model.Email;
            entry.Password = model.Password;
            entry.PasswordConfirmation = model.PasswordConfirmation;
            _context.SaveChanges();
        }
    }
}
