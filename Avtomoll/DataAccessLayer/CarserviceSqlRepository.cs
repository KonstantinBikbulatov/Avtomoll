using Avtomoll.Abstract;
using Avtomoll.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Avtomoll.DataAccessLayer
{
    public class CarServiceSqlRepository : IRepository<CarService>
    {
        ApplicationDbContext context;

        public CarServiceSqlRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(CarService model)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public CarService FindByName(string name)
        {
            return context.CarService.Where(c => c.Address == name).FirstOrDefault();
        }

        public IEnumerable<CarService> GetList() => context.CarService;

        public CarService Read(long id)
        {
            return context.CarService.Find(id);
        }

        public void Update(CarService _model)
        {
            context.Update(_model);
            context.SaveChanges();
        }
    }
}
