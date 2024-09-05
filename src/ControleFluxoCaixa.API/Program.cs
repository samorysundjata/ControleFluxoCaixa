using ControleFluxoCaixa.Aplicacao.Servicos;
using ControleFluxoCaixa.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ControleFluxoCaixaDbContext>(options =>
        options.UseSqlite("Data Source=controlefluxocaixa.db"));

builder.Services.AddScoped<LancamentoServico>();
builder.Services.AddScoped<ConsolidadoDiarioServico>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ControleFluxoCaixa API V1");
        c.RoutePrefix = string.Empty; // Para acessar diretamente em https://localhost:<porta>/swagger
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
