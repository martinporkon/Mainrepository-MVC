namespace Sooduskorv_MVC.Data.CommonData
{
    public abstract class NamedEntityData : UniqueEntityData
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}