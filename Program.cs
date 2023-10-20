using Microsoft.EntityFrameworkCore;

using DIENAPPRESTAPI.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<SeekerContext>(opt =>
    opt.UseInMemoryDatabase("SeekerItem"));

builder.Services.AddDbContext<ProviderContext>(opt =>
    opt.UseInMemoryDatabase("ProviderItem"));


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