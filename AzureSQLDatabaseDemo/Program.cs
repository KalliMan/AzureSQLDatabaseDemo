using AzureSQLDatabaseDemo.DAL.Context;
using AzureSQLDatabaseDemo.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var cnnString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(cnnString));
builder.Services.AddScoped<IAppDbUnitOfWork, AppDbUnitOfWork>();

//builder.Services.AddScoped<IGenericRepository<Customer>, CustomerRepository>();
//builder.Services.AddScoped<IGenericRepository<Order>, OrderRepository>();
//builder.Services.AddScoped<IGenericRepository<Product>, ProductRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
    }
}
else
{
    // Configure the HTTP request pipeline.

    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
