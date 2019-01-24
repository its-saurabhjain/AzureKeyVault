using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using azureKeyVault.Models;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace azureKeyVault.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public async Task<IActionResult> Contact()
        {
            
            //To vaidate the application with  AD 
            var keyVaultClient = new KeyVaultClient(AuthenticateVault);
            //get the secret from the key vault
            //https://myhclazurekeyvault.vault.azure.net/secrets/test/605179aae9f846eba71890e8967f7f06
            var result = await keyVaultClient.GetSecretAsync("http://<keyvault>.vault.azure.net/secrets/<secretname>/version");
            var connectionString = result.Value;
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        private async Task<string> AuthenticateVault(string authority, string resource, string scope)
        {
            var clientCredential = new ClientCredential("<AD Client ID>", "<AD Client Seceret>");
            var authenticationContext = new AuthenticationContext(authority);
            var result = await authenticationContext.AcquireTokenAsync(resource, clientCredential);
            return result.AccessToken;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
