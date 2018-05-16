using System;
using System.Threading.Tasks;
using DShop.Monolith.Core.Types;
using DShop.Monolith.Services.Carts.Dtos;
using DShop.Monolith.Services.Customers.Queries;

namespace DShop.Monolith.Services.Customers
{
    public interface ICustomersService
    {
        Task<CustomerDto> GetAsync(Guid id);
        Task<IPagedResult<CustomerDto>> BrowseAsync(BrowseCustomers query);
        Task CreateAsync(Guid id, string email);
        Task CompleteAsync(Guid id, string firstName, string lastName, 
            string address, string country);
    }
}