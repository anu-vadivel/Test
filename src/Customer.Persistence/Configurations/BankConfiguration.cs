
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Customer.Persistence.DAO;
using System.Reflection.Emit;

namespace Customer.Persistence.Configurations
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasIndex(b => b.IfscCode).IsUnique();
        }
    }
}
