using Backend.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
// Config DB
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("local");
    options.UseSqlServer(connectionString);
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(Options => {
    Options
    .AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
