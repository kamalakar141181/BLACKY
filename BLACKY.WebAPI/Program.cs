using BLACKY.WebAPI.Business;
using BLACKY.WebAPI.Helpers;
using BLACKY.WebAPI.Models;
using BLACKY.WebAPI.Security;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
//var builder = WebApplication.CreateWebHostBuilder(args).Build().Run();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("SQLAppDbContext")));
builder.Services.AddTransient<IExpenseTypeBL, ExpenseTypeBL>();
builder.Services.AddTransient<IUserBL, UserBL>();
builder.Services.AddTransient<ISqlHelper, SqlHelper>();
builder.Services.AddTransient<IConnection, Connection>();
builder.Logging.AddNLog();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseMiddleware<ApiKeyMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


