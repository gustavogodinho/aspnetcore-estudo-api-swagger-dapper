using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace APIIndicadores
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Minha API Swagger",
                        Version = "v1",
                        Description = "Estudo de API REST criada com o ASP.NET Core 2.2 para consulta a indicadores econômicos",
                        Contact = new Contact
                        {
                            Name = "Gustavo Godinho",
                            Email = "gustavogodinho6@msn.com",
                            Url = "https://github.com/gustavogodinho"

                        }
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Indicadores Econômicos V1");
            });


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}