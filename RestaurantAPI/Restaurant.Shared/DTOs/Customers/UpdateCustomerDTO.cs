namespace Restaurant.Shared.DTOs.Customers
{
    public record UpdateCustomerDTO(
        Guid Id,
        string FirstName,
        string LastName,
        string PhoneNumber
    );
}
