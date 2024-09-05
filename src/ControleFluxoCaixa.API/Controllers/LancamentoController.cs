// ControleFluxoCaixa.Api/Controllers/LancamentoController.cs
using ControleFluxoCaixa.Aplicacao.Servicos;
using ControleFluxoCaixa.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace ControleFluxoCaixa.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentoController : ControllerBase
    {
        private readonly LancamentoServico _lancamentoServico;

        public LancamentoController(LancamentoServico lancamentoServico)
        {
            _lancamentoServico = lancamentoServico;
        }

        [HttpPost]
        public IActionResult AdicionarLancamento([FromBody] Lancamento lancamento)
        {
            _lancamentoServico.AdicionarLancamento(lancamento);
            return Ok();
        }

        [HttpGet("saldo/{data}")]
        public IActionResult ObterSaldoDiario(DateTime data)
        {
            var saldo = _lancamentoServico.ObterSaldoDiario(data);
            return Ok(saldo);
        }
    }
}
