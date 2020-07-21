using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using bot.Services.db;
using bot.Services;
using bot.Services.Repositoriy;
using bot.Commands;

namespace bot
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
            var client= new TelegramBotClient(Configuration["Keys:TelegramApiKey"]);
            client.SetWebhookAsync($"{Configuration["Keys:WebHook"]}/update").Wait();
            services.AddEntityFrameworkNpgsql().AddDbContext<Context>(opt=>
                opt.UseNpgsql(Configuration["Keys:ConnectionString"]));
            services.AddTransient<ITranslete, Translete>(x=> new Translete(Configuration["Keys:YandexTransleteApiKey"]));
            services.AddTransient<IRepositoriy, Repositoriy>();
            services.AddTransient<ICommand, CommandHello>();
            services.AddTransient<ICommand,PrintAllLanguesCommand>();
            services.AddTransient<ICommand, TransleteCommand>();
            services.AddTransient<ICommand, SetCommand>();
            services.AddScoped<IBotCore>(x=>new BotCore(client, 
                x.GetServices<ICommand>()));
            services.AddControllers().AddNewtonsoftJson(options => 
                {
                    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
