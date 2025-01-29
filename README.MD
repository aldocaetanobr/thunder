# Projeto API thunder tasks
# Autor: Aldo Caetano - 29-01-2025

## CRUD API simples
O código contempla:

- Backend para servir a API CRUD para tarefas, usuarios e tarefas_usuarios com a tarefas basicas.
- Toda operação de banco gera uma notificação para ser utilizada nos serviços adjacentes ou frontend.
- Utilizacção de ODATA para queries
- Swagger rodando tambem em produção para visualização e testes dos endpoints.
- Containeres para SQL server e a aplicação em si.


## Rodando o Projeto
### Visual studio
- Abra a solução thundertasks.sln na pasta raiz.
- Aguarde a carga das dependencias.
- Compile e rode a aplicação.

### Docker
- Execute o comando <docker-compose up -d> na pasta raiz do Projeto.
- Aguarde a carga dos containers, o container para sql server tambem será criado nesse momento. (atenção para o sql server, ele pode demorar mais que o normal para iniciar na primeira vez.)
- Acesse o swagger da aplicação na url: http://localhost:5197/swagger/index.html

### Exemplos ODATA:

- Tarefas:
http://localhost:5197/odata/Tarefas
http://localhost:5197/odata/Tarefas(12345678-90ab-cdef-1234-567890abcdef) (atenção, o ID precisa existir!!!)
http://localhost:5197/odata/Tarefas?$orderby=createdat
http://localhost:5197/odata/Tarefas?$filter=Status eq 'Pendente'

- Usuarios:
http://localhost:5197/odata/Usuarios
http://localhost:5197/odata/Usuarios(12345678-90ab-cdef-1234-567890abcdef)
http://localhost:5197/odata/Usuarios?$orderby=Name asc
http://localhost:5197/odata/Usuarios?$expand=TarefasUsuarios


