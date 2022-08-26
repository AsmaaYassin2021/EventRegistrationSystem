using EventReg.API.Authentication;
using EventReg.API.Wrappers;
using EventReg.Busniess.Service;
using EventReg.Common;
using EventReg.Data.Model;
using EventReg.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System;


namespace EventReg.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureWrapper(this IServiceCollection services)
        {

            services.AddScoped<IEventRegiseterService, EventRegiseterService>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IRegistrationRepository, RegistrationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
        public static void ConfigureInvalidModel(this IServiceCollection services)
        {

            services.Configure<ApiBehaviorOptions>(o =>
            {
                o.InvalidModelStateResponseFactory = actionContext =>
                {
                    InvalidModelBadRequest customBadRequest = new InvalidModelBadRequest(actionContext.ModelState);

                    Log.Error("Invalid model for " + string.Join(", ", customBadRequest.errors));
                    return new BadRequestObjectResult(customBadRequest);
                };

            });
        }
        public static void ConfigureSwaggerAPI(this IServiceCollection services)
        {
            // Register the Swagger generator, defining one or more Swagger documents  
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Event System  API",
                    Version = "v2",
                    Description = "Event System  API",
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement { {   new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
                },
      new string[] { }
                    }
  });
            });

        }
        public static void ConfigureJWToken(this IServiceCollection services)
        {
            var key = "This is my token admin";
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key))
                };
            });

            services.AddSingleton<ITokenAuth>(new Auth(key));
        }
    }
}
