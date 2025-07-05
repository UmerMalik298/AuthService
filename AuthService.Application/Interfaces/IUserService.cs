using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.Application.DTOs;

namespace AuthService.Application.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterRequest request);
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<ProfileResponse> GetProfileAsync(Guid userId);
        Task UpdateProfileAsync(Guid userId, string newName);
    }

}
