using Avtomoll.Abstract;
using System.Collections.Generic;

namespace Avtomoll.ViewModel
{
    public class ListMassageViewModel : IPagination
    {
        public int PagesQuantity { get; set; }
        public int ActivePage { get; set; }
        public string NameModel { get; set; }
        public IEnumerable<BriefMessageViewModel> MessagesForPage { get; set; }
    }
}
