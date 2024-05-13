using Microsoft.EntityFrameworkCore;
using paymentSystemAPI.Api.Profiles.AutoMappings;
using paymentSystemAPI.Application.Interfaces.IRepository;
using paymentSystemAPI.Application.Interfaces.IServices;
using paymentSystemAPI.Application.Repositories;
using paymentSystemAPI.Application.Services;
using paymentSystemAPI.Dal.Data;
using paymentSystemAPI.Dal.Repositories;
using paymentSystemAPI.Domain.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IBaseRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IMerchantService, MerchantService>();
builder.Services.AddScoped<IBaseRepository<Merchant>, MerchantRepository>();
builder.Services.AddScoped<IMercentRepository, MerchantRepository>();

builder.Services.AddAutoMapper(typeof(PaymentApiMappings));

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
