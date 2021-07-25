# AluraFlix Backend API

# Sobre o projeto

Este projeto busca fornecer os serviços de *back-end* de uma nova **plataforma de compartilhamento de vídeos**. A plataforma deve permitir ao usuário montar playlists com links para seus vídeos preferidos, separados por categorias.

As principais funcionalidades a serem implementadas são:

1. **API com rotas implementadas segundo o padrão REST**;
2. **Validações feitas conforme as regras de negócio**;
3. **Implementação de base de dados para persistência das informações**;
4. **Serviço de autenticação para acesso às rotas GET, POST, PUT e DELETE**.

O projeto terá uma duração de 4 semanas, onde a cada semana teremos atividades específicas a serem desenvolvidas. A última semana será dedicada a resolver quaisquer tarefas pendentes ou realizar ajustes.

# Para Rodar o projeto

Execute os Scripts SQL, para criar o Database, Tabela e procedures, que estão localizados no diretório:

```bash
├───scripts

```

Abra o arquivo **appsettings.json** que se encontra no diretório:

```bash
└───src
    ├───AluraFlix.Api
    │   ├───appsettings.json
```

Preencha com os dados de acesso ao Banco de dados

```bash
"ConnectionVideoManager": "Server=<server>;Database=<DataBase>;User Id=<User>;Password=<Password>;"
```

No terminal no mesmo diretório, execute os comandos:

```bash
    dotnet restore
```

```bash
    dotnet run
```

# Testes

Os endpoints disponíveis são:

```bash
    GET /videos
```

```bash
    POST /videos
```

```bash
    PUT /videos
```

```bash
    DELETE /videos
```

Ou se preferir, pode utilizar o [Sawagger](https://localhost:5001/swagger/index.html) para realizar os testes.

Em breve os testes unitários serão disponibilizados.

<br/>
