using System;
using System.Collections.Generic;
using System.Text;

namespace CommonData
{
    public abstract class CodedEntityData : NamedEntityData
    {
        public string Code { get; set; }
    }
}