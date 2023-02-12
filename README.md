# RPG Game

RPG Game é uma API que possibilita executar ações de um jogo de RPG através dos endpoints existentes.

Os dados de profissões, personagens e batalhas são armazenados em memória, persistindo apenas durante a execução da API.

Alguns dados como o de profissões e personagens iniciais são criados automaticamente no "start" da API.

## Tecnologias e padrões utilizados

Para este projeto foi utilizado o framework .Net 6.0 (C#) e o [Visual Studio Community 2022](https://visualstudio.microsoft.com/pt-br/vs/community/).

**Packages utilizadas:**

- FluentValidation 11.4.0
- AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.0

**Design Patterns utilizados:**

- Singleton
- Factory Method

**Padrões de arquitetura utilizados:**

- Clean Architecture
- DDD
- Hexagonal Architecture

## Inicialização  

Após abrir a solution no Visual Studio:
- Realizar o build da aplicação apertando simultâneamente as teclas: CTRL+SHIFT+B
- Apertar a tecla F5
- A página do Swagger da aplicação (<https://localhost:7157/swagger/index.html>) será exibida com todos os seus endpoints

## Funcionalidades (Endpoints)
###  RELACIONADOS AOS PERSONAGENS  

**OBTÉM TODOS OS PERSONAGENS** 
> GET /Character/GetAllCharacteres/

**Parâmetros:** nenhum  
**Payload:** nenhum  
**Response:** Lista de personagens

```json
[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "name": "string",
    "occupationName": "string",
    "status": "Alive"
  }
]
```
___

**OBTÉM OS DETALHES DO PERSONAGEM PELO ID** 
> GET /Character/GetCharacterDetailById/{id}

**Parâmetros:**  
- Name: id  
- Type: Guid  
- Exemplo: d6152f79-417c-44c4-9a12-4a0ec0083906
  
**Payload:** nenhum  
**Response:** Detalhes do personagem (HTTP Status Code 200)

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "name": "string",
  "occupationName": "string",
  "healthPoints": 0,
  "strenght": 0,
  "dexterity": 0,
  "intelligence": 0,
  "strike": {
    "additionalProp1": 0,
    "additionalProp2": 0,
    "additionalProp3": 0
  },
  "speed": {
    "additionalProp1": 0,
    "additionalProp2": 0,
    "additionalProp3": 0
  }
}
```
___
**CRIA UM NOVO PERSONAGEM** 
> POST /Character/AddCharacter/

**Parâmetros:** nenhum    
**Payload:** Personagem
```json
{
  "name": "string",
  "occupationType": "Warrior"
}
```
**Valores aceitos:**  
_"OccupationType":_ Warrior, Thief e Mage  
_"Name":_ Letras (maiúsculas e minúsculas) e underline

  
**Response:** Personagem criado (HTTP Status Code 200)

```json
{
  "name": "Nome",
  "occupationType": "Warrior"
}
```
___
###  RELACIONADOS A PROFISSÃO

**OBTÉM TODAS AS PROFISSÕES** 
> GET /Occupation/GetAllOccupations/

**Parâmetros:** nenhum  
**Payload:** nenhum  
**Response:** Lista de profissões e seus atributos/modificadores

```json
[
  {
    "occupationType": "Warrior",
    "beattleModifiers": {
      "calculatedBonusStrike": 0,
      "calculatedBonusSpeed": 0,
      "beattleBonusStrike": {
        "additionalProp1": 0,
        "additionalProp2": 0,
        "additionalProp3": 0
      },
      "beattleBonusSpeed": {
        "additionalProp1": 0,
        "additionalProp2": 0,
        "additionalProp3": 0
      }
    },
    "attributes": {
      "attributesDic": {
        "additionalProp1": 0,
        "additionalProp2": 0,
        "additionalProp3": 0
      }
    }
  }
]
```
___
###  RELACIONADOS A BATALHA

**EXECUTA UMA BATALHA** 
> POST /Battle/RunBattle/

**Parâmetros:** nenhum  
**Payload:** Personagens (IDs) que participarão da batalha
```json
[
  "8502bd83-94a0-4725-a1ce-b32bc7d03660", --Shandra
  "e74ef41e-20ab-4ffa-ae71-d1a4f6298e9e" --Adric
]
```
  
**Response:** Log da batalha e informações do ganhador/perdedor

```json
{
  "logs": [
    "Shandra (5) foi mais veloz que o Adric (3), e irá começar!",
    "Shandra atacou Adric com 1 de dano, Adric com 19 pontos de vida restantes",
    "Adric atacou Shandra com 1 de dano, Shandra com 14 pontos de vida restantes",
    "Shandra atacou Adric com 0 de dano, Adric com 19 pontos de vida restantes",
    "Adric atacou Shandra com 2 de dano, Shandra com 12 pontos de vida restantes",
    "Shandra atacou Adric com 7 de dano, Adric com 12 pontos de vida restantes",
    "Adric atacou Shandra com 1 de dano, Shandra com 11 pontos de vida restantes",
    "Shandra atacou Adric com 1 de dano, Adric com 11 pontos de vida restantes",
    "Adric atacou Shandra com 5 de dano, Shandra com 6 pontos de vida restantes",
    "Shandra atacou Adric com 5 de dano, Adric com 6 pontos de vida restantes",
    "Adric atacou Shandra com 2 de dano, Shandra com 4 pontos de vida restantes",
    "Shandra atacou Adric com 4 de dano, Adric com 2 pontos de vida restantes",
    "Adric atacou Shandra com 1 de dano, Shandra com 3 pontos de vida restantes",
    "Shandra atacou Adric com 11 de dano, Adric com 0 pontos de vida restantes",
    "Shandra venceu a batalha! Shandra ainda tem 3 pontos de vida restantes!"
  ],
  "winner": "8502bd83-94a0-4725-a1ce-b32bc7d03660",
  "dead": "e74ef41e-20ab-4ffa-ae71-d1a4f6298e9e"
}
```
___

## Decisões tomadas
- Na inicialização da API alguns personagens são criados automaticamente, bem como as profissões especificadas no enunciado;
- Para persistir os dados em memória, escolhi utilizar o pattern Singleton, pela facilidade de implementação e garantia de persistência sem ter que me preocupar com a expiração dos dados;
- Decidi por adicionar um ID na criação do personagem, para que todas as outras ações sejam realizadas através do mesmo, garantindo performance e consistência;
- No endpoint que executa a batalha, é esperada uma lista de Guids, porém apenas os dois primeiros são utilizados;
- Utilizei um regex na validação do nome do Personagem, garantindo que não sejam aceitos nomes que possuam caracteres diferentes de letras (maiúsculas e minúsculas) e underline;
- Tanto a validação acima como também a validação de quantidade máxima de caracteres foram feitas utilizando-se do FluentValidation.