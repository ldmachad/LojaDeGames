using System.Text;
using FluentValidation;
using Machado_Games.Data;
using Machado_Games.Model;
using Machado_Games.Security;
using Machado_Games.Security.Implements;
using Machado_Games.Service;
using Machado_Games.Service.Implements;
using Machado_Games.Validator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using blogpessoal.Configuration;

namespace Machado_Games
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                            .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });

            // Conexão com o Banco de dados
            var connectionString = builder.Configuration.
                    GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            // Validação das Entidades
            builder.Services.AddTransient<IValidator<Produto>, ProdutoValidator>();
            builder.Services.AddTransient<IValidator<Categoria>, CategoriaValidator>();
            builder.Services.AddTransient<IValidator<User>, UserValidator>();


            // Registrar as Classes e Interfaces Service
            builder.Services.AddScoped<IProdutoService, ProdutoService>();
            builder.Services.AddScoped<ICategoriaService, CategoriaService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var key = Encoding.UTF8.GetBytes(Settings.Secret);
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            
            // Configuração do Swagger
            builder.Services.AddSwaggerGen(options =>
            {
                // Adição das informações do projeto e da pessoa desenvolvedora
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Projeto Machado Games",
                    Description = "Projeto Machado Games - ASP.NET Core 7.0",
                    Contact = new OpenApiContact
                    {
                        Name = "Leonardo Machado",
                        Email = "dev.leonardomachado@gmail.com",
                        Url = new Uri("https://github.com/ldmachad")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "GitHub",
                        Url = new Uri("https://github.com/ldmachad")
                    }
                });

                // Configuração de Segurança do Swagger
                options.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Digite um Token JWT válido",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                // Adicionar a indicação de endpoint protegido
                options.OperationFilter<AuthResponsesOperationFilter>();
            });

            // Adição do Fluent Validation no Swagger
            builder.Services.AddFluentValidationRulesToSwagger();

            // Configuração do CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "MyPolicy",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Criar o Banco de dados e as tabelas Automaticamente
            using (var scope = app.Services.CreateAsyncScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}