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
            builder.HasKey(c => new { c.Id, c.IdHistoricoOperacao});
            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.IdHistoricoOperacao).HasColumnName("id_historico_operacao");
            builder.Property(c => c.IdStatus).HasColumnName("id_status");
            builder.Property(c => c.Operacao).HasColumnName("operacao");
            builder.Property(c => c.DataHora).HasColumnName("data_hora");


        }
    }
}
