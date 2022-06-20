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
using Microsoft.Extensions.Configuration;
using TtrpgApi.Services.Interfaces;
using TtrpgApi.Domain;
using TtrpgApi.Hubs;

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
            services.AddSignalR();

            services.AddCors(o => o.AddPolicy("chatPolicy", builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                ));

            // Add services to the container.
            #region Repositories
            services.AddScoped<IQuesterRepository<dal.Quester>, QuesterRepository>();
            services.AddScoped<IFavoritesRepository<dal.Favorite>, FavoritesRepository>();
            services.AddScoped<IGamesRepository<dal.Game>, GamesRepository>();
            services.AddScoped<IGenresRepository<dal.Genre>, GenresRepository>();
            #endregion

            #region Services
            services.AddScoped<IQuesterService, QuesterService>();
            services.AddScoped<IFavoritesService, FavoritesService>();
            services.AddScoped<IGamesService, GamesService>();
            services.AddScoped<IGenresService, GenresService>();
            services.AddScoped<ChatHub>();
            services.AddSingleton<DataContext>();
            #endregion

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            #region Swagger

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

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("Quester", policy => policy.RequireRole("Quester", "Admin"));
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = "http://localhost:53377",
                    ValidateAudience = false,
                    ValidateLifetime = true
                };
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

            app.UseCors("chatPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chat");
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