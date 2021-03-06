using System.ComponentModel;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Quartz;
using Quartz.Impl;
using Serilog;
using Xdl.Internship.Core.RabbitMQ;
using Xdl.Internship.Scheduler.Core.Jobs;
using Xdl.Internship.Scheduler.Handlers.CheckExpiredOffers;
using Xdl.Internship.Scheduler.Handlers.CheckExpiredOffersFromController;
using Xdl.Internship.Scheduler.Jobs.CheckExpiredOffers;

namespace Xdl.Internship.Scheduler.ServiceHost
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

            services.AddMediatR(typeof(Startup));

            services.AddMediatR(typeof(CheckExpiredOffersRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CheckExpiredOffersHandler).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(CheckExpiredOffersFromControllerRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CheckExpiredOffersFromControllerHandler).GetTypeInfo().Assembly);

            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSingleton<IHostedService, JobService>();

            services.AddTransient<CheckExpiredOffersWorker>();
            services.AddTransient<IJobSetup, CheckExpiredOffersJobSetup>();

            services.AddOptions();

            services.Configure<RabbitMqConfiguration>(Configuration.GetSection("RabbitMq"));
            services.AddSingleton<IRabbitMqPublisher, MessagePublisher>();
            services.AddSingleton<IMessageSender<MessageDTO>, MessageSender>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "Xdl.Internship.Scheduler.ServiceHost", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Xdl.Internship.Scheduler.ServiceHost v1"));
            }

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}