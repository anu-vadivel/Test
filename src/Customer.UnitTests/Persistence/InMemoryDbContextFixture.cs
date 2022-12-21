using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Customer.Persistence;

namespace Customer.UnitTests.Persistence
{
    public class InMemoryDbContextFixture : IDisposable
    {
        public IMapper Mapper { get; }
        public CustomerDbContext Context { get; }

        public InMemoryDbContextFixture()
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddMaps("Customer.Persistence"); });

            Mapper = mappingConfig.CreateMapper();

            var options = new DbContextOptionsBuilder<CustomerDbContext>()
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            Context = new CustomerDbContext(options);
            Context.Database.EnsureCreated();
            CustomerDbInitializer.Initialize(Context);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
                Context.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}