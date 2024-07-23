using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealTimeUsingSockets.Application.Interfaces;
using RealTimeUsingSockets.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeUsingSockets.Persistence
{
    public static class ServiceExtensions
    {   
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
