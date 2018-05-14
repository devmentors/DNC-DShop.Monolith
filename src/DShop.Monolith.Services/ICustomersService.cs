using System;
using System.Threading.Tasks;
using DShop.Monolith.Infrastructure.Types;
using DShop.Monolith.Services.DTO;
using DShop.Monolith.Services.Queries;

namespace DShop.Monolith.Services.Services
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