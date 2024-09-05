using ControleFluxoCaixa.Aplicacao.Servicos;
using ControleFluxoCaixa.Dominio.Entidades;
using ControleFluxoCaixa.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

public class LancamentoServicoTestes
{
    [Fact]
    public void AdicionarLancamento_DeveAdicionarLancamento()
    {
        var options = new DbContextOptionsBuilder<ControleFluxoCaixaDbContext>()
            .UseInMemoryDatabase(databaseName: "ControleFluxoCaixaTest")
            .Options;

        using (var context = new ControleFluxoCaixaDbContext(options))
        {
            var servico = new LancamentoServico(context);
            var lancamento = new Lancamento { Valor = 100, Data = DateTime.Now, IsCredito = true, Tipo = "Credito" };

            servico.AdicionarLancamento(lancamento);

            Assert.Equal(1, context.Lancamentos.Count());
            Assert.Equal(100, context.Lancamentos.Single().Valor);
        }
    }
}