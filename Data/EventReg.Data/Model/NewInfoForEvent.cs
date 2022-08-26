using EventReg.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventReg.Data.Model
{
    public class NewInfoForEvent : Event, INewInfoForEvent
    {
        public string Location { get; set; }
    }
}
