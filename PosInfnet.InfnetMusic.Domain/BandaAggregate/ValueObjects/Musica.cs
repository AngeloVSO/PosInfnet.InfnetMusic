using PosInfnet.InfnetMusic.Domain.ContaAggregate;

namespace PosInfnet.InfnetMusic.Domain.BandaAggregate.ValueObjects;

public class Musica
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Titulo { get; set; }
    public required Banda Banda { get; set; }
    public ICollection<Conta> ContasMusicasFavoritas { get; set; } = [];
}
