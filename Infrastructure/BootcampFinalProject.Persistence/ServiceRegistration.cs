using BootcampFinalProject.Application.Repositories.CategoryRepository;
using BootcampFinalProject.Application.Repositories.OfferRepository;
using BootcampFinalProject.Application.Repositories.ProductRepository;
using BootcampFinalProject.Domain.Entities.Authentications;
using BootcampFinalProject.Persistence.Contexts;
using BootcampFinalProject.Persistence.Repositories.CategoryRepository;
using BootcampFinalProject.Persistence.Repositories.OfferRepository;
using BootcampFinalProject.Persistence.Repositories.ProductRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<FinalProjectDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString), ServiceLifetime.Transient);

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<FinalProjectDbContext>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();


            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<IOfferReadRepository, OfferReadRepository>();
            services.AddScoped<IOfferWriteRepository, OfferWriteRepository>();
        }
    }
}
//