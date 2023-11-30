using Microsoft.OpenApi.Models;
using System.Reflection.Metadata;
using BL;
using DL;

namespace apiPhotographsSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        readonly string AllowSpecificOrigins = "_allowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(AllowSpecificOrigins, builder =>
            //    {
            //        builder.WithOrigins("http://aaa.com", "http://bbb.com");
            //    });
            //});
            services.AddCors();

            services.AddControllers();
            services.AddScoped<IcollectionDL, CollectionDL>();
            services.AddScoped<IcollectionBL, CollectionBL>();

            //srv2\\pupils  //LAPTOP - ODKQSO4A
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BusinessPartners", Version = "v1" });

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",

                });

                var key1 = Configuration.GetSection("AppSettings:Token").Value;

                services.AddAuthorization();
            });
            }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BusinessPartners v1"));
            }


            logger.LogInformation("server is up");
            app.UseErrorMiddleware();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
          

            // It sets the policy to restrict the sources from which certain content can be loaded, such as scripts and images
            //app.Use(async (context, next) =>
            //{
            //    context.Response.Headers.Add(
            //        "Content-Security-Policy",
            //        "default-src 'self';" +
            //        "style-src 'self';" +
            //        "img-src 'self'");
            //    await next();
            //});

            app.UseRouting();
            //app.UseCors(AllowSpecificOrigins);
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
            app.UseAuthentication(); // Add this line before UseAuthorization()

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

