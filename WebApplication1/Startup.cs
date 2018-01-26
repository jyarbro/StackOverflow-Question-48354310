using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1 {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {
			// This line is the magic that loads the values from appsettings.json into a ViewConfiguration object.
			services.Configure<ViewConfiguration>(Configuration.GetSection("ViewConfiguration"));

			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
			}
			else {
				app.UseExceptionHandler("/Error");
			}

			app.UseStaticFiles();

			app.UseMvc();
		}
	}
}
