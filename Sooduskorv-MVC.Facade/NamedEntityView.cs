using System;
using System.Collections.Generic;
using System.Text;

namespace Sooduskorv_MVC.Facade
{
    public abstract class NamedEntityView:PeriodView
    {
        public string Name { get; set; } = "asd";
    }
}
