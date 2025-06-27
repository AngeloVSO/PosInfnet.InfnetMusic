using PosInfnet.InfnetMusic.Domain.ContaAggregate.Enums;

namespace PosInfnet.InfnetMusic.Domain.ContaAggregate;

public class Assinatura
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public TipoPlano Plano { get; set; }
    public decimal Preco { get; set; }
    public DateTime Data { get; set; } = DateTime.UtcNow;
    public Conta Conta { get; set; }
}
