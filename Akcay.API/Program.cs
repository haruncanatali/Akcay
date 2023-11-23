
using Akcay.API.Configs;
using Akcay.API.Extensions;
using Akcay.Application;
using Akcay.Application.Common.Interfaces;
using Akcay.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddSettingsConfig(builder.Configuration);

builder.Services.AddApplication();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IApplicationContext>());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfig();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MigrateDatabase();

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.UseErrorHandlingMiddleware();

app.MapControllers();

app.Run();