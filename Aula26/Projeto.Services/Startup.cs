using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Projeto.Data.Contexts;
using Projeto.Data.Contracts;
using Projeto.Data.Repositories;
namespace Projeto.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime.
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion
            (CompatibilityVersion.Version_2_1);
            #region EntityFramework
            services.AddDbContext<DataContext>
            (options => options.UseSqlServer
            (Configuration.GetConnectionString("Aula")));
            #endregion
            #region Swagger
            services.AddSwaggerGen(
            c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Sistema de Controle de Produtos",
                    Description = "API REST para integração com serviços de produtos",
                        Version = "v1",
                    Contact = new OpenApiContact
            {
                Name = "COTI Informática",
                Url = new Uri("http://www.cotiinformatica.com.br/"),
                Email = "contato@cotiinformatica.com.br"
            }
                });
            }
            );
            #endregion
            #region Injeção de Dependência
            services.AddTransient<IEstoqueRepository, EstoqueRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion
            #region AutoMapper
            services.AddAutoMapper(typeof(Startup));
            #endregion
        }
        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto API");
            });
            #endregion
            app.UseMvc();
        }
    }
}