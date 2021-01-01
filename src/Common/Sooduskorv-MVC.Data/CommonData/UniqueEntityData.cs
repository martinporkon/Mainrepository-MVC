using System;

namespace CommonData
{
    public abstract class UniqueEntityData 
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}