using PosInfnet.InfnetMusic.Domain.BandaAggregate.ValueObjects;
using PosInfnet.InfnetMusic.Domain.ContaAggregate;

namespace PosInfnet.InfnetMusic.Domain.BandaAggregate;

public class Banda(string nome)
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Nome { get; set; } = nome;
    public List<Musica> Musicas { get; set; } = [];
    public ICollection<Conta> ContasBandasFavoritas { get; set; } = [];
}
