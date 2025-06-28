namespace PosInfnet.InfnetMusic.WebApp.Models.Assinatura;

public class AssinaturaModel()
{
    public string Id { get; set; }
    public int TipoPlano { get; set; }
    public decimal Preco { get; set; }
    public DateTime Data { get; set; }
    public List<PlanosAssinaturaModel>? PlanosAssinaturaModels { get; set; }
}
