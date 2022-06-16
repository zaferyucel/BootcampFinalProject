using Microsoft.Extensions.DependencyInjection;
using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using FluentValidation;

namespace BootcampFinalProject.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(Assembly.GetExecutingAssembly());
            collection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            collection.AddAutoMapper(Assembly.GetExecutingAssembly());
            
        }
    }
}
