using ApiAuditoria.Gateways.DataContext;
using ApiAuditoria.Gateways.Repository;
using ApiAuditoria.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApiAuditoriaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuditService"), options => options.EnableRetryOnFailure()));
builder.Services.AddScoped<IAuditoriaAsignacionRepository, AuditoriaAsignacionRepository>();
builder.Services.AddScoped<IAuditoriaDocumentoProcesosRepository, AuditoriaDocumentoProcesosRepository>();
builder.Services.AddScoped<IAuditoriaDocumentosRepository, AuditoriaDocumentosRepository>();
builder.Services.AddScoped<IAuditoriaGastosRepository, AuditoriaGastosRepository>();
builder.Services.AddScoped<IAuditoriasRepository, AuditoriasRepository>();
builder.Services.AddScoped<IAuditoriaTareaProcesosRepository, AuditoriaTareaProcesosRepository>();
builder.Services.AddScoped<IAuditoriaTareasRepository, AuditoriaTareasRepository>();
builder.Services.AddScoped<ICatalogoGastosRepository, CatalogoGastosRepository>();
builder.Services.AddScoped<ICatalogoPlantillasRepository, CatalogoPlantillasRepository>();
builder.Services.AddScoped<ICatalogoProcesosRepository, CatalogoProcesosRepository>();
builder.Services.AddScoped<ICatalogoTareasRepository, CatalogoTareasRepository>();
builder.Services.AddScoped<ICategoriaGastosRepository, CategoriaGastosRepository>();
builder.Services.AddScoped<ICotizacionesRepository, CotizacionesRepository>();
builder.Services.AddScoped<IMonedasRepository, MonedasRepository>();
builder.Services.AddScoped<IResponsablesRepository, ResponsablesRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(o => {
    o.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API - Modulo de Control de Auditorias - Sistema de Auditoria - Romero y Asociados",
        Description = "Net Core API que se encarga del mantenimiento y consulta de las tablas del modulo de Control de Auditorias"
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

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
