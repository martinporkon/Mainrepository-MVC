using System;

namespace Sooduskorv_MVC.CommonTests.OverallTests
{
    public interface IEntity
    {
        DateTime ValidFrom { get; }
        DateTime ValidTo { get; }

        bool IsUnspecified { get; }
    }
    public interface IEntity<out TData> : IEntity
    {
        TData Data { get; }
    }
}
