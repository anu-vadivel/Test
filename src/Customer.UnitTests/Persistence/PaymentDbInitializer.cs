using System.Collections.Generic;
using Customer.Persistence;
using Customer.Persistence.DAO;
using Customer.Tests.Common.TestData;

namespace Customer.UnitTests.Persistence
{
    public class CustomerDbInitializer
    {
        public static void Initialize(CustomerDbContext context)
        {
            SeedBanks(context);
        }

        private static void SeedBanks(CustomerDbContext context)
        {
            var data = new List<Bank>
            {
                new() { Name = "Bank1", Id = 1, IfscCode = "IfscCode-a" },
                new() { Name = "Bank2", Id = 2, IfscCode = "IfscCode-b" },
                new() { Name = "Bank3", Id = 3, IfscCode = "IfscCode-c" },
            };
            context.AddRange(data);
            context.SaveChanges();
        }
    }   
}