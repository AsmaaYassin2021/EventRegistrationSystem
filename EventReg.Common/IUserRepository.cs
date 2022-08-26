using EventReg.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventReg.Common
{
  public  interface IUserRepository
    {
        Task<bool> Login(string name, string password);
    }
}
