using ControleFluxoCaixa.Aplicacao.Interfaces;
using ControleFluxoCaixa.Aplicacao.Servicos;
using ControleFluxoCaixa.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace ControleFluxoCaixa.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsolidadoDiarioController : ControllerBase
    {
        private readonly IConsolidadoDiarioServico _consolidadoDiarioService;

        public ConsolidadoDiarioController(ConsolidadoDiarioServico consolidadoDiarioService)
        {
            _consolidadoDiarioService = consolidadoDiarioService;
        }

        [HttpGet("{data}")]
        public async Task<ActionResult<ConsolidadoDiario>> GetConsolidadoDiario(DateTime data)
        {
            var consolidado = await _consolidadoDiarioService.GetConsolidadoDiarioAsync(data);
            if (consolidado == null)
            {
                return NotFound();
            }
            return consolidado;
        }
    }
}
