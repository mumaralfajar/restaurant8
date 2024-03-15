using restaurant.Models.DTO.Request;
using restaurant.Models.DTO.Response;
using restaurant.Models.DTO;
using restaurant.Models;

namespace restaurant.Services.Interfaces
{
    public interface ICustomerService
    {
        ICollection<Customer> GetCustomers();
        ResponseAPI<CustomerResponse> GetDetailCustomer(int customerId);
        ResponseAPI<CustomerResponse> AddCustomer(CustomerRequest request);
        ResponseAPI<CustomerResponse> EditCustomer(int customerId, CustomerRequest request);
        ResponseAPI<CustomerResponse> DeleteCustomer(int customerId);
    }
}
