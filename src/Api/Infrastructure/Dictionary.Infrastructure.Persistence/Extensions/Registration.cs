using Dictionary.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Infrastructure.Persistence.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<DictionaryContext>(conf =>
            {
                var connStr = configuration["DictionaryDbConnectionString"].ToString();
                conf.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();  //veritabanına bağlanırken hata alınırsa retry mekanizması devreye giriyor
                });
            });

            var seedData = new SeedData();
            seedData.SeedAsync(configuration).GetAwaiter().GetResult();
            return services;
        }
    }
}
