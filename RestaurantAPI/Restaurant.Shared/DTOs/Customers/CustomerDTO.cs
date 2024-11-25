using Restaurant.Domain.Models;

namespace Restaurant.Shared.DTOs.Customers
{
    public record CustomerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public CustomerDto() { }

        public CustomerDto(Guid Id,
                            string FirstName,
                            string LastName,
                            string PhoneNumber)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
        }

        public CustomerDto(Customer customer) : this(customer.Id, 
            customer.FirstName, 
            customer.LastName,
            customer.PhoneNumber) { }
    }
}
