using desafioItau.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.infra.Db.Mapping
{
    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("transacao");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("id");


            builder.HasMany(c => c.Historicos)
                .WithOne(c => c.Transacao)
                .HasForeignKey(c => c.IdTransacao);
        }
    }
}
