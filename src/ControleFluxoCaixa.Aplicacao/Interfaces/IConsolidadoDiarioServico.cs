using ControleFluxoCaixa.Dominio.Entidades;

namespace ControleFluxoCaixa.Aplicacao.Interfaces
{
    public interface IConsolidadoDiarioServico
    {
        Task<ConsolidadoDiario> GetConsolidadoDiarioAsync(DateTime data);
    }
}
