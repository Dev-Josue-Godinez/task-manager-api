using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Dtos;
using Task_Manager_API.OAuth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetSection("Environment").GetSection("Development")["ConnectionStrings"],
        b => b.MigrationsAssembly("Models")
    );
});

//builder.Services.AddScoped<DBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapPost("/auth", [AllowAnonymous] (HttpContext context, UserCredential userCrendential, DBContext dBContext) => Authorization.OAuthGenerator(context, userCrendential, dBContext, builder));
app.MapRazorPages();

app.Run();
