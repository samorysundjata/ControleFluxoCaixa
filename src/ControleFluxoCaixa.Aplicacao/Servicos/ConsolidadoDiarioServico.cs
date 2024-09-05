using ControleFluxoCaixa.Aplicacao.Interfaces;
using ControleFluxoCaixa.Dominio.Entidades;
using ControleFluxoCaixa.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace ControleFluxoCaixa.Aplicacao.Servicos
{
    public class ConsolidadoDiarioServico : IConsolidadoDiarioServico
    {
        private readonly ControleFluxoCaixaDbContext _context;

        public ConsolidadoDiarioServico(ControleFluxoCaixaDbContext context)
        {
            _context = context;
        }

        public async Task<ConsolidadoDiario> GetConsolidadoDiarioAsync(DateTime data)
        {
            var lancamentos = await _context.Lancamentos
                .Where(l => l.Data.Date == data.Date)
                .ToListAsync();

            var totalCreditos = lancamentos.Where(l => l.Tipo == "Credito").Sum(l => l.Valor);
            var totalDebitos = lancamentos.Where(l => l.Tipo == "Debito").Sum(l => l.Valor);
            var saldo = totalCreditos - totalDebitos;

            return new ConsolidadoDiario
            {
                Data = data,
                TotalCreditos = totalCreditos,
                TotalDebitos = totalDebitos,
                Saldo = saldo
            };
        }
    }
}
