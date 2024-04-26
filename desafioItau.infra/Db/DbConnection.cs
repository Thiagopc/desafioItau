using desafioItau.domain.Entities;
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
        public DbConnection(DbContextOptions options):base(options) { }


        public DbSet<HistoricoTransferencia> HistoricoTransferencias MyProperty { get; set; }


    }
}
