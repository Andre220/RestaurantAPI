namespace Restaurant.Shared.DTOs.Customers
{
    public record CreateCustomerDTO(
        Guid Id,
        string FirstName,
        string LastName,
        string PhoneNumber
    );
}
