using System;

namespace Data.CommonData
{
    public abstract class UniqueEntityData
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}