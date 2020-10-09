using System;

namespace Basket.Data.Common
{
    public abstract class UniqueEntityData
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}