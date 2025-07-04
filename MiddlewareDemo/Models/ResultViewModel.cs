namespace MiddlewareDemo.Models
{
    public class ResultViewModel
    {
        public long ElapsedMilliseconds { get; set; }
        public bool IsSlow => ElapsedMilliseconds > 500;
    }
}
