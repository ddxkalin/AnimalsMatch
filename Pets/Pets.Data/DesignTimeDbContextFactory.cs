//using System.IO;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.EntityFrameworkCore.Diagnostics;
//using Microsoft.Extensions.Configuration;

//namespace Pets.Data
//{
//    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PetsDbContext>
//    {
//        public PetsDbContext CreateDbContext(string[] args)
//        {
//            var configuration = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                .Build();

//            var builder = new DbContextOptionsBuilder<PetsDbContext>();

//            var connectionString = configuration.GetConnectionString("DefaultConnection");

//            builder.UseSqlServer(connectionString);

//            // Stop client query evaluation
//            builder.ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));

//            return new PetsDbContext(builder.Options);
//        }
//    }
//}

//todo: need fix
