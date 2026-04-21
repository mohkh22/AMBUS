using AMBUS.Application;
using AMBUS.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddServicesFromInfrastructure(builder.Configuration);
builder.Services.AddServicesFromApplication(); 

var app = builder.Build();
app.UseRouting();
app.UseStaticFiles(); 

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); 
app.Run();
