using AspNetCore.Unobtrusive.Ajax;
using Bot.AdminPanel.Identity;
using Bot.AdminPanel.Identity.Types;
using Bot.AdminPanel.Mail;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using tools.niap.ru.Data;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseMySql(
    builder.Configuration.GetConnectionString("IdentityConnection"),
    ServerVersion.Parse("7.4.3")),
    ServiceLifetime.Scoped);

builder.Services.AddDbContext<MyKeysContext>(options => options.UseMySql(
    builder.Configuration.GetConnectionString("MyKeysConnection"),
    ServerVersion.Parse("7.4.3")),
    ServiceLifetime.Scoped);

builder.Services.AddDbContext<DataDBContext>(options => options.UseMySql(
    builder.Configuration.GetConnectionString("DataConnection"),
    ServerVersion.Parse("7.4.3")),
    ServiceLifetime.Scoped);

builder.Services.AddDataProtection().PersistKeysToDbContext<MyKeysContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationIdentityDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<MailServiceConfig>(builder.Configuration.GetSection("MailServer"));
builder.Services.AddScoped<MailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseUnobtrusiveAjax();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();