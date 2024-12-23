using MarGate.Core.Jwt.Extension;
using MarGate.Core.UnitOfWork.Extension;
using MarGate.Core.CQRS.Extension;
using Microsoft.OpenApi.Models;
using MarGate.Identity.Persistence.Contexts;
using MarGate.Core.MessageBus.Extension;
using MarGate.Order.Application.Extensions;
using MarGate.Core.Logging.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Order Api", Version = "v1" });

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
            Array.Empty<string>()
        }
    });
});

builder.Services.AddJwtAuthentication(x =>
{
    x.SecurityKey = builder.Configuration.GetValue<string>("JwtToken:SecurityKey");
    x.Issuer = builder.Configuration.GetValue<string>("JwtToken:Issuer");
    x.Audience = builder.Configuration.GetValue<string>("JwtToken:Audience");
});

builder.Services.AddUnitOfWork<OrderDbContext>(x =>
{
    x.WriteConnectionString = builder.Configuration.GetConnectionString("MsSql");
});

builder.Services.AddMessageBus(builder.Configuration);

builder.Services.AddCQRS();

builder.Services.AddApplicationServices();

builder.Services.AddHttpClient("Identity", x =>
{
    x.BaseAddress = new Uri(builder.Configuration.GetValue<string>("RemoteCalls:Identity")!);
});

builder.Services.AddLog(builder.Logging);

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
