using OnlineStore.Models.Domain;

namespace OnlineStore.Models.View
{
    public class HomePageViewModel
    {
        public List<Product>? Products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
