using ControleFluxoCaixa.Dominio.Entidades;

namespace ControleFluxoCaixa.Aplicacao.Interfaces
{
    public interface ILancamentoServico
    {
        Task<IEnumerable<Lancamento>> GetLancamentosAsync();
        Task<Lancamento> GetLancamentoByIdAsync(int id);
        Task AddLancamentoAsync(Lancamento lancamento);
        Task UpdateLancamentoAsync(Lancamento lancamento);
        Task DeleteLancamentoAsync(int id);
    }
}
