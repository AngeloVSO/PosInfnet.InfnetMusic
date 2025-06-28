# InfnetMusic

Um sistema de gesrenciamento de músicas e bandas desenvolvido em .NET 8 com arquitetura limpa e DDD, oferecendo funcionalidades de gerenciamento de músicas, assinaturas e perfis de usuário.

## 🚀 Funcionalidades

- **Gerenciamento de Conta**
  - Cadastro e login de usuários
  - Autenticação via JWT Token
  - Gerenciamento de perfil

- **Controle de Músicas e Bandas**
  - Listagem de músicas e bandas
  - Busca por título
  - Sistema de favoritos
  - Gerenciamento de músicas e bandas favoritas

- **Sistema de Assinaturas**
  - Planos: Gratuito, Mensal (R$19,90) e Anual (R$199,90)
  - Processamento de pagamentos
  - Gerenciamento de transações

## 🛠️ Tecnologias

- .NET 8
- ASP.NET Core Web API
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- JWT Authentication
- BCrypt para hash de senhas

## 📁 Estrutura do Projeto

- **API**: Endpoints REST para consumo externo
- **WebApp**: Interface web usando Razor Pages
- **Domain**: Regras de negócio e entidades principais
- **Application**: Orquestração e casos de uso
- **Infrastructure**: Acesso a dados e serviços externos

## 🏗️ Arquitetura

- **Clean Architecture**
- **Domain-Driven Design (DDD)**
- **Repository Pattern**
- **MVC Pattern**

## 🔒 Segurança

- Autenticação via JWT Token
- Senhas criptografadas com BCrypt
- HTTPS
- Cross-Site Request Forgery (CSRF) Protection
- Cookies seguros com HttpOnly e SameSite

# Endpoints da API InfnetMusic

## Autenticação e Conta (`/api/conta`)
| Método | Endpoint | Descrição | Parâmetros |
|--------|----------|-----------|------------|
| POST | `/login` | Autentica um usuário | `{ "email": string, "senha": string }` |
| POST | `/cadastrar` | Cadastra novo usuário | `{ "nome": string, "email": string, "senha": string }` |
| POST | `/token` | Gera novo token | `email: string` |

## Assinaturas (`/api/assinatura`)
| Método | Endpoint | Descrição | Parâmetros |
|--------|----------|-----------|------------|
| POST | `/criar` | Cria nova assinatura | `{ "tipoPlano": int, "contaId": string }` |
| GET | `/{contaId}` | Obtém assinatura por ID da conta | `contaId: string` |

## Músicas (`/api/musica`)
| Método | Endpoint | Descrição | Parâmetros |
|--------|----------|-----------|------------|
| GET | `/obtertodas` | Lista todas as músicas | `contaId: string` (query) |
| GET | `/obterportitulo` | Busca música por título | `contaId: string, titulo: string` (query) |
| GET | `/obterfavoritas` | Lista músicas favoritas | `contaId: string` (query) |
| PUT | `/favoritarmusica` | Favorita uma música | `contaId: string, musicaId: string` (query) |
| DELETE | `/desfavoritarmusica` | Remove música dos favoritos | `contaId: string, musicaId: string` (query) |

## Bandas (`/api/banda`)
| Método | Endpoint | Descrição | Parâmetros |
|--------|----------|-----------|------------|
| GET | `/obtertodas` | Lista todas as bandas | `contaId: string` (query) |
| GET | `/obterporid` | Busca banda por ID | `contaId: string, bandaId: string` (query) |
| GET | `/obterpornome` | Busca banda por nome | `contaId: string, nome: string` (query) |
| PUT | `/favoritarbanda` | Favorita uma banda | `contaId: string, bandaId: string` (query) |
| DELETE | `/desfavoritarbanda` | Remove banda dos favoritos | `contaId: string, bandaId: string` (query) |

## Autenticação
Todos os endpoints (exceto `/conta/login` e `/conta/cadastrar`) requerem autenticação via Bearer Token.

## ⚙️ Configuração

1. Clone o repositório: git clone https://github.com/seu-usuario/PosInfnet.InfnetMusic.git
2. Configure a string de conexão no `appsettings.json`
3. Execute as migrations
4. Executes os scripts de seedBandas e seedMusicas, respectivamente
5. Execute o projeto

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
