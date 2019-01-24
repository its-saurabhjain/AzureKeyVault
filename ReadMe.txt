How to Use Azure Key Vault Feature

1. Create and register an application under azure active directory with with the onpremise application will authenticate with
2. use the clinet id and secret
3. Create a KeyVault in azure key vault
4. In the created keyvault add a new service principal, look for the application name created in AD
5. provide necessary permissions for keys and secret
6. copy the url for accessing the secret
7. In dot net code install 2 new nuget packages
dotnet add package Microsoft.IdentityModel.Clients.ActiveDirectory
dotnet add package microsoft.azure.keyvault
8. Modify the code as mentioned in HomeController for acccessing the secret value
