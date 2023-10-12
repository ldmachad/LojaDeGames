# Machado Games 🎮 

Este repositório contém o código-fonte do backend para uma Loja de Games desenvolvida em ASP.NET. O backend é responsável por gerenciar os dados dos produtos disponíveis na loja, categorizados para facilitar a navegação dos clientes. Além disso, implementa um sistema de segurança com token Bearer JWT para autenticação.

## Funcionalidades

- **Produtos Categorizados**: Os produtos são classificados em diferentes categorias para uma navegação fácil e organizada.

- **Operações CRUD**: Permite criar, listar, atualizar e excluir produtos da loja.

- **Token Bearer JWT**: Implementa um sistema de autenticação seguro com tokens JWT para proteger as rotas e os dados sensíveis.

- **API RESTful**: Oferece endpoints RESTful para interação com o frontend ou outras aplicações.

## Tecnologias Utilizadas

- ASP.NET
- Entity Framework
- JWT para autenticação
- Banco de dados SQL (ou outro de sua escolha)

## Configuração

Para configurar e executar o projeto em sua máquina, siga estas etapas:

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/ldmachad/MachadoGames
   ```
2. Navegue até o diretório do projeto.
3. Configure a conexão com o banco de dados em appsettings.json.
4. Inicie o projeto.
5. Acesse o backend por meio de:
   ```bash
   http://localhost:5000
   ```

## Endpoints da API

# Usuário

GET /usuarios: Retorna a lista de usuários.

GET /usuarios/{id}: Retorna um usuário específico por ID.

POST /usuarios/cadastrar: Cria um novo usuário.

POST /usuarios/logar: Faz login do usuário.

PUT /usuarios/atualizar: Atualiza um usuário existente.

# Categoria

GET /categorias: Retorna a lista de categorias.

GET /categorias/{id}: Retorna uma categoria específica por ID.

GET /categorias/tipo/{tipo}: Retorna uma categoria específica pelo Tipo.

POST /categorias: Cria uma nova categoria.

PUT /categorias/{id}: Atualiza uma categoria existente.

DELETE /categorias/{id}: Exclui uma categoria.

# Produto

GET /produtos: Retorna a lista de produtos.

GET /produtos/{id}: Retorna um produto específico por ID.

GET /produtos/nome/{nome}/ouconsole/{console}: Retorna um produto específico pelo nome ou console.

GET /produtos/preco_inicial/{min}/preco_final/{max}: Retorna um produto específico pelo intervalo de preço.

POST /produtos: Cria um novo produto.

PUT /produtos/{id}: Atualiza um produto existente.

DELETE /produtos/{id}: Exclui um produto.

## Autenticação

Para acessar as rotas protegidas, você precisará incluir um token JWT válido nas solicitações. Esse token será gerado ao efetuar o login do usuário.

Certifique-se de incluir o token no cabeçalho das requisições protegidas com o cabeçalho **Authorization** no formato **Bearer seu-token-jwt-aqui**.

# Exemplo de Login:

``` bash
POST /usuarios/logar
Content-Type: application/json

{
  "username": "usuario@usuario.com.br",
  "password": "12345678"
}
```
**Importante:** O usuário deverá ter o formato de um e-mail e a senha deverá conter no mínimo 8 caracteres.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir problemas, enviar solicitações de pull ou melhorar o projeto.

**Divirta-se desenvolvendo sua loja de games! Se tiver alguma dúvida ou problema, não hesite em entrar em contato.**
