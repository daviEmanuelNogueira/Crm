![fiap](https://github.com/daviEmanuelNogueira/Crm/assets/104274261/1c28656a-8218-41ed-aeed-5aeae252becc)

## 🎖️ Tech Challenge:
**Arquitetura de Sistemas .NET com Azure - Tech Challenge Fase 4: Microserviços e Serveless:** <br>
<br>
Desenvolver uma aplicação robusta seguindo os princípios da `Arquitetura Limpa` e enfatizando a qualidade do Software. Este desafio é projetado para simular um cenário de desenvolvimento real, em que a aplicação não só deve atender a requisitos funcionais específicos como garantir a manutenção, a testabilidade e a expansabilidade do código .

__________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

## 📱 Descrição do Projeto:
O tema do projeto é: CRM - Customer Relationship Management para empresas de prestação de serviços de Call Center do ramo bancário. O objetivo é registrar as solicitações de clientes referentes a movimentos em contas e utilização de cartões.

__________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

## 💂‍♀️ Participantes: 

- [Alex dos Santos Rosa](https://github.com/aleqsrosa) - RM352258; 
- [Davi Emanuel Torres de Souza Nogueira](https://github.com/daviEmanuelNogueira) - RM351602;
- [Fillipe Luis da Silva](https://github.com/fillipelsilva) - RM352110;
- [Pedro Henrique Sousa de Abreu](https://github.com/PedroAbreuHS) - RM352428.

| [<img loading= "lazy" src = "https://github.com/daviEmanuelNogueira/Crm/assets/104274261/2b4eee74-cbab-4192-91ab-19b75e45bc87" width=115>](https://github.com/aleqsrosa) | [<img loading= "lazy" src = "https://github.com/daviEmanuelNogueira/Crm/assets/104274261/e556f2d4-5312-4670-a54a-046c7de3a42d" width=115>](https://github.com/daviEmanuelNogueira) | [<img loading= "lazy" src = "https://github.com/daviEmanuelNogueira/Crm/assets/104274261/1455c943-2f52-4fcf-999b-1f1614f5cf0a" width=115>](https://github.com/fillipelsilva) | [<img loading= "lazy" src = "https://github.com/daviEmanuelNogueira/Crm/assets/104274261/0c879524-949c-492d-bf16-ea613defa63e" width=115>](https://github.com/PedroAbreuHS)
| :---: | :---: | :---: | :---: |
| Alex Rosa - RM352258 | Davi Nogueira - RM351602 | Fillipe Silva - RM352110 | Pedro Abreu - RM352428 |
| [![GitHub](https://img.shields.io/badge/-black?style=flat-square&logo=Github&link=https://github.com/danielecastroalves)](https://github.com/aleqsrosa) | [![GitHub](https://img.shields.io/badge/-black?style=flat-square&logo=Github&link=https://github.com/danielecastroalves)](https://github.com/daviEmanuelNogueira) | [![GitHub](https://img.shields.io/badge/-black?style=flat-square&logo=Github&link=https://github.com/danielecastroalves)](https://github.com/fillipelsilva) | [![GitHub](https://img.shields.io/badge/-black?style=flat-square&logo=Github&link=https://github.com/danielecastroalves)](https://github.com/PedroAbreuHS) |
__________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

## ⚙️ Tecnologias:
* C#;
* .NET 7;
* ASP.NET Core;
* SQLSERVER;

__________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

## 🥋 Skills Desenvolvidas:
* Comunicação;
* Trabalho em Equipe;
* Networking;
* Muito conhecimento técnico.

__________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

## ⚙️ Levantamento de Requisitos e Critérios de Aceite:

### Funcionalidade Esperada
A parte funcional deve registrar o atendimento de uma chamada de call center, registrar o motivo da ligação (pré cadastrado), telefone do cliente, primeiro nome, observação (para inserir alguma informação relevante do atendimento), Status (pré cadastrado) e Substatus (pré cadastrado).

`Motivo:`
- Perda do cartão;
- Desbloqueio do cartão;
- Negociação;
- Informação da conta.

`Status:`
- **Finalizado:** quando o motivo da ligação do cliente foi resolvido no primeiro contato;
- **Pendente:** quando por algum motivo não pode ser resolvido no primeiro atendimento.

`Substatus:`
- **Finalizado:** Cartão desbloqueado com sucesso, Duvidas referente a conta;
- **Pendente:** Cliente não conseguiu confirmar os dados, Negociação pendente de aceite.

`Restrições tecnica:`
- Não permitir o registro quando não for preenchido todos os campos, com exeção da observação;
- Todos os status devem conter um substatus.
__________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

## 🧪 Desenvolvimento (Build e Execução do Projeto):

### Arquitetura:
A estrutura para o desenvolvimento foi baseada e implementada considerando os principios da Arquitetura Limpa e a divisão em camadas:
- Domain;
- Infrastructure;
- Application;
- API;
- WEB;
- Testes.

### Persistência dos Dados:
O banco de dados escolhido foi o SQL Server, por ser um banco relacional e garantir os princípios ACID.

### Testes:
O padrão utilizado é pensado nos testes unitários, testes de integração e regras de negócio.

### Build e Execução do Projeto:
Para executar esses projetos você precisa seguir as etapas abaixo:
- Acessar o repositório do projeto através do link: https://github.com/daviEmanuelNogueira/Crm;
- Baixar o zip do projeto ou fazer um fork do mesmo;
- Abrir o projeto, preferencialmente, na IDE Visual Studio considerando que facilitará para a execução;
- Configurar a api como startup project;
- Rodar o comando update-database no package manage console apontando para o projeto de infraestrutura;
- Clicar na opção, configurar startup projects, selecionar multiple startup projects e colocar o projeto Crm.WEB quanto o projeto Crm.API como start;
- Após iniciar o navegador será iniciado a interação com o sistema, possibilitando o registro de um pré cadastro;

__________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

## ⚙️ Apresentação YouTube:
