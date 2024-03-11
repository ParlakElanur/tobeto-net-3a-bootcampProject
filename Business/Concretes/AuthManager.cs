using Business.Abstracts;
using Business.Requests.Applicant;
using Business.Rules;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IApplicantRepository _applicantRepository;
        private readonly UserBusinessRules _rules;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository, IApplicantRepository applicantRepository, UserBusinessRules rules)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaimRepository = userOperationClaimRepository;
            _applicantRepository = applicantRepository;
            _rules = rules;
        }
        public async Task<DataResult<AccessToken>> CreateAccessToken(User user)
        {
            List<OperationClaim> claims = await _userOperationClaimRepository.Query()
            .AsNoTracking().Where(a => a.UserId == user.Id).Select(a => new OperationClaim
            {
                Id = a.OperationClaimId,
                Name = a.OperationClaim.Name
            }).ToListAsync();
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Created Token");
        }

        public async Task<DataResult<AccessToken>> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _userService.GetByMailAsync(userForLoginDto.Email);
            await _rules.UserShouldBeExists(user.Data);
            await _rules.UserEmailShouldBeExists(userForLoginDto.Email);
            await _rules.UserPasswordShouldBeMatch(user.Data.Id, userForLoginDto.Password);
            var createAccessToken = await CreateAccessToken(user.Data);

            return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Login Success");
        }

        public async Task<DataResult<AccessToken>> RegisterApplicant(ApplicantForRegisterDto applicantForRegisterDto)
        {
            await _rules.UserEmailShouldBeNotExists(applicantForRegisterDto.Email);
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(applicantForRegisterDto.Password, out passwordHash, out passwordSalt);
            var applicant = new Applicant
            {
                UserName = applicantForRegisterDto.UserName,
                FirstName = applicantForRegisterDto.FirstName,
                LastName = applicantForRegisterDto.LastName,
                DateOfBirth = applicantForRegisterDto.DateOfBirth,
                Email = applicantForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            await _applicantRepository.AddAsync(applicant);
            var createAccessToken = await CreateAccessToken(applicant);
            return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
        }
    }
}
