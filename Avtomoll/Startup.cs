using Avtomoll.Abstract;
using Avtomoll.DataAccessLayer;
using Avtomoll.Domains;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Avtomoll
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services
               .AddDefaultIdentity<IdentityUser>()
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddTransient<IRepository<Service>, ServiceSqlRepository>();
            services.AddTransient<IRepository<ServiceHistory>, ServiceHistorySqlRepository>();
            services.AddTransient<IRepository<GroupService>, GroupServiceSqlRepository>();
            services.AddTransient<IRepository<Message>, MessageSqlRepository>();
            services.AddTransient<IRepository<CarService>, CarServiceSqlRepository>();
            services.AddTransient<ClientServiceSqlRepository>();
            services.AddTransient<IRepository<FeedBack>, FeedBackSqlRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Carservice",
                    pattern: "manager/carservice/{action}",
                    defaults: new { Controller = "Carservice", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "Reception",
                    pattern: "manager/reception/{action}",
                    defaults: new { Controller = "Reception", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "ServiceManager",
                    pattern: "manager/service/{action}",
                    defaults: new { Controller = "ServiceManager", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "ManagersManager",
                    pattern: "admin/ManagersManager/{action}",
                    defaults: new { Controller = "ManagersManager", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "Service",
                    pattern: "S",
                    defaults: new { Controller = "Service", action = "MakeOrder" });

                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "Admin/Page{page}",
                    defaults: new { Controller = "Admin", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                DataSeeder.Seed(scope.ServiceProvider);
                DataSeeder.SeedRoles(roleManager);
                DataSeeder.SeedUsers(userManager);
            }
        }
    }
}
