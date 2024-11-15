using Microsoft.EntityFrameworkCore;
using Smyrna_Prototype.Models;
using Microsoft.AspNetCore.Identity;
using System;
using Smyrna_Prototype.Services;
using Smyrna_Prototype;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Db service
builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Produce and Customer Interface and Repository implementation
builder.Services.AddScoped<IProductRepository, ProduceRepository>();
builder.Services.AddScoped<ICustomerReviewRepository, CustomerReviewRepository>();

// Email Sender
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration.GetSection("AuthMessageSenderOptions"));

// Configure Identity
builder.Services.AddDefaultIdentity<IdentityUser>(config =>
{
    // config.SignIn.RequireConfirmedEmail = false;
    config.Tokens.ProviderMap.Add("CustomEmailConfirmation",
        new TokenProviderDescriptor(
            typeof(CustomEmailConfirmationTokenProvider<IdentityUser>)));
    config.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
}).AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<CustomEmailConfirmationTokenProvider<IdentityUser>>();

// Cookie policy
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
       o.TokenLifespan = TimeSpan.FromHours(3));

builder.Services.AddSession();

builder.Services.AddRazorPages();

builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.AccessDeniedPath = "/Stop/Index";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapRazorPages();
app.UseCookiePolicy();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
