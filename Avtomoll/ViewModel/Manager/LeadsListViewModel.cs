using Avtomoll.Heplers;
using System.Collections.Generic;
using System.Linq;

namespace Avtomoll.ViewModel.Manager
{
    public class LeadsListViewModel
    {
        public IEnumerable<ServiceHistoryViewModel> leads;
        private IEnumerable<ServiceHistoryViewModel> allLeads;

        public ServiceHistoryViewModel emptyModel;
        public LeadsListViewModel(IEnumerable<ServiceHistoryViewModel> allLeads)
        {
            emptyModel = new ServiceHistoryViewModel();
            this.allLeads = allLeads;
        }

        public int AwaitingLeads => allLeads.Where(l => l.Status == HelperLeadStatus.Awaiting).Count();

        public int ApprovedLeads => allLeads.Where(l => l.Status == HelperLeadStatus.Approved).Count();

        public int CompletedLeads => allLeads.Where(l => l.Status == HelperLeadStatus.Completed).Count();

        public int CanceledLeads => allLeads.Where(l => l.Status == HelperLeadStatus.Canceled).Count();
    }
}
