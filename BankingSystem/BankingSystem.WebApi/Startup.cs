using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Application.BankAccounts.Queries;
using BankingSystem.Application.Infrastructure;
using BankingSystem.Application.Interfaces;
using BankingSystem.Common;
using BankingSystem.Infrastructure;
using BankingSystem.Persistence;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using NLog.Web;
using BankingSystem.WebApi.Middlewares;
using BankingSystem.Application.BankAccounts.Commands;

namespace BankingSystem.WebApi
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
            services.AddMvc();
            services.AddDbContext<BankingSystemDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //MediatR Pipeline
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IRequestPreProcessor<>), typeof(RequestLogger<>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(InquiryByAccountNumberQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DepositCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(WithdrawCommandHandler).GetTypeInfo().Assembly);

            //Infrastructure
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IDateTime, MachineDateTime>();

            //validations
            //services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCustomerCommandValidator>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app
            , IHostingEnvironment env
            , ILoggerFactory loggerFactory
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            env.ConfigureNLog("nlog.config");

            //add NLog to ASP.NET Core
            loggerFactory.AddNLog();

            //add NLog.Web
#pragma warning disable CS0618 // Type or member is obsolete
            app.AddNLogWeb();
#pragma warning restore CS0618 // Type or member is obsolete

            app.UseStaticFiles();

            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
                settings.DocumentPath = "/api/specification.json";
            });

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseMvc();
        }
    }
}
