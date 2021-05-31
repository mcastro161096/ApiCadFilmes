# ApiCadFilmes  
Api Rest em ASP.NET Core 5.0 e Ef Core  
Requisitos de negócio:  
Listar os filmes cadastrados  
Cadastrar um novo filme  
Editar um filme  
Remover um filme individualmente  
Remover vários filmes de uma só vez  
  
Como a entidade filme depende da entidade genero para estar consistente, a API conta com o CRUD de Filmes e Generos.  
Caso você clone o projeto e queira rodar ele localmente, basta configurar a connection string que se encontra no arquivo: appsettings.json,  
"ConnectionStrings": {  
    "DefaultConnection": "Password=SUASENHA;Persist Security Info=True;User ID=USUARIODOSEUBANCODEDADOS;Initial Catalog=DbApiCadFilmes;Data Source=NOMEDOSEUSERVIDOR"}.  
    É necessário que se tenha um servidor sql instalado na sua máquina, não é necessário criar o database pois na primeira execução  
  da API o EntityFramework irá aplicar as migrations e criar o banco de dados sozinho.  
  A API conta com a interface do Swagger que possibilita o teste de todos os endpoints da api, mas também pode ser testada via outras ferramentas coo PostMan.  
  A Api também está publicada no Azure Web sites, para acessá-la é necessário fazer as requisições nas seguintes Url's:  
Filmes: https://apicadfilmesapi1.azure-api.net/api/filmes  
Generos: https://apicadfilmesapi1.azure-api.net/api/generos  
Por segurança para fazer requisições para a api publicada no azure é necessário informar a Key: Ocp-Apim-Subscription-Key: VALORDACHAVE, essa chave eu mantenho privada.  
Também disponibilizei uma interface do Swagger no SwaggerHub que está pública, porém para fazer requisições a partir dela será necessário informar a Key citada acima,  
a mesma está acessível no seguinte endereço: https://app.swaggerhub.com/apis/mcastro1610968/api-cad_filmes/1.0  
Exemplos dos objetos json a serem usados nas requests:  
Filme  
{  
    "id": 4,  
    "nome": "Velozes e Furiosos 3",  
    "dataCriacao": "2021-05-30T01:16:40",  
    "ativo": true,  
    "generoId": 2  
  }  
  
  Genero  
  {  
    "id": 7,  
    "nome": "Ficção científica",  
    "dataCriacao": "2021-05-30T01:16:40",  
    "ativo": true  
  }  

  
  
