﻿# Marvel Heroes - NET Core 2.2 com Containers 🦸‍♂️🦸‍♀️

Uma aplicação NET Core 2.2 MVC utilizando Redis e MongoDB com conteinerização via docker.

Este projeto não visa implementar uma boa arquitetura de projeto e a única intenção é mostrar como funciona uma implementação com containers.

## Dê uma estrela! :star:
Se você gostou do projeto ou se ele te ajudou, por favor dê uma estrela ;)

## Como utilizar? 🤔

### Dependências 💻

* [NET Core 2.2 instalado.](https://dotnet.microsoft.com/download/dotnet-core/2.2)
* [Docker instalado.](https://www.docker.com/get-started)
* Chaves da API da Marvel. (veja [aqui](https://developer.marvel.com/account)).

### Inicializando 🤩

* Vá no arquivo src\MarvelHeroes.Server\appsettings.json e defina sua chave pública e privada.
* Execute o comando docker no diretório do arquivo da solução (.sln):
```
docker-compose up -d
```
* Acesse https://localhost:44344 da sua máquina local.

## Autor 👦

* **Alexandre Beato** - *Desenvolvedor* - [GitHub](https://github.com/alexandrebeato)

## License 📃

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details

## Referências 🔗

Data provided by Marvel. © 2019 [MARVEL](https://www.marvel.com)