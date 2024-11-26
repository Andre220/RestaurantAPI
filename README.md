# Restaurant API

Uma API para gerenciar pedidos de clientes em um restaurante. Desenvolvida utilizando .NET Core, com arquitetura limpa, boas práticas de organização de código e testes unitários planejados.

---

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework principal para desenvolvimento da API.
- **Entity Framework Core**: ORM para gerenciamento do banco de dados PostgreSQL.
- **PostgreSQL**: Banco de dados relacional.
- **ASP.NET Core Identity**: Sistema de autenticação e autorização.
- **JWT**: Gerenciamento de autenticação através de tokens.
- **Arquitetura Onion (Clean Architecture)**: Separação de responsabilidades e camadas.

---

## Endpoints Disponíveis

### **1. Autenticação**

- **Login**
  - **POST /api/Auth/Login**
  - **Body Exemplo**:
    ```json
    {
      "email": "usuario@teste.com",
      "password": "Senha@123"
    }
    ```

- **Registrar Novo Usuário**
  - **POST /api/Auth/Register**
  - **Body Exemplo**:
    ```json
    {
      "email": "novo@usuario.com",
      "password": "SenhaForte@123",
      "firstName": "João",
      "lastName": "Silva",
      "phoneNumber": "11999999999"
    }
    ```

---

### **2. Cardápio**

- **Listar Itens do Cardápio**
  - **GET /api/MenuItem**

- **Adicionar Item ao Cardápio**
  - **POST /api/MenuItem**
  - **Body Exemplo**:
    ```json
    {
      "name": "Pizza Margherita",
      "priceCents": 3500
    }
    ```

- **Editar Item do Cardápio**
  - **PUT /api/MenuItem/{id}**
  - **Body Exemplo**:
    ```json
    {
      "name": "Pizza Margherita Especial",
      "priceCents": 4000
    }
    ```

- **Deletar Item do Cardápio**
  - **DELETE /api/MenuItem/{id}**

---

### **3. Pedidos**

- **Listar Pedidos**
  - **GET /api/Order**

- **Criar Pedido**
  - **POST /api/Order**
  - **Body Exemplo**:
    ```json
    {
      "customer": {
        "firstName": "Maria",
        "lastName": "Santos",
        "phoneNumber": "21988887777"
      },
      "orderItems": [
        {
          "menuItemId": "1b04f87a-3495-4d60-9827-2fae24b7c9e1",
          "quantity": 2
        }
      ]
    }
    ```

- **Atualizar Pedido**
  - **PUT /api/Order/{id}**
  - **Body Exemplo**:
    ```json
    {
      "status": "Ready"
    }
    ```

- **Deletar Pedido**
  - **DELETE /api/Order/{id}**

---

### **4. Clientes**

- **Listar Todos os Clientes (com Paginação)**
  - **GET /api/Customer?pageNumber=1&pageSize=10**

- **Criar Cliente**
  - **POST /api/Customer**
  - **Body Exemplo**:
    ```json
    {
      "firstName": "Ana",
      "lastName": "Pereira",
      "phoneNumber": "31999999999"
    }
    ```

- **Editar Cliente**
  - **PUT /api/Customer/{id}**
  - **Body Exemplo**:
    ```json
    {
      "firstName": "Ana Maria",
      "lastName": "Pereira",
      "phoneNumber": "31999999999"
    }
    ```

- **Deletar Cliente**
  - **DELETE /api/Customer/{id}**

---

## Swagger

A API possui documentação interativa gerada com Swagger. Acesse `https://localhost:44381/swagger` para visualizar e testar os endpoints diretamente no navegador.

---

## Estrutura do Projeto

- **Core**: Camada com as entidades e interfaces.
- **Application**: Camada com as regras de negócio e validações.
- **Infrastructure**: Camada com implementações do EF Core e configuração do banco de dados.
- **Web**: Camada principal que expõe a API.
- **Tests**: Projeto para os testes unitários.

---

## TODOs

- [ ] **Adicionar Claims e Roles**
  - Implementar permissões específicas para endpoints com base em roles.
- [ ] **Adicionar Testes Unitários**
  - Cobrir os serviços e regras de negócio com testes.
- [ ] **Remover ou Corrigir Warnings**
  - Garantir que o projeto está livre de warnings para manter o código limpo.

---

## Como Executar

1. Clone este repositório:
   ```bash
   git clone https://github.com/Andre220/RestaurantAPI.git
   ```
2. Configure a string de conexão no arquivo appsettings.json.
3. Execute as migrações do banco de dados:
   ```bash
    dotnet ef database update
   ```
4. Inicie a aplicação:
   ```bash
    dotnet run --project Restaurant.Web
   ```
5. Acesse o Swagger para interagir com a API.

