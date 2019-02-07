using System;
using Microsoft.EntityFrameworkCore;
using Pets.Data.Common;

namespace Pets.Data
{
    public class DbQueryRunner : IDbQueryRunner
    {
        public DbQueryRunner(PetsDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public PetsDbContext Context { get; set; }

        public void RunQuery(string query, params object[] parameters)
        {
            this.Context.Database.ExecuteSqlCommand(query, parameters);
        }

        public void Dispose()
        {
            this.Context?.Dispose();
        }
    }
}
