using BlazorSozluk.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Infrastructure.Persistance.EntityConfigurations.Entry
{
    public class EntryEntityConfiguration:BaseEntityConfiguration<BlazorSozluk.Api.Domain.Models.Entry>
    {
        public override void Configure(EntityTypeBuilder<Api.Domain.Models.Entry> builder)
        {
            base.Configure(builder);

            builder.ToTable("entry", BlazerSozlukContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.CretedBy).
                WithMany(i => i.Entries).
                HasForeignKey(i => i.CreateById);
        }
    }
}
