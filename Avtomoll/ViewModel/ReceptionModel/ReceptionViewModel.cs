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
        public DataReception[] TimeReception { get; set; }
        public ReceptionViewModel(int size)
        {
            TimeReception = new DataReception[size];
        }
        //public IEnumerable<ServiceHistoryBriefViewModel> ServiceHistory { get; set; }
    }
    public class DataReception 
    {
        public DataReception()
        { }
        public DateTime Time { get; set; }
        public long ServiceHistoryId { get; set; }
    }
}