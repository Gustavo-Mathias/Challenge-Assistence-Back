using Assistencia.Repositories;
using Assistencia.Services;
using DesafioAssistencia.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5244);
    serverOptions.ListenAnyIP(5001, listenOptions => listenOptions.UseHttps());
});

builder.WebHost.UseUrls("http://localhost:5244", "https://localhost:5001");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddScoped<IGrupoVeiculoRepository, GrupoVeiculoRepository>();
builder.Services.AddScoped<IVeiculoAssistenciaRepository, VeiculoAssistenciaRepository>();
builder.Services.AddScoped<VeiculoAssistenciaService>();
builder.Services.AddScoped<GrupoVeiculoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
