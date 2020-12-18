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
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
            services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.AddMemoryCache();
            

            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // User settings
                options.User.RequireUniqueEmail = true;
            });
            services.AddSingleton(AutoMapperConfig.RegisterMappings().CreateMapper());
            /*services.AddAuthentication()
                .AddFacebook(facebookOpts =>
                {
                    facebookOpts.AppId = Configuration["Authentication:Facebook:AppId"];
                    facebookOpts.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                })
                .AddGoogle(googleOpts =>
                {
                    googleOpts.ClientId = Configuration["Authentication:Google:ClientId"];
                    googleOpts.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                });*/

            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

            services.AddTransient<DbInitializer>();

            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>();

            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));

            services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));

            //service
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IAnnouncementService, AnnouncementService>();

            services.AddTransient<IAuthorizationHandler, BaseResourceAuthorizationHandler>();
            //services.AddDefaultIdentity<CusUserRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddEntityFrameworkStores<AppDbContext>();


            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile));
            //services.AddSingleton(Mapper.Configuration);

            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));
            services.AddControllersWithViews();
            
            services.AddTransient<IProductCategoryRepository,ProductCategoryRepository>();
            //services.AddTransient<IFunctionService, FunctionService>();
            //services.AddTransient<IProductCategoryService,ProductCategoryService>();
            //services.AddSingleton(AutoMapperConfig.RegisterMappings().CreateMapper());
            services.AddRazorPages();
            //services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            //services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));
            //services.AddTransient<IAnnouncementService, AnnouncementService>();




            //services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            //services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

            //services.AddTransient<DbInitializer>();

            //services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>();

            //services.AddTransient<IRoleService, RoleService>();
            //services.AddTransient<IAuthorizationHandler, BaseResourceAuthorizationHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/tedu-{Date}.txt");
            if (env.EnvironmentName == Environments.Development)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            //app.UseMinResponse();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseSession();

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            /*app.UseEndpoints(routes =>
            {
                routes.MapHub<TeduHub>("/teduHub");

                routes.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");

                routes.MapControllerRoute(
                    "areaRoute",
                    "{area:exists}/{controller=Login}/{action=Index}/{id?}");
            });*/
        }
    }
}
