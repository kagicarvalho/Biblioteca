using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.CrossCutting.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace application
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
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);
            services.AddControllers();
            services.AddSwaggerGen(s =>{
                s.SwaggerDoc("v1", new OpenApiInfo{
                    Version = "v1",
                    Title = "Api Biblioteca",
                    Description = "Desenvolvido para ser reaproveitada em qualquer aplicação escolar - Estrutura DDD",
                    TermsOfService = new Uri("https://www.google.com"),
                    Contact = new OpenApiContact
                    {
                        Name  = "Kagi Adrian",
                        Email = "kagi.carvalho@outlook.com",
                        Url = new Uri("https://github.com/kagicarvalho")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de Licença de Uso",
                        Url = new Uri("https://www.google.com")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(s => {
            s.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiBiblioteca");
            s.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
