using PosInfnet.InfnetMusic.Domain.ContaAggregate;
using PosInfnet.InfnetMusic.Domain.TransacaoAggregate.Enums;

namespace PosInfnet.InfnetMusic.Domain.TransacaoAggregate;

public class Transacao
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Comerciante { get; set; } = "InfnetMusic";
    public decimal Valor { get; set; }
    public DateTime Data { get; set; } = DateTime.UtcNow;
    public StatusTransacao Status { get; set; } = StatusTransacao.Processando;
    public Conta Conta { get; set; }

    public bool Autorizar()
    {
        if (Valor >= 0)
        {
            Status = StatusTransacao.Autorizada;
            return true;
        }

        return false;
    }
}
