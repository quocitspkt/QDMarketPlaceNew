using AutoMapper;
using MarketPlace.Application.AutoMapper;
using MarketPlace.Application.Implementation;
using MarketPlace.Application.Interfaces;
using MarketPlace.Authorization;
using MarketPlace.Data;
using MarketPlace.Data.EF;
using MarketPlace.Data.EF.Repositories;
using MarketPlace.Data.Entities;
using MarketPlace.Data.IRepositories;
using MarketPlace.Helpers;
using MarketPlace.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlace
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    o=>o.MigrationsAssembly("MarketPlace.Data.EF")));

            //services.AddDefaultIdentity<CusUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddEntityFrameworkStores<AppDbContext>();
            services.AddIdentity<CusUser, CusUserRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
            //services.AddDefaultIdentity<CusUserRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped<UserManager<CusUser>, UserManager<CusUser>>();
            services.AddScoped<RoleManager<CusUserRole>, RoleManager<CusUserRole>>();

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile));
            //services.AddSingleton(Mapper.Configuration);

            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));
            services.AddControllersWithViews();
            services.AddTransient<DbInitializer>();
            services.AddTransient<IProductCategoryRepository,ProductCategoryRepository>();
            services.AddTransient<IProductCategoryService,ProductCategoryService>();
            services.AddSingleton(AutoMapperConfig.RegisterMappings().CreateMapper());
            services.AddRazorPages();
            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));
            services.AddScoped<IUserClaimsPrincipalFactory<CusUser>, CustomClaimsPrincipalFactory>();
            services.AddTransient<IAuthorizationHandler, BaseResourceAuthorizationHandler>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,DbInitializer dbInitializer)
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
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                   name: "areaEndpoint",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
            dbInitializer.Seed().Wait();
        }
    }
}
