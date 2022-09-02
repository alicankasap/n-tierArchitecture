using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.JWT;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Authentication
{
    public interface IAuthService
    {
        Task<IResult> Register(RegisterAuthDto registerAuthDto);
        IDataResult<Token> Login(LoginAuthDto loginAuthDto);
        IResult CheckIfEmailExists(string email);
        IResult CheckIfImageSizeIsLessThanOneMb(long imgSize);
    }
}
