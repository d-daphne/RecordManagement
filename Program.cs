using BloodPressureMeasurementApplication.Entities;
using BloodPressureMeasurementApplication.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register IBloodPressureManagementService and BloodPressureManagementService
builder.Services.AddScoped<IBloodPressureMeasurementService, BloodPressureMeasurementService>();

// Set up database connection
var connectionString = builder.Configuration.GetConnectionString("BloodPressureDb");
builder.Services.AddDbContext<BloodPressureDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
