# Cepedi.CleanArch

Executar o projeto `src\Cepedi.BancoCentral.Cadastro.Api` para abrir o swagger

## Características do projeto

- .NET 7.0

- Projeto base para a trilha avançada de .net da residência TIC18. A Residência TIC18 é um projeto oferecido pela parceria entre a Uesc e o Cepedi, localizado em Ilhéus-BA.

## Aplicar migrations
 dotnet ef migrations add Init --project .\src\Cepedi.BancoCentral.Cadastro.Dados\ -s .\src\Cepedi.BancoCentral.Cadastro.Api\

# Remove a última migration aplicada
 dotnet ef migrations remove --project .\src\Cepedi.BancoCentral.Cadastro.Dados\ -s .\src\Cepedi.BancoCentral.Cadastro.Api\

# Gera o script de migração
 dotnet ef migrations script --project .\src\Cepedi.BancoCentral.Cadastro.Dados\ -s .\src\Cepedi.BancoCentral.Cadastro.Api\

# Coloca o banco para o estado inicial zero
 dotnet ef migrations update 0 --project .\src\Cepedi.BancoCentral.Cadastro.Dados\ -s .\src\Cepedi.BancoCentral.Cadastro.Api\

# Criar Migrations
dotnet ef migrations add estruturaBase -s ../Cepedi.BancoCentral.Cadastro.Api/Cepedi.BancoCentral.Cadastro.Api.csproj

# Atualizar Banco
dotnet ef database update -s ../Cepedi.BancoCentral.Cadastro.Api/Cepedi.BancoCentral.Cadastro.Api.csproj


