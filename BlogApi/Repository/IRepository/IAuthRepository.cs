﻿using DataAccess.Models;
using DataAccess.Models.DTO.Security;

namespace BlogApi.Repository.IRepository
{
    public interface IAuthRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<AuthSecurity> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
