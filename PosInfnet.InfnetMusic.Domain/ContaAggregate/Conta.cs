using PosInfnet.InfnetMusic.Domain.BandaAggregate;
using PosInfnet.InfnetMusic.Domain.BandaAggregate.ValueObjects;
using PosInfnet.InfnetMusic.Domain.TransacaoAggregate;

namespace PosInfnet.InfnetMusic.Domain.ContaAggregate;

public class Conta
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string SenhaHash { get; set; }
    public Assinatura? Assinatura { get; set; }
    public List<Musica> MusicasFavoritas { get; private set; } = [];
    public List<Banda> BandasFavoritas { get; private set; } = [];
    public List<Transacao> Transacoes { get; set; } = [];

    public void FavoritarMusica(Musica musica)
    {
        if (!MusicasFavoritas.Contains(musica))
        {
            MusicasFavoritas.Add(musica);
            return;
        }
    }

    public void DesfavoritarMusica(Musica musica)
    {
        if (!MusicasFavoritas.Contains(musica))
        {
            return;
        }

        MusicasFavoritas.Remove(musica);
    }

    public void FavoritarBanda(Banda banda)
    {
        if (!BandasFavoritas.Contains(banda))
        {
            BandasFavoritas.Add(banda);
            return;
        }
    }

    public void DesfavoritarBanda(Banda banda)
    {
        if (!BandasFavoritas.Contains(banda))
        {
            return;
        }

        BandasFavoritas.Remove(banda);
    }

    public void CriarAssinatura(Assinatura assinatura)
    {
        Assinatura = assinatura;
    }
}
