using System;
using System.Threading.Tasks;
using DShop.Monolith.Core.Types;
using DShop.Monolith.Services.Customers.Queries;
using DShop.Monolith.Services.DTO;

namespace DShop.Monolith.Services.Customers
{
    public interface ICustomersService
    {
        Task<CustomerDto> GetAsync(Guid id);
        Task<PagedResult<CustomerDto>> BrowseAsync(BrowseCustomers query);
        Task CreateAsync(Guid id, string email);
        Task CompleteAsync(Guid id, string firstName, string lastName, 
            string address, string country);
    }
}