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
    internal class HistoricoTransferenciaMapping : IEntityTypeConfiguration<HistoricoTransferencia>
    {
        public void Configure(EntityTypeBuilder<HistoricoTransferencia> builder)
        {
            builder.ToTable("historico_transferencia");
            
        }
    }
}
