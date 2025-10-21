using Microsoft.EntityFrameworkCore;
using ReactAPICURDBackend.Data;

var builder = WebApplication.CreateBuilder(args);

//Add services
builder.Services.AddControllers();

// Database Connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Fix CORS for React frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // React runs here
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();
//app.UseCors(x => x
//.AllowAnyOrigin()
//.AllowAnyMethod()
//.AllowAnyHeader());

// Middleware order is very important
app.UseHttpsRedirection();
app.UseCors("AllowReactApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
