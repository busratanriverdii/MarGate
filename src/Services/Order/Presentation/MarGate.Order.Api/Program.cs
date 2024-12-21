using MarGate.Core.Jwt.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddJwtAuthentication(x =>
{
    x.SecurityKey = builder.Configuration.GetValue<string>("JwtToken:SecurityKey");
    x.Issuer = builder.Configuration.GetValue<string>("JwtToken:Issuer");
    x.Audience = builder.Configuration.GetValue<string>("JwtToken:Audience");
});

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
