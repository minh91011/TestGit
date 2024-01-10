using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyWebAPIApp.Data;
using MyWebAPIApp.InMemory;
using MyWebAPIApp.Interface;
using MyWebAPIApp.Models;
using MyWebAPIApp.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
});

//addScope
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<ICategoryRepository, CategoryRepositoryInMemory>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddAuthentication();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:3000") // Điều chỉnh domain của trang web React của bạn
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});


//secretKey
builder.Services.Configure<Key>(builder.Configuration.GetSection("AppSettings"));

//secretKey
var secretKey = builder.Configuration["AppSettings:SecretKey"];
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(op =>
{
    op.TokenValidationParameters = new TokenValidationParameters
    {
        //auto create token
        ValidateIssuer = false,
        ValidateAudience = false,

        //sign in token
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

        ClockSkew = TimeSpan.Zero
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors(policy => policy.AllowAnyHeader()
//                           .AllowAnyMethod()
//                           .SetIsOriginAllowed(origin => true)
//                           .AllowCredentials());

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
