using ChatServiceMVC.Hubs;
using ChatServiceMVC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ChatServiceMVC.Models;
namespace ChatServiceMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("ChatServiceMVCContextConnection") ?? throw new InvalidOperationException("Connection string 'ChatServiceMVCContextConnection' not found.");

            builder.Services.AddDbContext<ChatServiceMVCContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ChatServiceMVCContext>();

            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ChatServiceMVCContext>();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSignalR();

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

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapHub<ChatHub>("/chatHub");

            app.Run();
        }
    }
}
