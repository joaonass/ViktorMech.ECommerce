
# ViktorMech E-Commerce

> 🚧 Projeto em desenvolvimento — e-commerce fictício com temática cyberpunk, desenvolvido para praticar engenharia de software com C#, .NET e Angular.

O **ViktorMech** é um projeto de e-commerce fictício inspirado em um marketplace de máquinas de venda (*vending machines*) em um universo cyberpunk.

O objetivo é desenvolver uma aplicação organizada e evolutiva, aplicando princípios de orientação a objetos, modelagem de domínio, separação de responsabilidades e boas práticas de desenvolvimento.

Atualmente, o foco está na construção da API, nas regras de negócio e na persistência de dados. A interface cliente e o fluxo completo de compra fazem parte das próximas etapas.

## Tecnologias

- **C#** — linguagem utilizada no desenvolvimento do back-end.
- **.NET 10** — plataforma de desenvolvimento da aplicação.
- **ASP.NET Core Web API** — criação de endpoints HTTP.
- **Entity Framework Core** — mapeamento objeto-relacional e persistência de dados.
- **SQL Server** — banco de dados relacional.
- **Angular** — tecnologia escolhida para a futura interface cliente.

## Funcionalidades implementadas

- Cadastro e consulta de produtos.
- Atualização de produtos, incluindo atualização parcial.
- Modelagem de entidades e Value Objects.
- Validação de dados e regras de domínio.
- Configuração de persistência com Entity Framework Core.
- Criação de carrinhos anônimos.
- Adição de produtos ao carrinho.
- Validação de quantidades e disponibilidade de estoque ao adicionar itens.

## Arquitetura

A solução está organizada em projetos com responsabilidades distintas:

```text
ViktorMech.ECommerce/
├── VendingMachine.Api/             # API HTTP e configuração da aplicação
├── VendingMachine.Application/     # Casos de uso e handlers
├── VendingMachine.Domain/          # Entidades, Value Objects e regras de domínio
├── VendingMachine.Infrastructure/  # Persistência e implementações técnicas
├── VendingMachine.App/             # Projeto cliente
└── ViktorMech.slnx                 # Arquivo da solução
```

### Responsabilidades das camadas

- **API:** recebe requisições HTTP e configura os componentes necessários para executar a aplicação.
- **Application:** coordena os casos de uso por meio de handlers e organiza o fluxo das operações.
- **Domain:** concentra as entidades, os Value Objects e as regras de negócio, mantendo o domínio independente dos detalhes técnicos.
- **Infrastructure:** implementa os mecanismos de persistência e o acesso ao banco de dados com Entity Framework Core.
- **App:** projeto destinado à interface cliente, planejada com Angular.

A separação em camadas busca reduzir o acoplamento, facilitar a manutenção e permitir que as funcionalidades evoluam sem concentrar todas as responsabilidades em um único projeto.

## Como executar

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)
- SQL Server acessível
- Visual Studio, Rider ou VS Code

### 1. Clone o repositório

```bash
git clone https://github.com/joaonass/ViktorMech.ECommerce.git
cd ViktorMech.ECommerce
```

### 2. Restaure as dependências e compile a API

```bash
dotnet restore VendingMachine.Api/VendingMachine.Api.csproj
dotnet build VendingMachine.Api/VendingMachine.Api.csproj
```

### 3. Configure a conexão com o banco de dados

A API utiliza uma connection string chamada `DefaultConnection`.

Para configurar o ambiente local, crie ou edite o arquivo `VendingMachine.Api/appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ViktorMechDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Ajuste o servidor, o nome do banco e o método de autenticação conforme o seu ambiente.

Como alternativa, você pode configurar a conexão usando User Secrets:

```bash
dotnet user-secrets init --project VendingMachine.Api
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<sua-connection-string>" --project VendingMachine.Api
```

Não publique senhas, tokens ou outras credenciais no repositório.

### 4. Prepare o banco de dados

Se as migrations do Entity Framework Core estiverem configuradas no projeto `VendingMachine.Infrastructure`, aplique-as com:

```bash
dotnet ef database update --project VendingMachine.Infrastructure --startup-project VendingMachine.Api
```

Caso ainda não tenha instalado a ferramenta do EF Core, execute:

```bash
dotnet tool install --global dotnet-ef
```

Esse comando pressupõe que as migrations já foram criadas e estão disponíveis no projeto indicado.

### 5. Execute a API

```bash
dotnet run --project VendingMachine.Api/VendingMachine.Api.csproj
```

A URL local será exibida no terminal. Os endpoints disponíveis dependem das funcionalidades implementadas na versão atual.

## Roadmap

- [x] Estrutura inicial da solução e separação em camadas.
- [x] Modelagem inicial do domínio.
- [x] Configurações de persistência com Entity Framework Core.
- [x] Operações de produtos.
- [x] Criação de carrinhos anônimos.
- [x] Adição de itens com validação de estoque.
- [ ] Implementação de pedidos e checkout.
- [ ] Atualização de estoque durante a finalização da compra.
- [ ] Autenticação e autorização.
- [ ] Desenvolvimento da interface Angular.
- [ ] Testes automatizados.
- [ ] Documentação dos endpoints da API.
- [ ] Integração e entrega contínuas (CI/CD).

## Objetivos de aprendizado

O projeto serve como ambiente de prática para desenvolver conhecimentos em:

- Programação orientada a objetos.
- Modelagem de domínio e Value Objects.
- Separação de responsabilidades e arquitetura em camadas.
- Desenvolvimento de APIs REST.
- Persistência de dados com Entity Framework Core.
- Validação e encapsulamento de regras de negócio.
- Integração entre aplicação e banco de dados.

## Status do projeto

O ViktorMech está em desenvolvimento ativo. As funcionalidades implementadas são concentradas no back-end, enquanto a interface cliente e o processo completo de compra permanecem como etapas futuras.

## Autor

**João Nass**

[GitHub](https://github.com/joaonass)
