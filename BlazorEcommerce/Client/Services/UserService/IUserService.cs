﻿namespace BlazorEcommerce.Client.Services.UserService
{
    public interface IUserService
    {

        public Task<string> AddUserAsync(UserRegisterRequest request);
        public Task<User> LoginAsync(UserLoginRequest request);

        public Task VerifyAsync(VerifyModel token);

    }
}
