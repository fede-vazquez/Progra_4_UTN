using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Diagnostics;

namespace Auth.Utils
{
    public class AuthOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var Attributes = context.ApiDescription.CustomAttributes();
            var IsAuthorize = Attributes.Any(attr => attr.GetType() == typeof(AuthorizeAttribute));
            var IsAllowAnonymous = Attributes.Any(attr => attr.GetType() == typeof(AllowAnonymousAttribute));

            if (!IsAuthorize || IsAllowAnonymous) return;

            var reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Token",
            };

            var securityScheme = new OpenApiSecurityScheme
            {
                Reference = reference,
            };

            var requeriment = new OpenApiSecurityRequirement()
            {
                [securityScheme] = []
            };

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                requeriment,
            };
        }
    }
}
