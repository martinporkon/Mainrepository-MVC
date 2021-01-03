using System;

namespace Sooduskorv_MVC.Data.CommonData
{
    public abstract class UniqueEntityData 
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); /* = GuidCombGenerator*/
    }
}