using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore;
using RecruitmentSITHEC;
using RecruitmentSITHEC.Extensions;
using RecruitmentSITHEC.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// CORS
builder.Services.ConfigureCors();

// DEPENDENCIAS
builder.Services.AddAplicationServices();

// Enable HTTP Context Accessor
builder.Services.AddHttpContextAccessor();

// Rate Limit
builder.Services.ConfigureRateLimiting();


builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Model State validation
builder.Services.AddValidationErrors();


// DB Context Configuration
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable middleware to protect DDOS attacks
app.UseIpRateLimiting();

// Global exception handler
app.UseMiddleware<ExceptionMiddleware>();

// Personalize error page response
app.UseStatusCodePagesWithReExecute("/errors/{0}");



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
