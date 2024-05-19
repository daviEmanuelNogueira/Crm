using Crm.Application.AutoMapper;
using Crm.Application.UseCases.AtendimentoUseCase;
using Crm.Application.UseCases.MotivoUseCase;
using Crm.Application.UseCases.StatusSubstatusUseCase;
using Crm.Application.UseCases.StatusUseCases;
using Crm.Application.UseCases.SubstatusUseCases;
using Crm.Domain.Interfaces;
using Crm.Infrastructure.Data;
using Crm.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Crm.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperSetup));

            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<CreateStatusUseCase>();
            services.AddScoped<CreateSubtatusUseCase>();
            services.AddScoped<CreateMotivoUseCase>();
            services.AddScoped<CreateAtendimentoUseCase>();
            services.AddScoped<GetAllStatusSubstatusUseCase>();
            services.AddScoped<CreateStatusSubstatusUseCase>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ISubstatusRepository, SubstatusRepository>();
            services.AddScoped<IStatusSubstatusRepository, StatusSubstatusRepository>();
            services.AddScoped<IMotivoRepository, MotivoRepository>();
            services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
