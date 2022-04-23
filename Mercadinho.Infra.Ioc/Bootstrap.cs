﻿using Mercadinho.Application.App;
using Mercadinho.Application.Interface;
using Mercadinho.Data;
using Mercadinho.Data.Repositories;
using Mercadinho.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mercadinho.Infra.Ioc
{
    public class Bootstrap
    {
        public static void RegistroDeServicos(IServiceCollection services, IConfiguration configuration)
        {
            // Repositorios
            services.AddScoped(typeof(IBaseRespositorio<>), typeof(BaseRepositorio<>));
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IItemCarrinhoRepositorio, ItemCarrinhoRepositorio>();
            services.AddScoped<ICarrinhoDeComprasRepositorio, CarrinhoDeComprasRepositorio>();
            services.AddScoped<ICaixaRepositorio, CaixaRepositorio>();

            // Aplicação 
            services.AddScoped<IProdutoAplicacao, ProdutoAplicacao>();
            services.AddScoped<IItemCarrinhoAplicacao, ItemCarrinhoAplicacao>();
            services.AddScoped<ICarrinhoDeComprasAplicacao, CarrinhoDeComprasAplicacao>();
            services.AddScoped<ICaixaAplicacao, CaixaAplicacao>();

            services.AddDbContext<Contexto>(options => 
                options.UseSqlServer(configuration.GetConnectionString("Conexao"))    
            );
        }
    }
}
