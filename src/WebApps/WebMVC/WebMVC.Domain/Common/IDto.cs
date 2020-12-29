using System;

namespace WebMVC.Domain.Common
{
    public interface IDto
    {
        DateTime ValidFrom { get; }
        DateTime ValidTo { get; }

        bool IsUnspecified { get; }
    }
    public interface IDto<out TData> : IDto
    {
        TData Data { get; }
    }
}