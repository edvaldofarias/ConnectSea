
# ConnectSea

Projeto desenvolvido para entrevista técnica na empresa **[Connect Sea](https://www.connectsea.com.br/)**.

## Arquitetura

O projeto é composto por três componentes principais:

- **Backend**: Aplicação desenvolvida em **C#**, localizada na pasta `/backend`
- **Frontend**: Aplicação desenvolvida em **Angular**, localizada na pasta `/frontend`
- **Banco de Dados**: **SQL Server**

## Docker Compose

### Build

Para construir as imagens Docker, execute:

```bash
docker-compose build
```

### Up

Para iniciar todos os serviços (backend, frontend e banco de dados):

```bash
docker-compose up
```

Ou em modo detached:

```bash
docker-compose up -d
```

### Down

Para parar e remover todos os contêineres:

```bash
docker-compose down
```

---

Para mais informações, consulte a documentação específica de cada componente nas respectivas pastas.
