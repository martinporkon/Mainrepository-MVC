namespace Web.Domain.DTO
{
    public class OrderProductViewModel
    {
        public string Address { get; set; } = string.Empty;
        public OrderProductViewModel(string address)
        {
            Address = address;
        }
    }
}