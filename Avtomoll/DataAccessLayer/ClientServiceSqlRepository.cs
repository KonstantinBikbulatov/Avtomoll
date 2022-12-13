using Avtomoll.Abstract;
using Avtomoll.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Avtomoll.DataAccessLayer
{
    public class ClientServiceSqlRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientServiceSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(ServiceHistory lead, Service service)
        {
            ClientService relation = new ClientService()
            {
                ServiceHistory = lead,
                Service = service
            };

            _context.ClientService.Add(relation);
            _context.SaveChanges();
        }

        public List<Service> AllServicesFromLead(long LeadId)
        {
           return _context.ClientService.
                Where(r => r.ServiceHistory.ServiceHistoryId == LeadId).
                Select(r => r.Service).ToList();
        }

        public List<ServiceHistory> AllLeadsWithService(long ServiceId)
        {
            return _context.ClientService.
                Where(r => r.Service.ServiceId == ServiceId).
                Select(r => r.ServiceHistory).ToList();
        }

        public void Cancel(long ServiceId, long LeadId)
        {
            var relation = _context.ClientService.Where(r => r.Service.ServiceId == ServiceId &&
            r.ServiceHistory.ServiceHistoryId == LeadId).First();

            _context.ClientService.Remove(relation);
            _context.SaveChanges();
        }


    }
}
