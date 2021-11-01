using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Servicios.Repositorios;
using Servicios.Repositorios.Interfaces;
using Servicios.Servicios;
using Servicios.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_20212C_TP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_20212C_TP", Version = "v1" });
            });

            services.AddDbContext<Servicios.Entidades._20212C_TPContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("EFCoreContext"));
            });

            services.AddTransient<Servicios.Entidades._20212C_TPContext>();

            services.AddScoped<IRecetaRepositorio, RecetaRepositorio>();
            services.AddScoped<IRecetaServicio, RecetaServicio>();

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IUsuarioServicio, UsuarioServicio>();

            services.AddScoped<IEventoRepositorio, EventoRepositorio>();
            services.AddScoped<IEventoServicio, EventoServicio>();

            services.AddScoped<IComensalRepositorio, ComensalRepositorio>();
            services.AddScoped<IComensalServicio, ComensalServicio>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_20212C_TP v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
