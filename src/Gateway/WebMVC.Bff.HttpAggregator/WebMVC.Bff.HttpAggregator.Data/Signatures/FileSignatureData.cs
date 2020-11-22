using Sooduskorv_MVC.Data.CommonData;

namespace WebMVC.Bff.HttpAggregator.Data.Signatures
{
    public class FileSignatureData : NamedEntityData
    {
        public byte[] ExtensionSignature { get; set; }
        public string FileExtensionId { get; set; }
    }
}