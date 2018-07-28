﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using BfkPortal.Database.Interfaces;
using BfkPortal.Models;
using BfkPortal.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class AuthenticationRepository : DefaultRepository, IAuthenticationRepository
    {
        public AuthenticationRepository(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration) { }

        public void Add(User entity)
        {
            Context.Users.Add(entity);
            Save();
        }

        public User Find(int id) => Context.Users.Find(id);

        public User Find(User entity) => Context.Users.Find(entity);

        public void Remove(User entity)
        {
            Context.Users.Remove(entity);
            Save();
        }

        public IEnumerable<User> All() => Context.Users;

        public bool Verify(string email, string password)
        {
            var users = Context.Users.Where(user => user.Email == email);
            if (!users.Any())
                return false;

            foreach (var user in users)
            {
                if (DefaultHashingService.VerifyPassword(email, user.Password, password, user.Salt, Configuration["Pepper"]))
                    return true;
            }
            
            return false;
        }

        //  Only for development
        public void Reset()
        {
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }
    }
}
