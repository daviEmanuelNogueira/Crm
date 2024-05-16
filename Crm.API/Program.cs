using Crm.Application.AutoMapper;
using Crm.Application.UseCases.StatusSubstatusUseCase;
using Crm.Application.UseCases.StatusUseCases;
using Crm.Application.UseCases.SubstatusUseCases;
using Crm.Domain.Interfaces;
using Crm.Infrastructure.Data;
using Crm.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(AutoMapperSetup));

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<CreateStatusUseCase>();
builder.Services.AddScoped<CreateSubtatusUseCase>();
builder.Services.AddScoped<GetAllStatusSubstatusUseCase>();
builder.Services.AddScoped<CreateStatusSubstatusUseCase>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<ISubstatusRepository, SubstatusRepository>();
builder.Services.AddScoped<IStatusSubstatusRepository, StatusSubstatusRepository>();

builder.Services.AddRouting(options => options.LowercaseUrls = true); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
