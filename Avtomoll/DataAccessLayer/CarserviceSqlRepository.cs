using Avtomoll.Abstract;
using Avtomoll.Domains;
using System.Collections.Generic;
using System.Linq;

namespace Avtomoll.DataAccessLayer
{
    public class CarserviceSqlRepository : IRepository<CarService>
    {
        private readonly ApplicationDbContext _context;

        public CarserviceSqlRepository(ApplicationDbContext context)
        {
            _context = context;
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
            return _context.CarService.Where(c => c.Address == name).FirstOrDefault();
        }

        public IEnumerable<CarService> GetList()
        {
            return _context.CarService;
        }

        public CarService Read(long id)
        {
            return _context.CarService.Find(id);
        }

        public void Update(CarService model)
        {
            throw new System.NotImplementedException();
        }
    }
}
