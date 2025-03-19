using Assistencia.Repositories;
using Assistencia.Services;
using DesafioAssistencia.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IVeiculoAssistenciaRepository, VeiculoAssistenciaRepository>();
builder.Services.AddScoped<VeiculoAssistenciaService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5000);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var retry = 0;
    while (retry < 5)
    {
        try
        {
            db.Database.Migrate(); 
            break;
        }
        catch (Exception ex)
        {
            retry++;
            Console.WriteLine($"Tentativa {retry}: Banco de dados não está pronto... aguardando...");
            Thread.Sleep(5000);
        }
    }
}
app.Run();
