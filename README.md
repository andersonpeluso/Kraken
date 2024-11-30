
# Projeto Kraken

## Visão Geral
Kraken é uma aplicação modular e escalável projetada para otimizar processos dentro de seu domínio. Ela segue os princípios da arquitetura limpa, garantindo facilidade de manutenção e testabilidade.

## Arquitetura
O projeto segue uma arquitetura em camadas com os seguintes componentes:
- **Kraken.API**: Gerencia interações externas por meio de uma API RESTful, utilizando controladores e tratamento de exceções para maior robustez.
- **Kraken.Application**: Administra as regras de negócio e a lógica da aplicação, implementando casos de uso através de serviços.
- **Kraken.Core**: Define a camada de domínio, incluindo entidades e contratos de repositórios, garantindo uma separação clara de responsabilidades.
- **Kraken.Infrastructure**: Fornece detalhes de implementação, como persistência de dados e configurações de injeção de dependência.

## Principais Funcionalidades
- Arquitetura limpa e modular.
- Injeção de dependência (IoC) para melhor gerenciamento.
- Abstração do acesso a dados por meio de repositórios.
- Arquivos de configuração para ajustes específicos de ambiente.

  # Kraken Backend
  
## Começando
1. Abra o arquivo `Kraken.sln` no Visual Studio 2022 ou superior.
2. Configure as definições necessárias do ambiente no arquivo `appsettings.json`.
3. Compile e execute a solução.

   # Kraken Frontend

## Começando

Siga os passos abaixo para configurar e executar o projeto:

1. Certifique-se de ter o Node.js instalado na versão recomendada no arquivo `package.json`.
2. Instale as dependências do projeto executando o comando:
   ```bash
   npm install

## Tecnologias Utilizadas
- **.NET Core 8**: Um framework moderno e de alta performance.
- **Contêineres de IoC**: Para gerenciar dependências.
- **Entity Framework**: (se utilizado em `Persistence`) para gerenciamento de banco de dados.

## Estrutura de Pastas
- `Kraken.API`: Ponto de entrada da aplicação.
- `Kraken.Application`: Lógica de negócio ao nível da aplicação.
- `Kraken.Core`: Entidades de domínio e contratos.
- `Kraken.Infrastructure`: Implementações específicas de infraestrutura.

![- Não autenticado](/imagens/nao-autenticado.png)
*Figura 1: Tela de do usuário não autenticado.*

![- Gerado o token (JWT)](/imagens/token.png)
*Figura 2: Autenticando.*

![- Autenticado e listando os produtos](/imagens/autenticado.png)
*Figura 3: Autenticado.*

![- Gravando o produto](/imagens/grava-produto.png)
*Figura 4: Produto gravado.*

![- Tela de login](/imagens/tela-login.jpg)
*Figura 5: Tela de login.*

![- Cadastrando o produto](/imagens/listage-produtos.jpg)
*Figura 6: Tela de listagem de produto.*
