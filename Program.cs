using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesOrdersAPI.Container;
using SalesOrdersAPI.Handler;
using SalesOrdersAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Sales_DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
});

builder.Services.AddTransient<ICustomerContainer, CustomerContainer>();
builder.Services.AddTransient<IInvoiceContainer, InvoiceContainer>();
builder.Services.AddTransient<IProductContainer, ProductContainer>();
builder.Services.AddTransient<IMasterContainer, MasterContainer>();

var automapper = new MapperConfiguration(item => item.AddProfile(new MappingProfile()));
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200");
        policy.WithMethods("GET", "POST", "DELETE", "PUT");
        policy.AllowAnyHeader(); // <--- list the allowed headers here
        policy.AllowAnyOrigin();
    });
});

//var _loggrer = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();

//builder.Logging.AddSerilog(_loggrer);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseCors(options => options.WithOrigins("*").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
