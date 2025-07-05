using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.Domain.Entities;

namespace AuthService.Application.Common.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
