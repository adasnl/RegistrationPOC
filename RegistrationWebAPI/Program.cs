using AutoMapper;
using Microsoft.OpenApi.Models;
using RegistrationBL.Implementation;
using RegistrationBL.Interface;
using RegistrationDA.Entities;
using RegistrationDA.Implementation;
using RegistrationDA.Interface;
using RegistrationWebAPI.Attributes;
using RegistrationWebAPI.Common;
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

builder.Services.AddScoped<IRegistrationDataAccessService, RegistrationService>();
builder.Services.AddScoped<IRegistrationBusinessLayerService, RegistrationBusinessLayerService>();
builder.Services.AddDbContext<RepositoryDBContext>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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

app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();

app.Run();
