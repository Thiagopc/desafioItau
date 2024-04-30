using desafioItau.domain.Entities;
using desafioItau.infra.Db.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.infra.Db
{
    public class DbConnection : DbContext
    {

        static DbConnection()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbConnection(DbContextOptions options):base(options) { }


        public DbSet<Transacao> Transacoes  { get; set; }
        public DbSet<Historico> Historicos  { get; set; }

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new TransacaoMapping());
            //modelBuilder.ApplyConfiguration(new HistoricoTransferenciaMapping());
            modelBuilder.ApplyConfiguration(new TransacaoMapping());
            modelBuilder.ApplyConfiguration(new HistoricoMapping());
        }

    }
}
