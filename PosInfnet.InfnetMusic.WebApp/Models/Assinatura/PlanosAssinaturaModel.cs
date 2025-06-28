namespace PosInfnet.InfnetMusic.WebApp.Models.Assinatura;

public class PlanosAssinaturaModel(string tipoPlano, int codigoTipoPlano)
{
    public string TipoPlano { get; } = tipoPlano;
    public int CodigoTipoPlano { get; } = codigoTipoPlano;
}
