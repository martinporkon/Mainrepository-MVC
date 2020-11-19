using System;
using System.Collections.Generic;
using System.Text;

namespace Sooduskorv_MVC.Facade
{
    public abstract class NamedEntityView:DescribedEntityView
    {
        public string Name { get; set; }
    }
}
