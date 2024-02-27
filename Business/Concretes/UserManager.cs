using AutoMapper;
using Business.Abstracts;
using Business.Responses.User;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<GetByIdUserResponse>> GetAsync(int id)
        {
            User user = await _userRepository.GetAsync(u => u.Id == id);
            GetByIdUserResponse userResponse = _mapper.Map<GetByIdUserResponse>(user);

            return new SuccessDataResult<GetByIdUserResponse>(userResponse, "Received successfully");
        }
        public async Task<IDataResult<List<GetAllUserResponse>>> GetAllAsync()
        {
            List<User> users = await _userRepository.GetAllAsync();
            List<GetAllUserResponse> getAllUsers = _mapper.Map<List<GetAllUserResponse>>(users);

            return new SuccessDataResult<List<GetAllUserResponse>>(getAllUsers, "Listed successfully");
        }
    }
}
