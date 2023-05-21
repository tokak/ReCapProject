﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(UsersK user, List<OperationClaim> operationClaims);
    }
}
