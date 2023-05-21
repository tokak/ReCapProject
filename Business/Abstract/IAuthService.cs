using Core.Entities.Concrete;
using Core.Ultities.Result;
using Core.Ultities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<UsersK> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<UsersK> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(UsersK user);
    }
}
