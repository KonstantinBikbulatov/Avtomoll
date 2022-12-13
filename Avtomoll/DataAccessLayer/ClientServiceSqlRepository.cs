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
        }

        public IEnumerable<Service> AllServicesFromLead(ServiceHistory lead)
        {
           return _context.ClientService.
                Where(r => r.ServiceHistory.ServiceHistoryId == lead.ServiceHistoryId).
                Select(r => r.Service);
        }

        public IEnumerable<ServiceHistory> AllLeadsWithService(Service service)
        {
            return _context.ClientService.
                Where(r => r.Service.ServiceId == service.ServiceId).
                Select(r => r.ServiceHistory);
        }


    }
}
