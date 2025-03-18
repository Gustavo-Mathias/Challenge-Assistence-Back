using Assistencia.Repositories;
using Assistencia.Services;
using DesafioAssistencia.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do banco de dados MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Adicionando inje��o de depend�ncia
builder.Services.AddScoped<IVeiculoAssistenciaRepository, VeiculoAssistenciaRepository>();
builder.Services.AddScoped<VeiculoAssistenciaService>();

// Adicionando servi�os essenciais
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do Kestrel para escutar em qualquer IP e permitir conex�es externas
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5000); // Porta 5000 dentro do container
});

// Constru��o do aplicativo
var app = builder.Build();

// Se estiver em ambiente de desenvolvimento, habilita Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirecionamento HTTPS (desativado para evitar erro no Docker)
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

// Aguarde o banco de dados MySQL estar pronto antes de rodar
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var retry = 0;
    while (retry < 5)
    {
        try
        {
            db.Database.Migrate(); // Aplica as migra��es
            break;
        }
        catch (Exception ex)
        {
            retry++;
            Console.WriteLine($"Tentativa {retry}: Banco de dados n�o est� pronto... aguardando...");
            Thread.Sleep(5000);
        }
    }
}

// Inicia a API
app.Run();
