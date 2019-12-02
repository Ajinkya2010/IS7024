using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CrimeRecords.Models
{
    public class CrimeRecordsContext : DbContext
    {
        public CrimeRecordsContext (DbContextOptions<CrimeRecordsContext> options)
            : base(options)
        {
        }

        public DbSet<CrimeRecords.Models.Neighbourhood> Neighbourhood { get; set; }
    }
}
