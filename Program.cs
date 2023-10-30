using Microsoft.EntityFrameworkCore;

using DIENAPPRESTAPI.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddDbContext<DIENAPPRESTAPIContext>(
options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DienappDB"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
