using ControleFluxoCaixa.Aplicacao.Interfaces;
using ControleFluxoCaixa.Dominio.Entidades;
using ControleFluxoCaixa.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace ControleFluxoCaixa.Aplicacao.Servicos
{
    public class LancamentoServico : ILancamentoServico
    {
        private readonly ControleFluxoCaixaDbContext _context;

        public LancamentoServico(ControleFluxoCaixaDbContext context)
        {
            _context = context;
        }

        public void AdicionarLancamento(Lancamento lancamento)
        {
            _context.Lancamentos.Add(lancamento);
            _context.SaveChanges();
        }

        public decimal ObterSaldoDiario(DateTime data)
        {
            var lancamentos = _context.Lancamentos.Where(l => l.Data.Date == data.Date);
            var saldo = lancamentos.Sum(l => l.IsCredito ? l.Valor : -l.Valor);
            return saldo;
        }

        public async Task<IEnumerable<Lancamento>> GetLancamentosAsync()
        {
            return await _context.Lancamentos.ToListAsync();
        }

        public async Task<Lancamento> GetLancamentoByIdAsync(int id)
        {
            return await _context.Lancamentos.FindAsync(id);
        }

        public async Task AddLancamentoAsync(Lancamento lancamento)
        {
            await _context.Lancamentos.AddAsync(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLancamentoAsync(Lancamento lancamento)
        {
            _context.Lancamentos.Update(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLancamentoAsync(int id)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);
            if (lancamento != null)
            {
                _context.Lancamentos.Remove(lancamento);
                await _context.SaveChangesAsync();
            }
        }        
    }
}
