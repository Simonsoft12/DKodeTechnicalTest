using MyAPI.Repositories.Inventory;
using MyAPI.Repositories.Price;
using MyAPI.Repositories.Product;
using MyAPI.Services.InventoryService;
using MyAPI.Services.PriceService;
using MyAPI.Services.ProductService;
using MyAPI;
using System.Data.SqlClient;
using System.Data;
using MyAPI.Services.FileDownloadService;
using MyAPI.Services.SupplierService;
using MyAPI.Repositories.Supplier;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registering the database connection in DI
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));

// Registering repositories with the appropriate connectionString
builder.Services.AddScoped<IProductRepository>(sp => new ProductRepository(connectionString));
builder.Services.AddScoped<IInventoryRepository>(sp => new InventoryRepository(connectionString));
builder.Services.AddScoped<IPriceRepository>(sp => new PriceRepository(connectionString));
builder.Services.AddScoped<ISupplierRepository>(sp => new SupplierRepository(connectionString));

// Registering services
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPriceService, PriceService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IFileDownloadService, FileDownloadService>();

builder.Services.AddHttpClient();

// Registering AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

// Adding controllers
builder.Services.AddControllers();

// Registering Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuring the HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  // Enabling HTTPS
app.UseAuthorization();  // Enabling authorization

app.MapControllers();  // Mapping controllers to routing

app.Run();
