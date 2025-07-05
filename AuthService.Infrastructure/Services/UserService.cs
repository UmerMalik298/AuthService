using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.Application.Common.Auth;
using AuthService.Application.DTOs;
using AuthService.Application.Interfaces;
using AuthService.Infrastructure.Data;


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

        public Task<ProfileResponse> GetProfileAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(RegisterRequest request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProfileAsync(Guid userId, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
