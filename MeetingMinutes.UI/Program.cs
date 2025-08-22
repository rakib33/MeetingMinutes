using DoctorBooking.Application.Mappings;
using MeetingMinutes.Application.Interfaces;
using MeetingMinutes.Application.Services;
using MeetingMinutes.Infrastructure.Data;
using MeetingMinutes.Infrastructure.Interfaces;
using MeetingMinutes.Infrastructure.Repositories;
using MeetingMinutes.UI.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();
builder.Services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IMeetingRepository,MeetingRepository>();
builder.Services.AddScoped<IMeetingMasterService, MeetingMasterService>();
builder.Services.AddScoped<IMeetingDetailsService, MeetingDetailsService>();
builder.Services.AddScoped<IMeetingDetailsRepository, MeetingDetailsRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Run Stored Procedure creation here before app starts handling requests
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DbInitializer.Initialize(db);
}
// Add global exception handling middleware
app.UseMiddleware<ExceptionMiddleware>();

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
