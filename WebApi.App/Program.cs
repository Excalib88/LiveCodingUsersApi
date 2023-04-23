using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApi.App.Data;
using WebApi.App.Logic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("Db")));
builder.Services.AddHttpClient("UserService", opt => 
    opt.BaseAddress = new Uri(builder.Configuration["Users:BaseUrl"]!));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Users API", Version = "v1" });
});
builder.Services.AddScoped<IUserParser, UserParser>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuditService, AuditService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "Users API v1");
    x.RoutePrefix = "swagger";
});
app.MapControllers();

app.Run();