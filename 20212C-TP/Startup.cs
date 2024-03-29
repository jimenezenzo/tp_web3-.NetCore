using _20212C_TP.Filtros;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Servicios.Repositorios;
using Servicios.Repositorios.Interfaces;
using Servicios.Servicios;
using Servicios.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace _20212C_TP
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
            services.AddDistributedMemoryCache();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.Name = ".TPWEB3.Session";
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

            services.AddScoped<ITipoRecetaRepositorio, TipoRecetaRepositorio>();
            services.AddScoped<ITipoRecetaServicio, TipoRecetaServicio>();

            services.AddScoped<ICalificacionesRepositorio, CalificacionesRepositorio>();
            services.AddScoped<ICalificacionesServicio, CalificacionesServicio>();

            services.AddScoped<IEventoCocineroRepositorio, EventoCocineroRepositorio>();
            services.AddScoped<IEventoCocineroServicio, EventoCocineroServicio>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePages(async context => {
                var request = context.HttpContext.Request;
                var response = context.HttpContext.Response;

                if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    response.Redirect("/errores/status401");
                }
            });

            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
