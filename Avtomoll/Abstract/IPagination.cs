namespace Avtomoll.Abstract
{
    public interface IPagination
    {
        public string NameModel { get; set; }
        public int PagesQuantity { get; set; }
        public int ActivePage { get; set; }
    }
}
