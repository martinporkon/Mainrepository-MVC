using System;
using System.Collections.Generic;
using System.Text;

namespace Sooduskorv_MVC.Facade
{
    public abstract class DescribedEnityView:NamedEntityView
    {
        public string Description { get; set; }
    }
}
