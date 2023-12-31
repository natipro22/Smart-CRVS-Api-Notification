﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Domain;

namespace AppDiv.CRVS.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<ApplicationUser> GetUserByName(string userName);
        bool Any(string userId);
        Task<(Result result, IList<string>? roles, string? userId)> AuthenticateUser(string email, string password);
        Task<(Result result, string password)> createUser(string userName, string email, Guid IssuerId, Guid userGroupId);
        Task<(Result result, string password, string id)> createUser(ApplicationUser user);

        Task<(Result result, string resetToken)> ForgotPassword(string? email, string? userName);
        Task<Result> ResetPassword(string? email, string? userName, string password, string token);
        Task<Result> ChangePassword(string userName, string oldPassword, string newPassword);
        Task<Result> UpdateUser(string id, string userName, string email, Guid IssuerId, string? opt, DateTime? otpExpiredDate);
        Task<Result> UpdateUserAsync(ApplicationUser user);
        IQueryable<ApplicationUser> AllUsers();
        IQueryable<ApplicationUser> AllUsersDetail();
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<Result> DeleteUser(string userId);
        public Task<Result> UnlockUserAsync(string userName);
        // string GetUserGroupId(string userId);
    }
}

