using Sooduskorv_MVC.Data.CommonData;

namespace WebMVC.Bff.HttpAggregator.Data.Signatures
{
    public class FileSignatureData : NameEntityData
    {
        public string ExtensionSignature { get; set; }// byte[] converted
        public string FileExtensionId { get; set; }
    }
}