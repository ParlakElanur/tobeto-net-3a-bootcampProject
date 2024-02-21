﻿using Business.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserService
    {
        Task<GetByIdUserResponse> GetAsync(int id);
        Task<List<GetAllUserResponse>> GetAllAsync();
    }
}