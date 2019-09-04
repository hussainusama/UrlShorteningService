using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using UrlShorteningService.Contexts;
using UrlShorteningService.Encoders;

namespace UrlShorteningService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "UrlShorteningService", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => { 
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });

            var connectionString = Configuration["ConnectionStrings:DbConnectionString"];
            services.AddDbContext<UrlMapContext>(
                options => options.UseSqlServer(connectionString, providerOptions => providerOptions.EnableRetryOnFailure()));


            RegisterApplicationDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UrlMapContext context)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "UrlShorteningService");
                c.RoutePrefix = string.Empty;
            });

            context.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            

            app.UseMvc();
        }

        
        private void RegisterApplicationDependencies(IServiceCollection services)
        {
            services.AddTransient<IUrlMapContext, UrlMapContextWrapper>();
            services.AddTransient<IBase62Encoder, Base62Encoder>();
        }

    }
}
