﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Br.Com.FactIO.Api.Options
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));            
            }

            var scheme = GetJwtSecurityScheme();
            options.AddSecurityDefinition(scheme.Reference.Id, scheme);
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { scheme, new string[0] }
            });
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            return new OpenApiInfo
            {
                Title = "FactIO Api",
                Version = description.ApiVersion.ToString()
            };
        }

        private OpenApiSecurityScheme GetJwtSecurityScheme()
        {
            return new OpenApiSecurityScheme
            {
                Name = "JWT Authentication",
                Description = "Provide a JWT Bearer",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
        }
    }
}
