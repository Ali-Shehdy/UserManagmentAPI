using Microsoft.EntityFrameworkCore;
using UserManegment;
using UserManegment.Dtos;
using UserManegment.Entities;
using UserManegment.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService,  UserService>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("sayHello", (string title ) => "Hello " + title);

app.MapPost("user/Create", (IUserService userService, UserCreateParams dto) =>
{
UserResponse result = userService.Create(dto);
return Results.Ok(result);
});
app.Run();
