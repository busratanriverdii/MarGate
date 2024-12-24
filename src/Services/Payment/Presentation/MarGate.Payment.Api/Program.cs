using MarGate.Core.Jwt.Extension;
using MarGate.Core.UnitOfWork.Extension;
using MarGate.Payment.Persistence.Contexts;
using MarGate.Core.CQRS.Extension;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Payment Api", Version = "v1" });

    // Add Bearer Token authorization support in Swagger UI
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter your Bearer token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddJwtAuthentication(x =>
{
    x.SecurityKey = builder.Configuration.GetValue<string>("JwtToken:SecurityKey");
    x.Issuer = builder.Configuration.GetValue<string>("JwtToken:Issuer");
    x.Audience = builder.Configuration.GetValue<string>("JwtToken:Audience");
});

builder.Services.AddUnitOfWork<PaymentDbContext>(x =>
{
    x.WriteConnectionString = builder.Configuration.GetConnectionString("MsSql");
});

builder.Services.AddCQRS();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseJwtAuthentication();

app.MapControllers();

app.Run();
