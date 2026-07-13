using AirTrack.Server.Components;
using AirTrack.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace AirTrack.Server
    {
    public class Program
        {
        public static void Main(string[] args)
            {
            var builder = WebApplication.CreateBuilder(args);

            // Register AirTrackContext here
            builder.Services.AddDbContext<AirTrackContext>(options =>
            options.UseSqlite("Data Source=airtrack.db"));

            //Register DbHelper
            builder.Services.AddScoped<DbHelper>();


            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // CREATE TABLES  
            using (var scope = app.Services.CreateScope())
                {
                var db = scope.ServiceProvider.GetRequiredService<AirTrackContext>();
                db.Database.EnsureCreated();
                }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
                {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                }

            app.UseHttpsRedirection();
            app.UseMiddleware<SanitizeInputMiddleware>();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
            }
        }
    }
