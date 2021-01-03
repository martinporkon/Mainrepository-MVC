namespace Sooduskorv_MVC.Data.CommonData
{
    public abstract class NameEntityData : UniqueEntityData, IUniqueNamedData
    {
        public string Name { get; set; }
    }
}