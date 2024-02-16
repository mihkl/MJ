using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MJ.Soft.Data;

var b = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = b.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
b.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectionString));
b.Services.AddDatabaseDeveloperPageExceptionFilter();
b.Services.AddDefaultIdentity<IdentityUser>(o => o.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
b.Services.AddControllersWithViews();

var app = b.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.UseMigrationsEndPoint();
else {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
