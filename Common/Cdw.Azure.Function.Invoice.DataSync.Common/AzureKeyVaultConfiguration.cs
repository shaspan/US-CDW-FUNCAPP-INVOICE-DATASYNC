namespace Cdw.Azure.Function.Sample.Common
{
    public class AzureKeyVaultConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        public string Endpoint { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public string Prefix { get; set; } = null!;

        
        /// <summary>
        /// 
        /// </summary>
        public string? DataDogApiKey { get; set; }
    }
}
