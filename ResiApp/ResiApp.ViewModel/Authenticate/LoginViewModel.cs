﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResiApp.ViewModels.Authenticate
{
    public class LoginViewModel
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Token { get; set; } = "";
    }

}
