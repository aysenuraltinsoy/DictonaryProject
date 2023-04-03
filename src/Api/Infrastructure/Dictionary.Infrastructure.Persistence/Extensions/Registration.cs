using Dictionary.Api.Application.Interfaces.Repositories;
using Dictionary.Infrastructure.Persistence.Context;
using Dictionary.Infrastructure.Persistence.Repositories;
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

            //var seedData = new SeedData();
            //seedData.SeedAsync(configuration).GetAwaiter().GetResult();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<IEntryCommentVoteRepository, EmailConfirmationRepository>();
            services.AddScoped<IEntryCommentFavoriteRepository, EntryCommentFavoriteRepository>();
            services.AddScoped<IEntryCommentRepository, EntryCommentRepository>();
            services.AddScoped<IEntryCommentVoteRepository, EntryCommentVoteRepository>();
            services.AddScoped<IEntryFavoriteRepository, EntryFavoriteRepository>();
            services.AddScoped<IEntryVoteRepository, EntryVoteRepository>();

            return services;
        }
    }
}
