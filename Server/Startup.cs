using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Server.Controllers.Database;
using Server.Models;

namespace Server
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
            string connectionString = BuildConnectionString(Configuration["Database:Host"],
                                                            Configuration["Database:User"],
                                                            Configuration["Database:Password"],
                                                            Configuration["Database:Schema"]);

            services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(opt => opt.UseNpgsql(connectionString));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            Seeder.Seed(app.ApplicationServices);
        }

        private string BuildConnectionString(string host, string username, string password, string schema)
        {
            return $"Host={host};Username={username};Password={password};Database={schema}";
        }
    }
}
