﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebMVC.Domain.Common
{
    public interface ICrudMethods<T>// TODO?
    {
        Task<List<T>> Get();

        Task<T> Get(string id);

        Task Delete(string id);

        Task Add(T obj);

        Task Update(T obj);
    }
}