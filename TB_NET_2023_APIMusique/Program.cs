using Microsoft.Data.SqlClient;
using System.Data.Common;
using TB_NET_2023_APIMusique.BLL.Interfaces;
using TB_NET_2023_APIMusique.BLL.Services;
using TB_NET_2023_APIMusique.DAL.Interfaces;
using TB_NET_2023_APIMusique.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//DbConnection
builder.Services.AddTransient<DbConnection>(service =>
{
    string connectionString = builder.Configuration.GetConnectionString("Default");
    return new SqlConnection(connectionString);
});

//Services
builder.Services.AddScoped<IArtistService, ArtistService>();

//Repositories
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
