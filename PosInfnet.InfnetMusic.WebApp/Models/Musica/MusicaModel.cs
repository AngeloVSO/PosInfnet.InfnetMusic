namespace PosInfnet.InfnetMusic.WebApp.Models.Musica;

public record MusicaModel
{
    public string Id { get; init; }
    public string Titulo { get; init; }
    public string BandaNome { get; init; }
    public string BandaId { get; init; }
    public bool EhFavorita { get; init; }
}
