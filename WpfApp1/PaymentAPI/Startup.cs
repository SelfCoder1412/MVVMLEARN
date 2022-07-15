using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI
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
            services.AddControllersWithViews();
            services.AddControllers();
            //https://faun.pub/restful-web-api-using-c-net-core-3-1-with-sqlite-f020d76c9b89
            //https://www.youtube.com/watch?v=S5dzfuh3t8U
            //PM > install - package Microsoft.EntityFrameworkCore.Tools  5.0.0.0
            //PM > install - package Microsoft.EntityFrameworkCore.Design
            //PM > install - package Microsoft.EntityFrameworkCore.Sqlite
            //PM > Add-Migration PaymentDetail
            //Update-Database
            //Add - Migration CreateIdentitySchema - Context AuthDbContext
            //    It didn't work without context parameter. This created 2 migrations which I ran separately:

            //Update - Database 20201217102436_InitialCreate - Context AuthDbContext
            //    and than

            //Update - Database 20201218083037_CreateIdentitySchema - Context AuthDbContext
            services.AddDbContext<PaymentDetailContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PaymentDetailContext>();
                context.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Payment}/{action=Index}/{id?}");
            });
        }
    }
}
