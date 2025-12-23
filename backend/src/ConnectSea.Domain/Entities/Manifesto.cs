using ConnectSea.Domain.Enums;

namespace ConnectSea.Domain.Entities;

public class Manifesto(
    string numero,
    TipoManifesto tipo,
    string navio,
    string portoOrigem,
    string portoDestino) : BaseEntity
{
    public string Numero { get; set; } = numero;
    public TipoManifesto Tipo { get; set; } = tipo;
    public string Navio { get; set; } = navio;
    public string PortoOrigem { get; set; } = portoOrigem;
    public string PortoDestino { get; set; } = portoDestino;
    public List<ManifestoEscala> ManifestoEscalas { get; private set; } = [];

    public void AdicionarEscala(int escalaId)
    {
        var manifestoEscala = new ManifestoEscala(Id, escalaId);
        if(VerificarEscalaVinculada(escalaId))
        {
            throw new InvalidOperationException("Escala já vinculada ao manifesto.");
        }

        ManifestoEscalas.Add(manifestoEscala);
        SetDateModified();
    }

    public bool VerificarEscalaVinculada(int escalaId)
    {
        return ManifestoEscalas.Any(me => me.EscalaId == escalaId);
    }
}
