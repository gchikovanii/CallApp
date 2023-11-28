using CallApp.API.Infrastructure.Extensions;
using CallApp.Persistence.DataContext;
using CallApp.Persistence.Store;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger();
builder.Services.AddJwt(builder.Configuration);
#region Sql Connection
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                                                  options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnectionString))), ServiceLifetime.Scoped);
#endregion
#region AddFluentValidation
builder.Services.AddFluentValidation();
#endregion
#region Serilog
builder.Host.UseSerilog((context, conf) =>
conf.ReadFrom.Configuration(context.Configuration));
#endregion
#region MediatR
builder.Services.AddMediatR(i => i.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseGlobalExceptionHandler();
app.UseAuthorization();
app.UseAuthentication();
app.UseCulture();
app.MapControllers();
#region AppRun
try
{
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal("Host Crashed! Exception: " + ex);
}
#endregion

