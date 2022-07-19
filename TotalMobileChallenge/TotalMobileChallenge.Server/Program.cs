using Microsoft.EntityFrameworkCore;
using TotalMobileChallenge.Server.Context;
using TotalMobileChallenge.Server.Core.Interfaces;
using TotalMobileChallenge.Server.Core.Logic;
using TotalMobileChallenge.Server.Incoming.Adapters;
using TotalMobileChallenge.Server.Incoming.Ports;
using TotalMobileChallenge.Server.Outgoing.Adapters;
using TotalMobileChallenge.Server.Outgoing.Ports;

var builder = WebApplication.CreateBuilder(args);

var corsString = "myCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsString,
                      policy =>
                      {
                          policy
                              .AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                      });
});

var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CompanyContext>(options => options.UseSqlServer(config.GetConnectionString("TotalMobileConnStr")));

builder.Services.AddScoped<IGetEmployeeInfoDB, GetEmployeeInfoDBAdapter>();
builder.Services.AddScoped<IGetShiftInfoDB, GetShiftInfoDBAdapter>();
builder.Services.AddScoped<IGetEmployeeShiftDB, GetEmployeeShiftInfoDBAdapter>();

builder.Services.AddScoped<IGetEmployeesLogic, GetEmployeesLogic>();
builder.Services.AddScoped<IGetHoursWorkedLogic, GetHoursWorkedLogic>();

builder.Services.AddScoped<IGetData, GetDataAdapter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsString);

app.UseAuthorization();

app.MapControllers();

app.Run();
