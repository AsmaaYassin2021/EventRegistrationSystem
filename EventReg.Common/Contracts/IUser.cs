using System;
using System.Collections.Generic;
using System.Text;

namespace EventReg.Common.Contracts
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        string Role { get; set; }
    }
}
