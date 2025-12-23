using ConnectSea.Domain.Enums;

namespace ConnectSea.Domain.Dtos;

public record ManifestoDto(
    int Id,
    string Numero,
    TipoManifesto Tipo,
    string Navio,
    string PortoOrigem,
    string PortoDestino);