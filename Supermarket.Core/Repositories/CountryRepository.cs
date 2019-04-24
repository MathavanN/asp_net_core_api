using Supermarket.Core.Context;
using Supermarket.Core.Models;
using Supermarket.Core.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core.Repositories
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public async Task AddCountryAsync(Country country)
        {
            await AddAsync(country);
            await SaveAsync();
        }

        public async Task DeleteCountryAsync(Country country)
        {
            Remove(country);
            await SaveAsync();
        }

        public async Task<IEnumerable<Country>> FindByConditionCountriesAsync(Expression<Func<Country, bool>> expression)
        {
            return await FindByConditionAsync(expression);
        }

        public async Task<Country> FindByIdAsync(int id)
        {
            var country = await FindByConditionAsync(c => c.Id == id);
            return country.FirstOrDefault();
        }

        public async Task<IEnumerable<Country>> ListAllCountriesAsync()
        {
            return await ListAllAsync();
        }

        public async Task UpdateCountryAsync(Country country)
        {
            Update(country);
            await SaveAsync();
        }
    }
}
