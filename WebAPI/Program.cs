using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICarService, CarManager>(); // IoC Container, 1 instance of CarManager for all requests
builder.Services.AddSingleton<ICarDal, EfCarDal>(); // IoC Container, 1 instance of EfCarDal for all requests
builder.Services.AddSingleton<IRentalService, RentalManager>(); // IoC Container, 1 instance of RentalManager for all requests
builder.Services.AddSingleton<IRentalDal, EfRentalDal>(); // IoC Container, 1 instance of EfRentalDal for all requests

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();