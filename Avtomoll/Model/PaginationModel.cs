using System.Collections.Generic;

namespace Avtomoll.Model
{
    public class PaginationModel<T>
    {
        public int PagesQuantity { get; set; }
        public int ActivePage { get; set; }
    }
}
