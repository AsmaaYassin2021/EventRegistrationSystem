using EventReg.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EventReg.API.Model
{
    public class User
    {  
        public string UserName { get; set; }
        public string Password { get; set; }
    
}
}
