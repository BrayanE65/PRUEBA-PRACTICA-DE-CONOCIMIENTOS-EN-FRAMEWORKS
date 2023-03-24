using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using PRUEBA_PRACTICA_DE_CONOCIMIENTOS_EN_FRAMEWORKS.Areas.Identity;
using PRUEBA_PRACTICA_DE_CONOCIMIENTOS_EN_FRAMEWORKS.Data;
using PRUEBA_PRACTICA_DE_CONOCIMIENTOS_EN_FRAMEWORKS.Reactive;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<EstudianteService>();
builder.Services.AddSignalR();
// builder.Services.AddHostedService<EstudianteHostedService>();
builder.Services.AddScoped(sp =>
{
     var hubConnection = new HubConnectionBuilder()
         .WithUrl("https://localhost:5001/EstudianteHub")
         .Build();

     return hubConnection; 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// app.UseEndpoints(endpoints =>
//  {
//    endpoints.MapHub<EstudianteHub>("/Estudiante");
//  }
// );

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
