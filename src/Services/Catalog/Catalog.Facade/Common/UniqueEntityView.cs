using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Facade.Common
{
    public abstract class UniqueEntityView : PeriodEntityView
    {
        protected UniqueEntityView() => Id = Guid.NewGuid().ToString();
        [Required] public string Id { get; set; }
        public override string GetId() => Id;
    }
}