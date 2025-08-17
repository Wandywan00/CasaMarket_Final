using CasaMarket.Application.Services;
using CasaMarket.Infrastructure.Data;
using CasaMarket.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- Services and Repositories ---
builder.Services.AddDbContext<CasaMarketApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CasaMarketConnection")));

// --- Dependency Injection ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<UnitOfWork, UnitOfWorkImpl>();

builder.Services.AddScoped<DetailOrderRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<ReviewRepository>();
builder.Services.AddScoped<MessageRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ImagesProductRepository>();

builder.Services.AddScoped<DetailOrderService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<MessageService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ImagesProductService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b =>
        b.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());
});

var app = builder.Build();

// --- Pipeline ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
