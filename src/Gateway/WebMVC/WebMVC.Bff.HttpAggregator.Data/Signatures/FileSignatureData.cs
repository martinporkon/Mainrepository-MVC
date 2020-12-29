using Sooduskorv_MVC.Data.CommonData;

namespace WebMVC.Bff.HttpAggregator.Data.Signatures
{
    public class FileSignatureData : NamedEntityData
    {
        public string ExtensionSignature { get; set; }// byte[] converted
        public string FileExtensionId { get; set; }
    }
}