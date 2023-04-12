using InvoiceTracker.Application.Services;
using InvoiceTracker.Core.Models;
using InvoiceTracker.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string constr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<InvoiceTrackerDbContext>(options =>
{
    options.UseSqlServer(constr);
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.SignIn.RequireConfirmedEmail = false;
    option.User.RequireUniqueEmail = true;
    option.Password.RequiredLength = 8;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<InvoiceTrackerDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<ApplicationUserService>();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<ClientService>();

var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
