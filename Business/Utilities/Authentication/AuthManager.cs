using Business.Repositories.UserRepository;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Hashing;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Authentication
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;

        public AuthManager(IUserService userService, ITokenHandler tokenHandler)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
        }

        public IResult CheckIfEmailExists(string email)
        {
            var list = _userService.GetByEmail(email);
            if (list != null)
            {
                return new ErrorResult("Bu mail adresi daha önce kullanılmış");
            }
            return new SuccessResult();
        }

        public IResult CheckIfImageSizeIsLessThanOneMb(long imgSize)
        {
            decimal imgMbSize = (decimal)(imgSize * 0.000001);
            if (imgMbSize > 1)
            {
                return new ErrorResult("Yüklediğiniz fotografın boyutu en fazla 1 mb olmalıdır");
            }
            return new SuccessResult();
        }

        private IResult CheckIfImageExtensionsAllow(string fileName)
        {
            var ext = fileName.Substring(fileName.LastIndexOf('.'));
            var extension = ext.ToLower();
            List<string> AllowFileExtensions = new List<string> { ".jpg", ".jpeg", ".gif", ".png" };

            if (!AllowFileExtensions.Contains(extension))
            {
                return new ErrorResult("Eklediğiniz fotoğrafın türü jpg, jpeg, gif, png türlerinden biri olmalıdır.");
            }
            return new SuccessResult();
        }

        public IDataResult<Token> Login(LoginAuthDto loginAuthDto)
        {
            var user = _userService.GetByEmail(loginAuthDto.Email);
            if (user == null)
            {
                return new ErrorDataResult<Token>("Kullanıcı maili sistemde bulunamadı");
            }
            var result = HashingHelper.VerifyPasswordHash(loginAuthDto.Password, user.PasswordHash, user.PasswordSalt);
            List<OperationClaim> operationClaims = _userService.GetUserOperationClaims(user.Id);

            if (result)
            {
                Token token = new Token();
                //token = _tokenHandler.CreateToken(user, operationClaims);
                return new SuccessDataResult<Token>(token);
            }
            return new ErrorDataResult<Token>("Kullanıcı maili ya da şifresi yanlış");
        }

        [ValidationAspect(typeof(AuthValidator))]
        public async Task<IResult> Register(RegisterAuthDto registerAuthDto)
        {
            IResult result = BusinessRules.Run(
                CheckIfEmailExists(registerAuthDto.Email),
                CheckIfImageExtensionsAllow(registerAuthDto.Image.FileName),
                CheckIfImageSizeIsLessThanOneMb(registerAuthDto.Image.Length)
                );

            if (result != null)
            {
                return result;
            }

            await _userService.Add(registerAuthDto);
            return new SuccessResult("Kullanıcı kaydı başarıyla tamamlandı");
        }
    }
}
