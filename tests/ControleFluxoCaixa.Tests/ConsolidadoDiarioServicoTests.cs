using ControleFluxoCaixa.Aplicacao.Servicos;
using ControleFluxoCaixa.Dominio.Entidades;
using ControleFluxoCaixa.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ControleFluxoCaixa.Aplicacao.Tests.Servicos
{
    public class ConsolidadoDiarioServicoTests
    {
        [Fact]
        public async Task GetConsolidadoDiarioAsync_Should_Return_ConsolidadoDiario()
        {
            // Arrange
            var data = new DateTime(2022, 1, 1);
            var lancamentos = new List<Lancamento>
            {
                new Lancamento { Data = new DateTime(2022, 1, 1), Tipo = "Credito", Valor = 100 },
                new Lancamento { Data = new DateTime(2022, 1, 1), Tipo = "Credito", Valor = 200 },
                new Lancamento { Data = new DateTime(2022, 1, 1), Tipo = "Debito", Valor = 50 },
                new Lancamento { Data = new DateTime(2022, 1, 2), Tipo = "Credito", Valor = 150 },
                new Lancamento { Data = new DateTime(2022, 1, 2), Tipo = "Debito", Valor = 75 }
            };

            var mockContext = new Mock<ControleFluxoCaixaDbContext>();
            mockContext.Setup(c => c.Lancamentos)
                .Returns(MockDbSet(lancamentos));

            var servico = new ConsolidadoDiarioServico(mockContext.Object);

            // Act
            var result = await servico.GetConsolidadoDiarioAsync(data);

            // Assert
            Assert.Equal(data, result.Data);
            Assert.Equal(300, result.TotalCreditos);
            Assert.Equal(125, result.TotalDebitos);
            Assert.Equal(175, result.Saldo);
        }

        private static DbSet<T> MockDbSet<T>(IEnumerable<T> data) where T : class
        {
            var queryable = data.AsQueryable();
            var mockDbSet = new Mock<DbSet<T>>();
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            return mockDbSet.Object;
        }
    }
}
