
# Projeto API Thunder Tasks
**Autor**: Aldo Caetano - 29/01/2025

## CRUD API Simples

O código contempla:

- Backend para servir uma API CRUD para **tarefas**, **usuários** e **tarefas_usuarios** com operações básicas.
- Toda operação no banco de dados gera uma notificação, que pode ser utilizada nos serviços adjacentes ou no frontend.
- Utilização de **ODATA** para queries.
- **Swagger** funcionando também em produção, para visualização e testes dos endpoints.
- **Containers** para SQL Server e a aplicação em si.

---

## Rodando o Projeto

### Visual Studio

1. Abra a solução `ThunderTasks.sln` na pasta raiz do projeto.
2. Aguarde a carga das dependências.
3. Compile e rode a aplicação.

### Docker

1. Execute o comando a seguir na pasta raiz do projeto:

   ```bash
   docker-compose up -d
   ```

2. Aguarde a carga dos containers. O container para o SQL Server também será criado nesse momento. **Atenção**: o SQL Server pode demorar mais que o normal para iniciar na primeira vez.
3. Acesse o Swagger da aplicação através da URL:  
   [http://localhost:5197/swagger/index.html](http://localhost:5197/swagger/index.html)

---

## Exemplos de Consultas ODATA

### Tarefas

- Acessar todas as tarefas:
  ```http
  http://localhost:5197/odata/Tarefas
  ```

- Acessar uma tarefa específica pelo ID (o ID precisa existir!):
  ```http
  http://localhost:5197/odata/Tarefas(12345678-90ab-cdef-1234-567890abcdef)
  ```

- Ordenar tarefas pela data de criação (`CreatedAt`):
  ```http
  http://localhost:5197/odata/Tarefas?$orderby=CreatedAt
  ```

- Filtrar tarefas pelo status `Pendente`:
  ```http
  http://localhost:5197/odata/Tarefas?$filter=Status eq 'Pendente'
  ```

### Usuários

- Acessar todos os usuários:
  ```http
  http://localhost:5197/odata/Usuarios
  ```

- Acessar um usuário específico pelo ID:
  ```http
  http://localhost:5197/odata/Usuarios(12345678-90ab-cdef-1234-567890abcdef)
  ```

- Ordenar usuários pelo nome (`Name`):
  ```http
  http://localhost:5197/odata/Usuarios?$orderby=Name asc
  ```

- Expandir os dados de tarefas associadas aos usuários:
  ```http
  http://localhost:5197/odata/Usuarios?$expand=TarefasUsuarios
  ```

---

## Notificações

- Toda operação no banco de dados (inserção, atualização, exclusão) gera uma **notificação**, que pode ser consumida por serviços adjacentes ou pelo frontend para comunicação em tempo real.
