using ConnectSea.Domain.Enums;

namespace ConnectSea.Domain.Dtos;

public record EscalaDto(
    int Id,    
    string navio,
    string porto,
    StatusEscala status,
    DateTimeOffset eta,
    DateTimeOffset? etb = null,
    DateTimeOffset? etd = null);