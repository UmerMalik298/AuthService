using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.Application.Common.Auth;
using AuthService.Application.DTOs;
using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Auth;
using AuthService.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;


namespace AuthService.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IJwtTokenGenerator _jwtToken;
        public UserService(AppDbContext context, IJwtTokenGenerator jwtToken)
        {
            _context = context;
            _jwtToken = jwtToken;
        }

        public async Task<ProfileResponse> GetProfileAsync(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new Exception("User not found.");

            return new ProfileResponse(user.Email, user.Name);
        }


        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
                throw new Exception("Invalid credentials.");

            var result = await _context.Users.FirstOrDefaultAsync(u => u.Password == request.Password);
            if (result == null)
                throw new Exception("Invalid credentials.");

            var token = _jwtToken.GenerateToken(user);

            return new AuthResponse(token);
        }


        public async Task RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (existingUser != null)
                throw new Exception("Email already registered.");

            var user = new User
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
            };

           

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateProfileAsync(Guid userId, string newName)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new Exception("User not found.");

            user.Name = newName;
            await _context.SaveChangesAsync();
        }

    }
}
