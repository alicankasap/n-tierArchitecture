using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.UserRepository
{
    public interface IUserService
    {
        Task<IDataResult<List<User>>> GetList();
        User GetByEmail(string email);
        IDataResult<User> GetById(int id);
        Task Add(RegisterAuthDto registerAuthDto);
        IResult Update(User user);
        IResult Delete(User user);
        IResult ChangePassword(UserChangePasswordDto userChangePasswordDto);
        List<OperationClaim> GetUserOperationClaims(int userId);
    }
}
