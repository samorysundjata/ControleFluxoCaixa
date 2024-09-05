namespace ControleFluxoCaixa.Dominio.Entidades
{
    public class ConsolidadoDiario
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal TotalCreditos { get; set; }
        public decimal TotalDebitos { get; set; }
        public decimal Saldo { get; set; }
    }
}
