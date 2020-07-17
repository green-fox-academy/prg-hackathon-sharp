using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using programmersGuide.Context;
using programmersGuide.Models.Entities;
using programmersGuide.Services;
using programmersGuide.Services.Interfaces;

namespace programmersGuide
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ApplicationDbContext>(options =>
                                                        options.UseNpgsql("User ID=bufnlhcjhvgdkq;Password=71c9f976ff924f05905447375dcdf2a20813793b5ddb64070a325a56852eac3f;Host=ec2-46-137-79-235.eu-west-1.compute.amazonaws.com;Port=5432;Database=dbp4li6ogof188;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;"));
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication().AddCookie();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IQuizService, QuizService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
