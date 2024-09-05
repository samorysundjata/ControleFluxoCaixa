// ControleFluxoCaixa.Aplicacao/Servicos/LancamentoServico.cs
using ControleFluxoCaixa.Dominio.Entidades;
using ControleFluxoCaixa.Infraestrutura.Contexto;

namespace ControleFluxoCaixa.Aplicacao.Servicos
{
    public class LancamentoServico
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
    }
}
