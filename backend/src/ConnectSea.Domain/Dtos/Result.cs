namespace ConnectSea.Domain.Dtos;

public record Result(bool Sucesso = true, string? Mensagem = null, bool Duplicidade = false);