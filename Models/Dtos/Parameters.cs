﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos
{
    internal class Parameters
    {
    }

    public class UserCredential
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}