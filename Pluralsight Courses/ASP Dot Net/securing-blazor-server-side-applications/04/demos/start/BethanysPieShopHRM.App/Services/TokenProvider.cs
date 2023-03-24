using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.App.Services
{
    public class TokenProvider
    {
        public string XsrfToken { get; set; }
        public string Cookie { get; set; }

    }

    public class InitialApplicationState { 
        public string XsrfToken { get; set; }
        public string Cookie { get; set; }

    }

}
