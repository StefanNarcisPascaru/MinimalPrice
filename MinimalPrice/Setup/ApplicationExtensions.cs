//using FastEndpoints;
//using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication.Negotiate;
using MinimalPrice.Endpoints.Prices;
using MinimalPrice.Repositories;

namespace MinimalPrice.Setup
{
    public static class ApplicationExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            
            //builder.Services.AddFastEndpoints(o => o.IncludeAbstractValidators = true);
            builder.Services.AddSwaggerGen();
            //builder.Services.AddSwaggerDoc();
            builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
                .AddNegotiate();

            builder.Services.AddTransient<IPricesRepository, PricesRepository>();

            //builder.Services.AddAuthorization(options =>
            //{
            //    // By default, all incoming requests will be authorized according to the default policy.
            //    options.FallbackPolicy = options.DefaultPolicy;
            //});
        }

        public static void AddMiddleware(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                //app.UseOpenApi();
                //app.UseSwaggerUi3(s => s.ConfigureDefaults());

            }

            //app.UseFastEndpoints(x =>
            //{
            //    //x.Errors.ResponseBuilder = (f,httpContext) =>
            //    //{
            //    //    return null;
            //    //}
            //});

            app.UseHttpsRedirection();
            //app.UseAuthentication();
            //app.UseAuthorization();

            PricesEndpoint.AddEndpoints(app);
        }
    }
}
