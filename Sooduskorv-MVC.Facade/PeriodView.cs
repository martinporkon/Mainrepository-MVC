﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sooduskorv_MVC.Facade
{
    public abstract class DescribedEntityView:UniqueEntityView
    {
        [DataType(DataType.Date)]
        [DisplayName("Valid From")]
        public DateTime? ValidFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Valid To")]
        public DateTime? ValidTo { get; set; }

        public override string GetId() => Id;
    }
}
