using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ITJob.SecurityService.Repository.DbContexts;
using ITJob.SecurityService.Models;
using ITJob.SecurityService.Repository.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ITJob.SecurityService.Repository
{
    public class AuthRepository : IDisposable
    {
        private readonly AuthContext _ctx;

        private readonly UserStore<ApplicationUser> _appUserStore;
        private readonly UserManager<ApplicationUser> _appUserManager;

        private readonly ApplicationRoleManager _appRoleManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();

            _appUserStore = new UserStore<ApplicationUser>(_ctx);
            _appUserManager = new UserManager<ApplicationUser>(_appUserStore);

            _appRoleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(_ctx));
        }

        public async Task<IList<string>> GetUserRoles(ApplicationUser user)
        {
            return await _appUserManager.GetRolesAsync(user.Id);
        }

        public async Task<IdentityRole> GetUserRole(ApplicationUser user)
        {
            return await _appRoleManager.FindByIdAsync(user.Roles.FirstOrDefault().RoleId);
        }

        public async Task<IdentityResult> SetUserRole(ApplicationUser user, IdentityRole role)
        {
            if (_appRoleManager.FindByNameAsync(role.Name).Result == null)
            {
                var roleResult = await _appRoleManager.CreateAsync(role);
                if (!roleResult.Succeeded)
                {
                    return roleResult;
                }
            }
            if (!_appUserManager.IsInRole(user.Id, role.Name))
            {
                return await _appUserManager.AddToRoleAsync(user.Id, role.Name);
            }
            return null;
        }

        public async Task<IdentityResult> RemoveUserRole(ApplicationUser user, IdentityRole role)
        {
            if (_appUserManager.IsInRole(user.Id, role.Name))
            {
                return await _appUserManager.RemoveFromRoleAsync(user.Id, role.Name);
            }
            return null;
        }

        public async Task RemoveUser(string userName)
        {
            var user = await _appUserManager.FindByNameAsync(userName);
            await _appUserManager.DeleteAsync(user);
        }

        public ApplicationUser FindByNationalCode(string nationalCode)
        {
            return _appUserManager.Users.SingleOrDefault(w => w.NationalCode == nationalCode);
        }

        public async Task<bool> ExistNationalCode(string nationalCode)
        {
            return await _appUserManager.Users.CountAsync(c => c.NationalCode == nationalCode) > 0;
        }

        public async Task<IdentityResult> RegisterUserWithRole(ApplicationUser user, string password, string role)
        {
            IdentityResult result;
            var newUser = await _appUserManager.CreateAsync(user, password);
            if (newUser.Succeeded)
            {
                result = await SetUserRole(user, new IdentityRole(role));
            }
            else
            {
                var oldUser = await _appUserManager.FindAsync(user.UserName, password);
                result = await SetUserRole(oldUser, new IdentityRole(role));
            }
            return result;
        }

        public async Task<ApplicationUser> FindUser(string userName, string password)
        {
            var user = await _appUserManager.FindAsync(userName, password);

            return user;
        }

        public IQueryable<ApplicationUser> FindAll()
        {
            return _appUserManager.Users;
        }

        public async void ResetPassword(string userName, string oldPassword, string newPassword)
        {
            var user = await _appUserManager.FindByNameAsync(userName);
            var passwordHash = _appUserManager.PasswordHasher.HashPassword(newPassword);
            await _appUserStore.SetPasswordHashAsync(user, passwordHash);
            await _appUserStore.UpdateAsync(user);
        }

        public Client FindClient(string clientId)
        {
            var client = _ctx.Clients.Find(clientId);

            return client;
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {

            var existingToken = _ctx.RefreshTokens.SingleOrDefault(r => r.Subject == token.Subject && r.ClientId == token.ClientId);

            if (existingToken != null)
            {
                // ReSharper disable once UnusedVariable
                var result = await RemoveRefreshToken(existingToken);
            }

            _ctx.RefreshTokens.Add(token);

            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await _ctx.RefreshTokens.FindAsync(refreshTokenId);

            if (refreshToken != null)
            {
                _ctx.RefreshTokens.Remove(refreshToken);
                return await _ctx.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
            _ctx.RefreshTokens.Remove(refreshToken);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await _ctx.RefreshTokens.FindAsync(refreshTokenId);

            return refreshToken;
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return _ctx.RefreshTokens.ToList();
        }

        public async Task<ApplicationUser> FindAsync(UserLoginInfo loginInfo)
        {
            var user = await _appUserManager.FindAsync(loginInfo);

            return user;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            var result = await _appUserManager.CreateAsync(user);

            return result;
        }

        public async Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
        {
            var result = await _appUserManager.AddLoginAsync(userId, login);

            return result;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _appUserManager.Dispose();

        }
    }
}