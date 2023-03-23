using Microsoft.OpenApi.Models;
using RegistrationBL.Implementation;
using RegistrationBL.Interface;
using RegistrationDA.Implementation;
using RegistrationDA.Interface;
using RegistrationWebAPI.Attributes;
using RegistrationWebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(_ =>
{
    _.OperationFilter<HeaderParameter>();
    _.SwaggerDoc("v1", new OpenApiInfo { Title = "RegistrationWebAPI", Version = "v1" });

    _.AddSecurityDefinition("APIKEY", new OpenApiSecurityScheme
    {
        Name = "APIKEY",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme",
        In = ParameterLocation.Header,
        Description = "ApiKey must appear in header"
    });

    _.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "APIKEY"
                },
                In = ParameterLocation.Header
            },
            new string[]{}
        }
    });
});

builder.Services.AddScoped<IRegistration, RegistrationService>();
builder.Services.AddScoped<IRegistrationBL, RegistrationBLService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(_ => _.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ApiKeyMiddleware>();

app.Run();
