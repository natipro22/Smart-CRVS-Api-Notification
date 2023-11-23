namespace AppDiv.CRVS.Application.Contracts.DTOs
{
    public class AddressResponseDTOE
    {
        public string? Id { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? Zone { get; set; }
        public string? Woreda { get; set; }
        public string? Kebele { get; set; }

    }
    public class AddressResponseDTOView
    {
        public object? Id { get; set; }
        public object? Country { get; set; }
        public object? Region { get; set; }
        public object? Zone { get; set; }
        public object? Woreda { get; set; }
        public object? Kebele { get; set; }

    }
}