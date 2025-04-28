using ApiBrnetEstoque.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApiBrnetEstoque.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using ApiBrnetEstoque.Services;


var builder = WebApplication.CreateBuilder(args);

// banco de dados (MySQL)
builder.Services.AddDbContext<BdBrnetEstoqueContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// passwordhasher
builder.Services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();

// controladores 
builder.Services.AddControllers();

// Swagger para testar a API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Lei a seção Jwt do appsettings (Issuer, Audience)
var jwtSection = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSection["Key"]!);

builder.Services
  .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
                                   Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
                                 )
    }
  );

// services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<EquipmentService>();
builder.Services.AddScoped<ChecklistService>();
builder.Services.AddScoped<StockService>();
builder.Services.AddScoped<KmService>();





// roles
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireRole("admin_estoque"));

    options.AddPolicy("TecnicoPolicy", policy =>
        policy.RequireRole("tecnico"));
});



// Configura CORS para permitir requisições do frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

// Middleware do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ativa CORS
app.UseCors("AllowAll");

// Middleware HTTPS
app.UseHttpsRedirection();

// Middleware de autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();


// Mapeia os endpoints dos controladores
app.MapControllers();

app.Run();
