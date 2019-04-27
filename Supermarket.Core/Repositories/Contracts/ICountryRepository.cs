using Supermarket.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Supermarket.Core.Repositories.Contracts
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> ListAllCountriesAsync();
        Task<Country> FindByIdAsync(int id);
        Task<IEnumerable<Country>> FindByConditionCountriesAsync(Expression<Func<Country, bool>> expression);
        Task AddCountryAsync(Country country);
        Task UpdateCountryAsync(Country country);
        Task DeleteCountryAsync(Country country);
    }
}
