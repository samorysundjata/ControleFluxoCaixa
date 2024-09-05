namespace ControleFluxoCaixa.Dominio.Entidades
{
    public class Lancamento
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public bool IsCredito { get; set; }
        public string Tipo { get; set; } // "Credito" ou "Debito"
    }
}
