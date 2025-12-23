using ConnectSea.Domain.Enums;

namespace ConnectSea.Domain.Dtos;

public record EscalaDto(
    int Id,    
    string Navio,
    string Porto,
    StatusEscala Status,
    DateTimeOffset Eta,
    DateTimeOffset? Etb = null,
    DateTimeOffset? Etd = null);