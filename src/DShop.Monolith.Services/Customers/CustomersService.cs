using System;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain;
using DShop.Monolith.Core.Domain.Customers;
using DShop.Monolith.Core.Domain.Customers.Repositories;
using DShop.Monolith.Core.Types;
using DShop.Monolith.Services.Carts.Dtos;
using DShop.Monolith.Services.Customers.Queries;

namespace DShop.Monolith.Services.Customers
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customerRepository;
        private readonly ICartsRepository _cartsRepository;
        
        public CustomersService(ICustomersRepository customerRepository,
            ICartsRepository cartsRepository)
        {
            _customerRepository = customerRepository;
            _cartsRepository = cartsRepository;
        }

        public async Task<CustomerDto> GetAsync(Guid id)
        {
            var customer = await _customerRepository.GetAsync(id);

            return customer == null ? null : new CustomerDto
            {
                Id = customer.Id,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Country = customer.Country,
                CreatedAt = customer.CreatedAt
            };
        }

        public async Task<IPagedResult<CustomerDto>> BrowseAsync(BrowseCustomers query)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(Guid id, string email)
            => await _customerRepository.CreateAsync(new Customer(id, email));

        public async Task CompleteAsync(Guid id, string firstName, string lastName, 
            string address, string country)
        {
            var customer = await _customerRepository.GetAsync(id);
            if (customer.Completed)
            {
                throw new ServiceException("customer_already_completed", 
                    $"Customer account was already completed for user: '{id}'.");
            }
            customer.Complete(firstName, lastName, address, country);
            await _customerRepository.UpdateAsync(customer);
            var cart = new Cart(id);
            await _cartsRepository.CreateAsync(cart);
        }
    }
}