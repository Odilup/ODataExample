using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.OData;
using ODataServiceAdventureWorks.Models;

namespace ODataServiceAdventureWorks
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AdventureWorksContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AdventureWorksDB")));

            services.AddOData();
            services.AddODataQueryFilter();

            services.AddMvc(options => { options.EnableEndpointRouting = false; })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routebuilder =>
            {
                //routebuilder.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
                routebuilder.MapODataServiceRoute("ODataRoute", "odata",
                    EdmModelBuilder.GetEdmModel(app.ApplicationServices));
            });
        }
    }
}
