using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DAL.Interfaces;
using dal = DAL.Models;
using DAL.Repositories;
using Model_BLL.Services.Interfaces;
using Model_BLL.Services;
using Model_BLL.Models;
using TtrpgApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using TtrpgApi.Services.Interfaces;

namespace TtrpgApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors();

            // Add services to the container.
            #region Repositories
            services.AddScoped<IQuesterRepository<dal.Quester>, QuesterRepository>();
            #endregion

            #region Services
            services.AddScoped<IQuesterService, QuesterService>();
            #endregion


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            #region Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "swagger.xml");
                c.IncludeXmlComments(filePath);
                c.DescribeAllParametersInCamelCase();
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "QuestingBoard",
                    Description = "TTRPG Makerhub Project",
                });
            });
            #endregion

            #region JWToken
            IConfigurationSection mySecret = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(mySecret);

            AppSettings appSettings = mySecret.Get<AppSettings>();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                        new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = "http://localhost53377",
                        ValidateLifetime = true,
                        ValidateAudience = true,
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("Quester", policy => policy.RequireRole("Quester", "Admin"));
            });

            services.AddScoped<ITokenService, TokenService>();

        }
        #endregion

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.DisplayOperationId();
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TTRPG API");
            });
        }
    }
}