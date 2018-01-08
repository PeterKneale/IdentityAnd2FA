# Custom Identity Provider And 2FA Demo
- Aspnet Core 2.0 + Identity + Dapper + 2FA
- Implements a [custom identity provider](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity-custom-storage-providers) (IUserStore etc) using [Dapper](https://github.com/StackExchange/Dapper) in place of entity framework. 
- Allows users to enable two factor auth using [google authenticator](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity-enable-qrcodes) and login using the tokens in addition to their username/pwd
- uses the new sql server on linux container for it's database [microsoft/mssql-server-linux](https://hub.docker.com/r/microsoft/mssql-server-linux/)
