﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Data.Repositories;
using Domain.Interface;
using Domain.Model;

namespace Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _user;

        public UserServices(IUserRepository user)
        {
            _user = user;
        }
        public async Task<bool> AddUserAsync(string username, string fullname, string password, int age,string email,
            CancellationToken cancellationToken)
        {
            
            return await _user.AddUser(username, fullname, password, age, email,cancellationToken);
        }

        public async Task<bool> Any(string username)
        {
            return await _user.Any(username);
        }

        public async Task<User> GetByUsername(string username, string password, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _user.GetByUsername(username, password, cancellationToken);
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
    }
}
