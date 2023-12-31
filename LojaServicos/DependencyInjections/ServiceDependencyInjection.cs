﻿using LojaServicos.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace LojaServicos.DependencyInjections
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection AddServiceDependencyInjection(this IServiceCollection services)
        {
            services
                .AddServices();

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoServico, ProdutoServico>();
            services.AddScoped<IClienteServico, ClienteServico>();

            return services;
        }
    }
}
