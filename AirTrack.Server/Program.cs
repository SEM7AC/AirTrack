using AirTrack.Server.Components;
using AirTrack.Data;
using Microsoft.EntityFrameworkCore;
using AirTrack.Server.Data;

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

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
                {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
            }
        }
    }
