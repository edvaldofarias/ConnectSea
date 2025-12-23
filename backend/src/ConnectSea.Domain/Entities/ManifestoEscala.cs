namespace ConnectSea.Domain.Entities;

public class ManifestoEscala
{
    public ManifestoEscala(int manifestoId, int escalaId)
    {
        ManifestoId = manifestoId;
        EscalaId = escalaId;
        DataVinculacao = DateTimeOffset.UtcNow;
    }

    public int ManifestoId { get; private set; }

    public int EscalaId { get; private set; }

    public Escala Escala { get; private set; } = default!;

    public Manifesto Manifesto { get; private set; } = default!;

    public DateTimeOffset DataVinculacao { get; private set; }
}