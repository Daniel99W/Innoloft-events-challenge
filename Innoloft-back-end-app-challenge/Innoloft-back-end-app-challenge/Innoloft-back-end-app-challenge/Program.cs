using EventsAPI.Core.Interfaces;
using EventsAPI.DAL;
using EventsAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.WebHost.ConfigureKestrel(
    options => 
    options.Listen(System.Net.IPAddress.Parse(builder.Configuration["hostIp"]),Convert.ToInt32(builder.Configuration["port"])));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IRepositoryUser, UserRepository>();
builder.Services.AddScoped<IRepositoryEvent, EventRepository>();
builder.Services.AddScoped<IRepositoryEventRegistration, EventRegistrationRepository>();
builder.Services.AddScoped<IRepositoryInvitedUsers, InvitedUsersRepository>();
builder.Services.AddDbContext<EventsDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConn"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlConn")));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
