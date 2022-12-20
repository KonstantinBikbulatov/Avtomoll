using Avtomoll.Domains;
using System;
using System.Collections.Generic;

namespace Avtomoll.ViewModel.ReceptionModel
{
    public class ReceptionViewModel
    {
        public DateTime TimeOpenCarservice { get; set; }
        public DateTime Date { get; set; }
        public long IdServiceHistory { get; set; }
        public IEnumerable<DateTime> Time { get; set; }
        public long[] TimeReception { get; set; }

        public ReceptionViewModel(int size)
        {
            TimeReception = new long[size];
        }
        //public IEnumerable<ServiceHistoryBriefViewModel> ServiceHistory { get; set; }
    }
}