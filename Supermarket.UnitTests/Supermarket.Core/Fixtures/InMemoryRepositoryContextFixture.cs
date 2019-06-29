using Microsoft.EntityFrameworkCore;
using Supermarket.Core.Context;
using System;

namespace Supermarket.UnitTests.Supermarket.Core.Fixtures
{
    public class InMemoryRepositoryContextFixture : IDisposable
    {

        public RepositoryContext RepositoryContext => InMemoryContext();

        public void Dispose()
        {
            RepositoryContext?.Dispose();
        }

        private static RepositoryContext InMemoryContext()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseInMemoryDatabase("test-supermarket-api-in-memory")
                .EnableSensitiveDataLogging()
                .Options;

            var context = new RepositoryContext(options);

            return context;
        }
    }
}
