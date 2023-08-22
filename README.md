<h1 align="center">CRUD de Veículos</h1>


## Sobre o Projeto
Este projeto é oriundo de um processo seletivo, sendo a 5° e última avaliação, partido de um curso gratuito full stack oferecido pela "JN Moura Sistemas de Gestão".
O objetivo é desenvolver uma API em C# que permita a criação, leitura, atualização e exclusão (CRUD) de registros de veículos em uma base de dados SQL Server. 

* [Apresentação do Projeto](https://www.linkedin.com/feed/update/urn:li:activity:7084666810112864256/?originTrackingId=ySDvoBcMSoik4Oj1QWLiGA%3D%3D)
* [Front End](https://github.com/GabrielGiovanii/loja-client-angular)

## Tecnologias Utilizadas
* [C#](https://learn.microsoft.com/en-us/dotnet/csharp)
* [.Net Framework](https://learn.microsoft.com/en-us/dotnet/framework)
* [ASP.NET MVC](https://learn.microsoft.com/pt-br/aspnet/mvc)
* [SQL Server](https://learn.microsoft.com/en-us/sql/?view=sql-server-ver16)
* [Postman](https://learning.postman.com/docs/publishing-your-api/documenting-your-api)
  
## Práticas Adotadas
* Criação de Controladores: Desenvolvimento de controladores para manipular os diferentes métodos HTTP (GET, POST, PUT, DELETE) relacionados aos veículos.
* Validação de Dados: Implementação de validações para garantir que os dados inseridos estejam corretos e completos.
* Utilização de Repositórios: Criação de repositórios para separar as operações de banco de dados da lógica do controlador, seguindo as boas práticas de separação de responsabilidades.
* Cache: Implementação de cache utilizando uma classe de cache para melhorar o desempenho em operações frequentes.
* Logger: Utilização de um sistema de log para registrar eventos importantes e erros durante a execução da API.
* Separação de Responsabilidades: Divisão clara entre controladores, repositórios e modelos para facilitar a manutenção e escalabilidade da API.
* Utilização de Annotations: Uso de DataAnnotations para validar os modelos e garantir a integridade dos dados.
* String de Conexão Segura: Armazenamento de informações sensíveis, como string de conexão e caminho do log, no arquivo de configuração Web.config.

# Como executar
- Clone o projeto
```
git clone https://github.com/GabrielGiovanii/loja-api-rest.git
```
- Execute o projeto
  
## API Endpoints

- Listar Veículos
```
Get: localhost:44369/api/Veiculos

Corpo da Resposta:
[
    {
        "Id": 60,
        "Marca": "Fiat",
        "Nome": "Uno Millie",
        "AnoModelo": 2011,
        "DataFabricacao": "2010-01-01T00:00:00",
        "Valor": 15000.0,
        "Opcional": "ar"
    },
    {
        "Id": 71,
        "Marca": "Honda",
        "Nome": "CG FAN 125",
        "AnoModelo": 2005,
        "DataFabricacao": "2005-01-01T00:00:00",
        "Valor": 5000.0,
        "Opcional": ""
    }
]
```
- Listar Veículo por id
```
Get: localhost:44369/api/Veiculos/{id}

Corpo da Resposta:
    {
        "Id": 60,
        "Marca": "Fiat",
        "Nome": "Uno Millie",
        "AnoModelo": 2011,
        "DataFabricacao": "2010-01-01T00:00:00",
        "Valor": 15000.0,
        "Opcional": "ar"
    }
```

- Criar Veículo
```
Post: localhost:44369/api/Veiculos

Corpo solicitado:
    {
        "Marca": "Honda",
        "Nome":"CG FAN 125",
        "AnoModelo": 2005,
        "DataFabricacao": "2005-01-01T00:00:00",
        "Valor": 5000.00,
        "Opcional": ""
    }
ou
    {
        "Marca": "Honda",
        "Nome":"CG FAN 125",
        "AnoModelo": 2005,
        "DataFabricacao": "2005-01-01T00:00:00",
        "Valor": 5000.00
    }
```

- Atualizar Veículo
```
Put: localhost:44369/api/Veiculos

Corpo solicitado:
    {
        "Id": 43,
        "Marca": "a",
        "Nome": "2",
        "AnoModelo": 2000,
        "DataFabricacao": "1-1-1",
        "Valor": 100.58,
        "Opcional": "ar condicionado"
    }
ou
    {
        "Id": 43,
        "Marca": "a",
        "Nome": "2",
        "AnoModelo": 2000,
        "DataFabricacao": "1-1-1",
        "Valor": 100.58
    }
```

- Deletar Veículo
```
Delete: localhost:44369/api/Veiculos/{id}
```

## Autor
### [Gabriel Giovani](https://www.linkedin.com/in/gabriel-giovanii/)



