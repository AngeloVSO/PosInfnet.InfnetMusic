using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PosInfnet.InfnetMusic.API.Services;
using PosInfnet.InfnetMusic.Application.BandaModule.Interfaces;
using PosInfnet.InfnetMusic.Application.BandaModule.Services;
using PosInfnet.InfnetMusic.Application.ContaModule.Interfaces;
using PosInfnet.InfnetMusic.Application.ContaModule.Services;
using PosInfnet.InfnetMusic.Application.MusicaModule.Interfaces;
using PosInfnet.InfnetMusic.Application.MusicaModule.Services;
using PosInfnet.InfnetMusic.Application.TransacaoModule.Interfaces;
using PosInfnet.InfnetMusic.Application.TransacaoModule.Services;
using PosInfnet.InfnetMusic.Domain.BandaAggregate.Interfaces;
using PosInfnet.InfnetMusic.Domain.ContaAggregate.Interfaces;
using PosInfnet.InfnetMusic.Domain.TransacaoAggregate.Interfaces;
using PosInfnet.InfnetMusic.Infrastructure.Context;
using PosInfnet.InfnetMusic.Infrastructure.Repositories;
using System.Text;

namespace PosInfnet.InfnetMusic.API.Setup;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IContaRepository, ContaRepository>();
        services.AddScoped<ITransacaoRepository, TransacaoRepository>();
        services.AddScoped<IBandaRepository, BandaRepository>();
        services.AddScoped<IMusicaRepository, MusicaRepository>();

        services.AddScoped<IBandaService, BandaService>();
        services.AddScoped<IMusicaService, MusicaService>();
        services.AddScoped<IContaService, ContaService>();
        services.AddScoped<ITransacaoService, TransacaoService>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }


    public static IServiceCollection AddInfrastructureJWT(this IServiceCollection services, IConfiguration configuration)
    {
        var issuer = configuration["Jwt:Issuer"];
        var audience = configuration["Jwt:Audience"];
        var secreteKey = configuration["Jwt:SecretKey"];

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreteKey)),
                ClockSkew = TimeSpan.Zero
            };
        });

        return services;
    }
}
