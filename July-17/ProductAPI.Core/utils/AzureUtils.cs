using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace ProductAPI.Core.Utils
{
    public class AzureUtils
    {
        private const string KeyVaultName = "DB-Credential";
        private const string SecretName = "ConnectionStrings";
        private readonly Uri _keyVaultUri;

        public AzureUtils()
        {
            _keyVaultUri = new Uri($"https://{KeyVaultName}.vault.azure.net");
        }

        public string GetConnectionString()
        {
            try
            {
                var client = new SecretClient(_keyVaultUri, new DefaultAzureCredential());

                Console.WriteLine($"Retrieving secret '{SecretName}' from Azure Key Vault '{KeyVaultName}'.");

                var secret = client.GetSecret(SecretName);

                Console.WriteLine($"Secret '{SecretName}' retrieved successfully.");

                return secret.Value.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving secret '{SecretName}' from Azure Key Vault '{KeyVaultName}': {ex.Message}");
                throw;
            }
        }
    }
}
