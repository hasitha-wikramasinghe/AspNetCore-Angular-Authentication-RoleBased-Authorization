﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_Registration_Sample.Models
{
    public class ApplicationSettings
    {
        public string Jwt_Secret { get; set; }
        public string Client_URL { get; set; }
    }
}
