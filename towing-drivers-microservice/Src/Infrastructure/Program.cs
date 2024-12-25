using Application.Core;
using DotNetEnv;
using MassTransit;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tow.Domain;
using Tow.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
Env.Load();

builder.Services.AddSingleton<MongoTowRepository>();
builder.Services.AddSingleton<MongoEventStore>();
builder.Services.AddScoped<IdService<string>, GuidGenerator>();
builder.Services.AddScoped<IMessageBrokerService, RabbitMQService>();
builder.Services.AddScoped<IEventStore, MongoEventStore>();
builder.Services.AddScoped<ITowRepository, MongoTowRepository>();
builder.Services.AddControllers(options => {
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Tow API", Version = "v1" });
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = Environment.GetEnvironmentVariable("API_GATEWAY_URL")!;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")!))
        };
    });

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(new Uri(Environment.GetEnvironmentVariable("RABBITMQ_URI")!), h =>
        {
            h.Username(Environment.GetEnvironmentVariable("RABBITMQ_USERNAME")!);
            h.Password(Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD")!);
        });

        configurator.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
        configurator.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseSwagger(c =>
{
    c.SerializeAsV2 = true;
});

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tow v1");
    c.RoutePrefix = string.Empty;
});

app.MapGet("api/towdriver/health", () => Results.Ok("ok"));

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
