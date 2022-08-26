using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventReg.Common.Contracts
{
  public  interface INewInfoForEvent
    {
       string Location { get; set; }

    }
}
