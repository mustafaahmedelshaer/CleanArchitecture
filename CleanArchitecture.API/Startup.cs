using CleanArchitecture.API.Middleware;
using CleanArchitecture.Application.IServices;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.IRepositories;
using CleanArchitecture.Domain.IRepositories.Base;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.InfraStructure.Reposatories;
using CleanArchitecture.InfraStructure.Reposatories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CleanArchitecture.API
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
            services.AddCors(options => options.AddPolicy("DemoCorsPolicy", build =>
            {

                build.WithOrigins(
                                // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                                Configuration["App:CorsOrigins"].ToString()
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                               //.Select(o => o.RemovePostFix("/"))
                               .ToArray()
                       )
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials();
            }));

            services.AddControllers();
            services.AddDbContext<DBDemoContext>(
                 m => m.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee.API", Version = "v1" });
            });
            //services.AddAutoMapper(typeof(Startup));
            //services.AddMediatR(typeof(CreateEmployeeHandler).GetTypeInfo().Assembly);
             services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IBookRepository, BookRepo>();
            services.AddScoped<IBookService, BookService>();

        }

     


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("DemoCorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
