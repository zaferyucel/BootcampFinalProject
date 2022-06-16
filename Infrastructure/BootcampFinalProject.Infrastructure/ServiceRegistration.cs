using BootcampFinalProject.Application.Abstractions.Token;
using BootcampFinalProject.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }
        
        
    }
}
