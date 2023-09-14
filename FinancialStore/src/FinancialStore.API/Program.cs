using FinancialStore.Core;
using FinancialStore.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(
    builder.Services,
    builder.Configuration
);

var app = builder.Build();

Configure(
    app,
    app.Environment,
    builder.Configuration
);

app.Run();

static void ConfigureServices(
    IServiceCollection services,
    IConfiguration configuration
)
{
    services.AddPersistence(configuration);
    services.AddCore();

    services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
    });

    services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Financial Transaction API", Description = "", Version = "v1" });
    });
}

static void Configure(
    IApplicationBuilder app,
    IHostEnvironment env,
    IConfiguration configuration
)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseHttpsRedirection();

    app.UseCors();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Financial Transaction API v1");
    });

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapDefaultControllerRoute();
    });
}