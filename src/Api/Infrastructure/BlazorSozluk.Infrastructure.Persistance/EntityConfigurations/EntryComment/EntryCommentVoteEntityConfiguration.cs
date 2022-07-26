﻿using BlazorSozluk.Infrastructure.Persistance.Context;
using BlazorSozluk.Infrastructure.Persistance.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorSozluk.Infrastructure.Persistence.EntityConfigurations.EntryComment;

public class EntryCommentVoteEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.EntryCommentVote>
{
    public override void Configure(EntityTypeBuilder<Api.Domain.Models.EntryCommentVote> builder)
    {
        base.Configure(builder);

        builder.ToTable("entrycommentvote", BlazerSozlukContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.EntryComment)
            .WithMany(i => i.EntryCommentVotes)
            .HasForeignKey(i => i.EntryCommentId);
    }
}
