using Avtomoll.Abstract;
using System;
using System.Collections.Generic;

namespace Avtomoll.ViewModel.ReceptionModel
{
    public class ListReseptionViewModel : IPagination
    {
        public int PagesQuantity { get; set; }
        public int ActivePage { get; set; }
        public string NameModel { get; set; }

        public List<ReceptionViewModel> ReceptionForPage { get; set; }
    }
}