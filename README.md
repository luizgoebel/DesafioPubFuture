# DesafioPubFuture
Desafio de programação PubFuture Proway

Orientações para rodar aplicação:

Projeto criado utilizando visual studio 2019 -->

Copie o link github do projeto vá até a navegação superior do visual studio na opção GIT -> clonar repositório -> cole o link do github e indique o diretório.

Em seguida...

--> No projeto vá até arquivo appsettings.json, altere a string de conexão para seu banco de dados conforme exemplo abaixo, geralmente mudar o data Source.
    "DefaultConnection": "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=PubFutureDB; Data Source=DESKTOP-M0JNEVB"
    
--> em seguida novamente na navegação superior em Ferramentas -> Gerenciador de pacostes do NuGet -> Console do gerenciador de pacotes

--> abrirá um prompt gerenciador, você deverá  digitar:
PM> update-database

Este comando irá reconhecer sua string de conexão com o banco de dados(SQLSERVER) e irá criar sua base automaticamente, após este procedimento, você poderá executar a aplicação.




**Há um arquivo da base caso seja mais fácil de restaurar arquivo: PubFutureDB.bak**

--> Para isso é necessário restaurar esse arquivo em sua instância do Sql Server e alterar somente seu Data Source na string de conexão que esta situadaa em appjson no projeto.
