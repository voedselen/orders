using BusinessLayer;
using BusinessLayer.DB_Interfaces;
using BusinessLayer.Logic;
using DBLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<IDB_AccessOrder, DB_AccessOrder>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IOrderBusinessLogic>(new AccessOrders(new DB_AccessOrder()));
builder.Services.AddSingleton<IPaypalServices>(new PaypalService(new DB_PaypalService()));
var app = builder.Build();

// Enable CORS
app.UseCors(policy =>
{
    policy.WithOrigins("http://localhost:3000")
          .AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials();
});

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
