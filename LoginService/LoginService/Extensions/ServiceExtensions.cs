using LoanMngt.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginService.Models;
using Microsoft.Extensions.Configuration;
namespace LoanMngt.Extensions
{
    public static class ServiceExtensions
    {
           public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
