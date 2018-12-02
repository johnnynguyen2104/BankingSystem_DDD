using BankingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Persistence.Configurations
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder
              .HasMany(a => a.Histories)
              .WithOne(a => a.Account)
              .IsRequired()
              .HasForeignKey(a => a.AccountId);

            builder.Property(a => a.AccountNumber)
                .HasMaxLength(30);

            builder.Property(a => a.Currency)
                    .HasMaxLength(10);

            builder
                .Property(p => p.RowVersion)
                .IsConcurrencyToken();

        }
    }
}
