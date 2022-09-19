using System;
using System.Collections.Generic;
using System.Text;

namespace Hectre.OMS.Tests.Data.Models
{
    public class Personal
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginDataModel
    {
        public Personal Personal { get; set; }
    }
}
