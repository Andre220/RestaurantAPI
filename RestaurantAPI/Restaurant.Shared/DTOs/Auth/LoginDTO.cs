namespace Restaurant.Shared.DTOs.Auth
{
    public record LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
