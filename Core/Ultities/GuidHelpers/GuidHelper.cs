﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultities.GuidHelpers
{
    public class GuidHelper
    {
        public static string CreatGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
