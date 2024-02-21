using Business.Abstracts;
using Business.Responses.User;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserManager:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<GetByIdUserResponse> GetAsync(int id)
        {
            User user = await _userRepository.GetAsync(u => u.Id == id);
            GetByIdUserResponse userResponse = new GetByIdUserResponse()
            {
                Id = user.Id,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                Password = user.Password,
            };
            return userResponse;
        }
        public async Task<List<GetAllUserResponse>> GetAllAsync()
        {
            List<User> users =await _userRepository.GetAllAsync();
            List<GetAllUserResponse> getAllUsers= new List<GetAllUserResponse>();

            foreach (var user in users)
            {
                getAllUsers.Add(new GetAllUserResponse()
                {
                    Id = user.Id,
                    CreatedDate = user.CreatedDate,
                    UpdatedDate = user.UpdatedDate,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth,
                    Email = user.Email,
                    Password = user.Password,
                });
            }
            return getAllUsers;
        }
    }
}
