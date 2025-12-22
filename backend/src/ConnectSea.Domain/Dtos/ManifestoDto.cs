using ConnectSea.Domain.Enums;

namespace ConnectSea.Domain.Dtos;

public record ManifestoDto(
    int Id,
    string numero,
    TipoManifesto tipo,
    string navio,
    string portoOrigem,
    string portoDestino);