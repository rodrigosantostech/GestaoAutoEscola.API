#API do Sistema de Gestão de Autoescola
Bem-vindo(a) à documentação da API do Sistema de Gestão de Autoescola. Esta API permite a integração de um sistema de gerenciamento de autoescola, oferecendo funcionalidades para gerenciar alunos, instrutores, veículos, aulas e muito mais.

A API é baseada em arquitetura RESTful e utiliza os princípios HTTP para realizar operações de CRUD (Create, Read, Update, Delete) nos recursos disponíveis. É fornecido suporte para autenticação e autorização, permitindo que você controle o acesso aos recursos da API.

Recursos Disponíveis
A seguir, são listados os principais recursos disponíveis nesta API:

Alunos: Gerencie informações dos alunos matriculados na autoescola, incluindo dados pessoais, informações de pagamento e histórico de aulas.
Instrutores: Cadastre e consulte informações sobre os instrutores responsáveis pela instrução dos alunos.
Veículos: Gerencie os veículos utilizados nas aulas práticas, mantendo informações sobre os modelos, placas e disponibilidade.
Aulas: Realize operações relacionadas às aulas práticas, como agendamento, consulta de horários disponíveis e registro de comparecimento dos alunos.
Autenticação
A API utiliza autenticação baseada em tokens para garantir a segurança dos recursos. Para utilizar os endpoints protegidos, é necessário incluir um token de autenticação válido no cabeçalho das requisições. Os tokens podem ser obtidos através do endpoint de login, fornecendo as credenciais corretas.

Endpoints
A seguir, são listados os principais endpoints da API:

`POST /login`: Realiza a autenticação do usuário e retorna um token de acesso.
`GET /alunos`: Retorna a lista de alunos cadastrados na autoescola.
`POST /alunos`: Cadastra um novo aluno na autoescola.
`GET /alunos/{id}`: Retorna as informações detalhadas de um aluno específico.
`PUT /alunos/{id}`: Atualiza as informações de um aluno específico.
`DELETE /alunos/{id}`: Remove um aluno da autoescola.
`GET /instrutores`: Retorna a lista de instrutores cadastrados na autoescola.
`POST /instrutores`: Cadastra um novo instrutor na autoescola.
`GET /instrutores/{id}`: Retorna as informações detalhadas de um instrutor específico.
`PUT /instrutores/{id}`: Atualiza as informações de um instrutor específico.
`DELETE /instrutores/{id}`: Remove um instrutor da autoescola.
`GET /veiculos`: Retorna a lista de veículos cadastrados na autoescola.
`POST /veiculos`: Cadastra um novo veículo na autoescola.
`GET /veiculos/{id}`: Retorna as informações detalhadas de um veículo específico.
`PUT /veiculos/{id}`: Atualiza as informações de um veículo específico.
`DELETE /veiculos/{id}`: Remove um veículo da autoescola.
`GET /aulas`: Retorna a lista de aulas agendadas na autoescola.
`POST /aulas`: Agenda uma nova aula prática.
`GET /aulas/{id}`: Retorna