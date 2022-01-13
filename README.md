# DesafioPubFuture
Desafio de programação PubFuture Proway

Orientações para rodar aplicação:

Projeto criado utilizando visual studio comminity 2019 -->

Copie o link do projeto (github) vá até a naveção superior do visual studio na opção GIT -> clonar repositório -> cole o link e de um diretório.

--> No projeto vá até arquivo appsettings.json, altere a string de conexão para seu banco de dados conforme exemplo abaixo, geralmente mudar o data Source.
    "DefaultConnection": "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=PubFutureDB; Data Source=DESKTOP-M0JNEVB"
    
--> em seguida novamente na navegação superior Ferramentas -> Gerenciador de pacostes do NuGet -> Console do genrenciador de pacotes

--> abrirá um prompt gerenciador, você deverá  digitar:
PM> update-database

Este comando irá reconhecer sua string de conexão com o banco de dados(SQLSERVER) e irá criar sua base automaticamente, após este procedimento, você poderá executar a aplicação.
