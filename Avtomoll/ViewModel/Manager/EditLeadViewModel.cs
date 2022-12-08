using Avtomoll.Heplers;

namespace Avtomoll.ViewModel.Manager
{
    public class EditLeadViewModel
    {
        public ServiceHistoryViewModel lead;

        public EditLeadViewModel(ServiceHistoryViewModel lead)
        {
            CarTypeNative = HelperLeadStatus.CarTypeNative;
            CarTypeForeign = HelperLeadStatus.CarTypeForeign;

            AwaitingStatus =  HelperLeadStatus.Awaiting;
            ApprovedStatus = HelperLeadStatus.Approved;
            CompletedStatus = HelperLeadStatus.Completed;
            CanceledStatus = HelperLeadStatus.Canceled;

            this.lead = lead;
        }

        public string CarTypeNative { get; private set; }
        public string CarTypeForeign { get; private set; }
        public string AwaitingStatus { get; private set; }
        public string ApprovedStatus { get; private set; }
        public string CompletedStatus { get; private set; }
        public string CanceledStatus { get; private set; }
    }
}
