using Avtomoll.Abstract;
using Avtomoll.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Avtomoll.DataAccessLayer
{
    public class ManagerJsonRepository : IRepository<ManagerViewModel>
    {
        private readonly string _filename = "manager.json";
        private readonly IWebHostEnvironment _environment;
        private List<ManagerViewModel> _managers;

        public ManagerJsonRepository(IWebHostEnvironment environment)
        {
            _environment = environment;
            LoadManagers();
        }

        private void LoadManagers()
        {
            string path = _environment.ContentRootPath;
            string filepath = Path.Combine(path, "ManagerJson", _filename);
            string jsonContent = File.ReadAllText(filepath);

            _managers = JsonConvert.DeserializeObject<List<ManagerViewModel>>(jsonContent) ??
                new List<ManagerViewModel>();
        }

        private void SubmitChanges()
        {
            string path = _environment.ContentRootPath;
            string filepath = Path.Combine(path, "ManagerJson", _filename);
            string jsonContent = JsonConvert.SerializeObject(_managers);
            File.WriteAllText(filepath, jsonContent);
        }

        public void Create(ManagerViewModel model)
        {
            _managers.Add(model);

            SubmitChanges();
        }

        public void Delete(long id) 
        {
            int index = _managers.FindIndex(x => x.ManagerId == id);
            if (index == -1) return;

            _managers.RemoveAt(index);

            SubmitChanges();
        }

        public IEnumerable<ManagerViewModel> GetList()
        {
            return _managers.Skip(0).Take(10);
        }

        public ManagerViewModel Read(long id)
        {
            return _managers.FirstOrDefault(x => x.ManagerId == id);
        }

        public void Update(ManagerViewModel model)
        {
            var entry = _managers.FirstOrDefault(x => x.ManagerId == model.ManagerId);

            entry.RoleManager = model.RoleManager;
            entry.Name = model.Name;
            entry.Email= model.Email;
            entry.Password = model.Password;
            entry.PasswordConfirmation = model.PasswordConfirmation;

            SubmitChanges();
        }

        public ManagerViewModel FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
