using desafioItau.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace desafioItau.infra.Db.Mapping
{
    internal class HistoricoMapping : IEntityTypeConfiguration<Historico>
    {
        public void Configure(EntityTypeBuilder<Historico> builder)
        {
            builder.ToTable("historico");
            builder.HasKey(c =>  c.Id);
            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.IdTransacao).HasColumnName("id_transacao");
            builder.Property(c => c.IdStatus).HasColumnName("id_status");
            builder.Property(c => c.Operacao).HasColumnName("operacao");
            builder.Property(c => c.DataHora).HasColumnName("data_hora");


        }
    }
}
