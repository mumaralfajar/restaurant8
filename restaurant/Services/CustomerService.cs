﻿using restaurant.Models.DTO.Request;
using restaurant.Models.DTO.Response;
using restaurant.Models.DTO;
using restaurant.Models;
using restaurant.Services.Interfaces;
using restaurant.Data;

namespace restaurant.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly RestaurantDbContext _context;

        public CustomerService(RestaurantDbContext context)
        {
            _context = context;
        }

        public ICollection<Customer> GetCustomers()
        {
            try
            {
                return _context.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResponseAPI<CustomerResponse> GetDetailCustomer(int customerId)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                if (customer != null)
                {
                    return new ResponseAPI<CustomerResponse>
                    {
                        Data = new CustomerResponse
                        {
                            CustomerId = customer.CustomerId,
                            CustomerName = customer.CustomerName,
                            CustomerAddress = customer.CustomerAddress,
                            CustomerPhone = customer.CustomerPhone,
                        },
                        Message = "Successfully loaded customer data"
                    };
                }
                else
                {
                    return new ResponseAPI<CustomerResponse>
                    {
                        Message = "Customer not found"
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResponseAPI<CustomerResponse> AddCustomer(CustomerRequest request)
        {
            var newCustomer = new Customer
            {
                CustomerName = request.CustomerName,
                CustomerAddress = request.CustomerAddress,
                CustomerPhone = request.CustomerPhone
            };

            try
            {
                _context.Customers.Add(newCustomer);
                _context.SaveChanges();

                return new ResponseAPI<CustomerResponse>
                {
                    Data = new CustomerResponse
                    {
                        CustomerId = newCustomer.CustomerId,
                        CustomerName = newCustomer.CustomerName,
                        CustomerAddress = newCustomer.CustomerAddress,
                        CustomerPhone = newCustomer.CustomerPhone,
                    },
                    Message = "Successfully added customer data"
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResponseAPI<CustomerResponse> EditCustomer(int customerId, CustomerRequest request)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(x => x.CustomerId == customerId);
                if (customer != null)
                {
                    customer.CustomerName = request.CustomerName;
                    customer.CustomerAddress = request.CustomerAddress;
                    customer.CustomerPhone = request.CustomerPhone;
                    _context.SaveChanges();

                    return new ResponseAPI<CustomerResponse>
                    {
                        Data = new CustomerResponse
                        {
                            CustomerId = customerId,
                            CustomerName = customer.CustomerName,
                            CustomerAddress = customer.CustomerAddress,
                            CustomerPhone = customer.CustomerPhone
                        },
                        Message = "Successfully updated customer data"
                    };
                }
                else
                {
                    return new ResponseAPI<CustomerResponse>
                    {
                        Message = "Customer not found"
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResponseAPI<CustomerResponse> DeleteCustomer(int customerId)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();

                    return new ResponseAPI<CustomerResponse>
                    {
                        Message = "Successfully deleted customer data"
                    };
                }
                else
                {
                    return new ResponseAPI<CustomerResponse>
                    {
                        Message = "Customer not found"
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
