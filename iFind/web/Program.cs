using web.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//alternativa temu kar je on naredil v startup.cs, ki tukaj ne obstaja več
builder.Services.AddDbContext<iFindContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("PovezavaDoiFindBaze") + //iz jsona
        ";TrustServerCertificate=True")); 


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();







app.Run();
