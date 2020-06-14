# DreamLife

Projeto desenvolvido treinamento da empresa Lemaf.

Tecnologias utilizadas: 
C#
Postgres
AngularJS


###Introdução ao problema

A empresa DreamLife está desenvolvendo um aplicativo de gerenciamento de viagens. Neste aplicativo, dentre várias funcionalidades, deverá ser desenvolvida uma tela com uma listagem de futuras viagens do usuário para uma determinada cidade, conforme o protótipo apresentado a seguir. Sua responsabilidade neste teste será desenvolver esta tela. 

##  Implementação

# **Back-end **

Foi criada uma API com o serviço que traga uma listagem com as informações das viagens. 
A requisição foi um método GET, passando como parâmetro o id da cidade. 
*Ex.:* 
http://localhost/Trips/City/{id_cidade} ou http://localhost/Trips/GetTripsByCity?id={id_cidade} 

O arquivo trips.json contém uma listagem com todas as viagens registradas. Dentre as viagens registradas, sua API deverá retornar apenas as viagens com data superior a data de hoje e filtradas por cidade. Esta requisição deverá retornar um array de objetos json.



● Resolução do problema; 
● Orientação a objetos; 
● Conhecimento de C# e .Net; 
● Clareza e qualidade do código; 
● Arquitetura e organização do projeto; 


# **Front-end **

Deverá ser construída uma página seguindo o protótipo apresentado acima. Esta página consumirá os dados da API que você criou, e apresentará as informações das viagens de acordo com a resposta da requisição. 
Deverão ser listadas apenas viagens para Dubai, ou seja, sua requisição deverá passar como parâmetro o id 132.

Ao clicar em um item da lista de viagens, o painel na parte superior deverá exibir as informações específicas desta viagem que foi clicada. Caso nenhuma viagem tenha sido selecionada, deverá ser exibido o texto “Choose a trip".

A página tem como requisito funcionar apenas nas versões mais recentes do chrome e firefox.

Uso de bibliotecas é bem vindo, no entanto evite usar bibliotecas muito antigas, como JQuery.

Obs.: Para abrir a página só é necessário abrir a página index.html, ou ser executado um comando como ‘npm start', ‘gulp serve'.

O front  está comunicando com a API, sem que seja necessário configurações adicionais.






