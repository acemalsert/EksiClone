using BlazorSozluk.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Infrastructure.Persistance.Extensions
{
    public static class Registiration
    {
        public static IServiceCollection AddInfrastructureRegistiration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BlazerSozlukContext>(conf =>
            {
                var connStr = configuration["BlazorSozlukDbConnectionString"].ToString();
                conf.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });
            return services;
        }
    }
}
