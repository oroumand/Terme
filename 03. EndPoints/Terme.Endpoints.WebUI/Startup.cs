using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Terme.Core.ApplicationServices.Categories.Commands;
using Terme.Core.ApplicationServices.Categories.Queries;
using Terme.Core.ApplicationServices.Masters.Commands;
using Terme.Core.ApplicationServices.Masters.Queries;
using Terme.Core.ApplicationServices.Orders.Commands;
using Terme.Core.ApplicationServices.Orders.Queries;
using Terme.Core.ApplicationServices.Payments;
using Terme.Core.Domain.Categories.Commands;
using Terme.Core.Domain.Categories.Entities;
using Terme.Core.Domain.Categories.Queries;
using Terme.Core.Domain.Categories.Repositories;
using Terme.Core.Domain.Masters.Commands;
using Terme.Core.Domain.Masters.Dtos;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Queries;
using Terme.Core.Domain.Masters.Repositories;
using Terme.Core.Domain.Orders.Commands;
using Terme.Core.Domain.Orders.Entities;
using Terme.Core.Domain.Orders.Queries;
using Terme.Core.Domain.Orders.Repositories;
using Terme.Core.Domain.Payments;
using Terme.Core.Resources.Resources;
using Terme.Endpoints.WebUI.Models.Carts;
using Terme.Framework.Commands;
using Terme.Framework.Queries;
using Terme.Framework.Resources;
using Terme.Infrastructures.Data.SqlServer;
using Terme.Infrastructures.Data.SqlServer.Categories.Repositories;
using Terme.Infrastructures.Data.SqlServer.Masters.Repositories;
using Terme.Infrastructures.Data.SqlServer.Orders.Repositories;

namespace Terme.Endpoints.WebUI
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
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddControllersWithViews()
                 .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddRazorRuntimeCompilation()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(SharedResource));
                });

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;

                    options.ClientId = "mvc";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.SaveTokens = true;

                    options.Scope.Add("api1");
                    options.Scope.Add("offline_access");
                });

            services.AddMemoryCache();
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => SessionCart.GetCart(sp));
            services.AddTransient<CommandDispatcher>();
            services.AddTransient<QueryDispatcher>();

            services.AddDbContextPool<TermeDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("TermeCnn")));
            services.AddTransient<IResourceManager, ResourceManager<SharedResource>>();


            services.AddTransient<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddTransient<ICategoryQueryRepository, CategoryQueryRepository>();
            services.AddTransient<CommandHandler<AddCategoryCommand>, AddCategoryCommandHandler>();
            services.AddTransient<IQueryHandler<ParentCategoryQuery, List<Category>>, ParentCategoryQueryHandler>();
            services.AddTransient<IQueryHandler<AllCategoryQuery, List<Category>>, AllCategoryQueryHandler>();


            services.AddTransient<IMasterCommandRepository, MasterCommandRepository>();
            services.AddTransient<IMasterQueryRepository, MasterQueryRepository>();
            services.AddTransient<CommandHandler<AddMasterCommand>, AddMasterCommandHandler>();
            services.AddTransient<IQueryHandler<AllMasterQuery, List<DtoMasterBrief>>, AllMasterQueryHandler>();




            services.AddTransient<IMasterProductCommandRepository, MasterProductCommandRepository>();
            services.AddTransient<IMasterProductQueryRepository, MasterProductQueryRepository>();
            services.AddTransient<CommandHandler<AddMasterProductCommand>, AddMasterProductCommandHandler>();
            services.AddTransient<IQueryHandler<AllMasterProductQuery, List<DtoProductBrief>>, AllMasterProductQueryHandler>();

            services.AddTransient<IQueryHandler<MasterDetailsQuery, DtoMasterDetails>,MasterDetailsQueryHandler>();
            services.AddTransient<IQueryHandler<ProductsAdvanacedQuery, DtoProductsAdvanacedQuery>, ProductsAdvanacedQueryHandler>();
            services.AddTransient<IQueryHandler<ProductDetailsQuery, DtoProductDetails>, ProductDetailsQueryHandler>();
            services.AddTransient<IQueryHandler<ProductByIdQuery, MasterProduct>, ProductByIdQueryHandler>();

            services.AddTransient<IOrderCommandRepository, OrderCommandRepository>();
            services.AddTransient<IOrderQueryRepository, OrderQueryRepository>();
            services.AddTransient<CommandHandler<CheckOutCommand>, CheckOutCommandHandler>();
            services.AddTransient<IQueryHandler<OrderByIdQuery, Order>, OrderByIdQueryHandler>();
            services.AddTransient<PaymentService, PayIrPaymentService>();
            services.AddTransient<CommandHandler<SetTransactionCommand>, SetTransactionCommandHandler>();
            services.AddTransient<CommandHandler<SetPaymentDoneCommand>, SetPaymentDoneCommandHandler>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
