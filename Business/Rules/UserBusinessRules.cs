using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class UserBusinessRules : BaseBusinessRules
    {
        private readonly IUserRepository _userRepository;
        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task CheckIfUserIdNotExists(int id)
        {
            var isExists = await _userRepository.GetAsync(u => u.Id == id);
            if (isExists is null)
                throw new BusinessException("UserId does not exists");
        }
        public async Task UserEmailShouldBeNotExists(string email)
        {
            var isExists = await _userRepository.GetAsync(u => u.Email == email);
            if (isExists is not null) throw new BusinessException("User mail already exists");
        }
        public async Task UserEmailShouldBeExists(string email)
        {
            var isExists = await _userRepository.GetAsync(u => u.Email == email);
            if (isExists is null) throw new BusinessException("Email or Password don't match");
        }
        public Task UserShouldBeExists(User? user)
        {
            if (user is null) throw new BusinessException("Email or Password don't match");
            return Task.CompletedTask;
        }
        public async Task UserPasswordShouldBeMatch(int id, string password)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException("Email or Password don't match");
        }
    }
}
