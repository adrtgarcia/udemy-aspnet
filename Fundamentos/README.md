# Anotações Gerais

[ ⚠️ em construção ]

### 02 - introdução à arquitetura web

internet: rede, hardware, servidor/roteador/cabo/torre/satélite, protocolo ip, independente da web, os dispositivos são identificados por ip

web: ferramenta, software, texto/imagem/vídeo/áudio, protocolo http, dependente da internet, informações são identificadas por url

arquitetura de aplicações web: 

protocolo http: 

programadores implementam aplicações web, que são hospedadas em servidores web. essas aplicações são acessadas pelos usuários por meio de navegadores web.


### 03 - introdução ao asp.net core mvc

criação do projeto: asp.net core web app (mvc)

mvc - nomenclatura e convenção: 
* todo arquivo controller precisa OBRIGATORIAMENTE terminar com controller no nome
* todo arquivo view deve estar numa pasta que corresponde ao controller específico, e cada método do controller tem seu próprio arquivo view dentro dessa pasta
* pasta shared dentro de view: guarda todos os arquivos que servem de apoio para o projeto
* é interessante que os arquivos model tenham o sufixo model no nome

ciclo de vida básico mvc: 
* toda vez que o programa roda, ele passa no program e vai no método main > cria o host
* classe startup > construtor > injetar iconfiguration > configuração de cookies > adiciona pacote mvc > método configure > confere se o ambiente é de desenvolvimento > se sim, joga a exceção diretamente para mim > oferece permissões e mapeia rotas
* chega em homecontroller (controller padrão, index = view padrão) > toda requisição passa pelo contrutor da controller > chama o index (view) > carrega a página

### Introdução ao Entity Framework Core

documentação microsoft: https://learn.microsoft.com/pt-br/ef/core

é o intermediador entre a aplicação e o banco de dados, permite deixar de preocupar com acesso ao banco, segurança e coisas do tipo

exemplo prático:
* assistir aula 6 para conectar sqlserver

