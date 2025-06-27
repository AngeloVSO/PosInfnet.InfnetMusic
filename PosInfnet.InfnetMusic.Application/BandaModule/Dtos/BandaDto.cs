namespace PosInfnet.InfnetMusic.Application.BandaModule.Dtos;

public record BandaDto
{
    public string Id { get; init; }
    public string Nome { get; init; }
    public bool EhFavorita { get; init; }
}